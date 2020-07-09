using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Calendar.DataAccess;
using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public sealed class SqliteEventsProvider : IEventsProvider
    {
        private readonly EventsTableAccess eventsTable;
        private readonly IUsersProvider usersProvider;

        public SqliteEventsProvider(EventsTableAccess eventsTable, IUsersProvider usersProvider)
        {
            this.eventsTable = eventsTable;
            this.usersProvider = usersProvider;
        }

        public async Task<Event?> GetEventAsync(long id)
        {
            var resultRows = eventsTable.GetEventsAsync(id);

            Event? result = null;
            await foreach (var row in resultRows)
            {
                Debug.Assert(result == null, "Since `id` is a primary key, we should get at most one row back.");

                DateTime? startTime;
                if (DateTime.TryParse(row.Start, out DateTime parsedStartTime))
                {
                    startTime = parsedStartTime;
                }
                else
                {
                    Debug.Assert(false, $"Could not parse start time {row.Start}.");
                    startTime = null;
                }

                DateTime? endTime;
                if (DateTime.TryParse(row.End, out DateTime parsedEndTime))
                {
                    endTime = parsedEndTime;
                }
                else
                {
                    Debug.Assert(false, $"Could not parse end time {row.End}.");
                    endTime = null;
                }

                User? owner;
                if (row.OwnerId != null)
                {
                    owner = await usersProvider.GetUserAsync(row.OwnerId.Value);
                }
                else
                {
                    owner = null;
                }

                result = new Event
                {
                    Id = row.Id,
                    Title = row.Title,
                    Start = startTime,
                    End = endTime,
                    Location = row.Location,
                    Owner = owner
                };
            }

            return result;
        }
    }
}
