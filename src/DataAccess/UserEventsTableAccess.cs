using System.Collections.Generic;

using Calendar.DataAccess.Schema;

namespace Calendar.DataAccess
{
    /// <summary>
    /// Provides access to the <c>UserEvents</c> table in SQLite.
    /// </summary>
    public sealed class UserEventsTableAccess
    {
        private readonly SqliteDataReader dataReader;

        public UserEventsTableAccess(SqliteDatabaseContext dbContext)
        {
            dataReader = new SqliteDataReader(dbContext.DatabaseFilepath);
        }

        public async IAsyncEnumerable<UserEventsRow> GetByUserAsync(long userId)
        {
            var resultRows = dataReader.ExecuteAsync(
                sql: "SELECT * FROM UserEvents WHERE user_id = $id;",
                parameters: new Dictionary<string, object>
                {
                    ["$id"] = userId
                });

            await foreach (var row in resultRows)
            {
                yield return new UserEventsRow
                {
                    UserId = (long)row[0],
                    EventId = (long)row[1],
                    Accepted = (long)row[2]
                };
            }
        }

        public async IAsyncEnumerable<UserEventsRow> GetByEventAsync(long eventId)
        {
            var resultRows = dataReader.ExecuteAsync(
                sql: "SELECT * FROM UserEvents WHERE event_id = $id;",
                parameters: new Dictionary<string, object>
                {
                    ["$id"] = eventId
                });

            await foreach (var row in resultRows)
            {
                yield return new UserEventsRow
                {
                    UserId = (long)row[0],
                    EventId = (long)row[1],
                    Accepted = (long)row[2]
                };
            }
        }
    }
}
