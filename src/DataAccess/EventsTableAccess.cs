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

        public EventsTableAccess()
        {
            dataReader = new SqliteDataReader(@"C:\Users\Brian\Code\GitHub\brcrista\Calendar\calendar.db");
        }

        public async IAsyncEnumerable<EventsRow> GetEventsAsync(int id)
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
                    Title = (string)row[1],
                    Start = (string)row[2],
                    End = (string)row[3],
                    Location = (string)row[4],
                    OwnerId = (long)row[5]
                };
            }
        }
    }
}
