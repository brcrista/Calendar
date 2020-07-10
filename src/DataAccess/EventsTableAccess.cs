using System.Collections.Generic;

using Calendar.DataAccess.Schema;

namespace Calendar.DataAccess
{
    /// <summary>
    /// Provides access to the <c>Events</c> table in SQLite.
    /// </summary>
    public sealed class EventsTableAccess
    {
        private readonly SqliteDataReader dataReader;

        public EventsTableAccess(SqliteDatabaseContext dbContext)
        {
            dataReader = new SqliteDataReader(dbContext.DatabaseFilepath);
        }

        public async IAsyncEnumerable<EventsRow> GetEventsAsync(long id)
        {
            var resultRows = dataReader.ExecuteAsync(
                sql: "SELECT * FROM Events WHERE id = $id;",
                parameters: new Dictionary<string, object>
                {
                    ["$id"] = id
                });

            await foreach (var row in resultRows)
            {
                yield return new EventsRow
                {
                    Id = (long)row[0],
                    Title = SqliteDataReader.CastReference<string>(row[1]),
                    Start = SqliteDataReader.CastReference<string>(row[2]),
                    End = SqliteDataReader.CastReference<string>(row[3]),
                    Location = SqliteDataReader.CastReference<string>(row[4]),
                    Description = SqliteDataReader.CastReference<string>(row[5]),
                    OwnerId = SqliteDataReader.CastValue<long>(row[6])
                };
            }
        }
    }
}
