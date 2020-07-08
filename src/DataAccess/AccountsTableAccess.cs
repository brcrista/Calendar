using System.Collections.Generic;

using Calendar.DataAccess.Schema;

namespace Calendar.DataAccess
{
    /// <summary>
    /// Provides access to the <c>Events</c> table in SQLite.
    /// </summary>
    public sealed class AccountsTableAccess
    {
        private readonly SqliteDataReader dataReader;

        public AccountsTableAccess(SqliteDatabaseContext dbContext)
        {
            dataReader = new SqliteDataReader(dbContext.DatabaseFilepath);
        }

        public async IAsyncEnumerable<AccountsRow> GetAccountsAsync(long id)
        {
            var resultRows = dataReader.ExecuteAsync(
                sql: "SELECT * FROM Accounts WHERE id = $id;",
                parameters: new Dictionary<string, object>
                {
                    ["$id"] = id
                });

            await foreach (var row in resultRows)
            {
                yield return new AccountsRow
                {
                    Id = (long)row[0],
                    Email = (string)row[1],
                    Password = (string)row[2]
                };
            }
        }
    }
}
