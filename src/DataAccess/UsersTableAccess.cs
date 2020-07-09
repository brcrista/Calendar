using System.Collections.Generic;

using Calendar.DataAccess.Schema;

namespace Calendar.DataAccess
{
    /// <summary>
    /// Provides access to the <c>Events</c> table in SQLite.
    /// </summary>
    public sealed class UsersTableAccess
    {
        private readonly SqliteDataReader dataReader;

        public UsersTableAccess(SqliteDatabaseContext dbContext)
        {
            dataReader = new SqliteDataReader(dbContext.DatabaseFilepath);
        }

        public async IAsyncEnumerable<UsersRow> GetUsersAsync(long id)
        {
            var resultRows = dataReader.ExecuteAsync(
                sql: "SELECT * FROM Users WHERE id = $id;",
                parameters: new Dictionary<string, object>
                {
                    ["$id"] = id
                });

            await foreach (var row in resultRows)
            {
                yield return new UsersRow
                {
                    Id = (long)row[0],
                    DisplayName = (string?)row[1],
                    AccountId = (long?)row[2]
                };
            }
        }
    }
}
