using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;

namespace Calendar.DataAccess
{
    public sealed class DataReader : IAsyncDisposable
    {
        private readonly SqliteConnection dbConnection;

        private DataReader(string databaseFilepath)
        {
            this.dbConnection = new SqliteConnection(new SqliteConnectionStringBuilder
            {
                ["Data Source"] = databaseFilepath,
                ["Mode"] = SqliteOpenMode.ReadOnly
            }.ConnectionString);
        }

        public static async Task<DataReader> ConnectAsync(string databaseFilepath)
        {
            var result = new DataReader(databaseFilepath);
            await result.dbConnection.OpenAsync();
            return result;
        }

        public async ValueTask DisposeAsync()
        {
            await dbConnection.DisposeAsync();
        }

        public async IAsyncEnumerable<object[]> ExecuteAsync(string sql, IReadOnlyDictionary<string, object> parameters)
        {
            SqliteCommand command = CreateCommand(sql, parameters);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var row = new object[reader.FieldCount];
                reader.GetValues(row);
                yield return row;
            }
        }

        private SqliteCommand CreateCommand(string sql, IReadOnlyDictionary<string, object> parameters)
        {
            var command = dbConnection.CreateCommand();
            command.CommandText = sql;

            foreach (var kvp in parameters)
            {
                command.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }

            return command;
        }
    }
}
