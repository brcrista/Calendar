using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Calendar.DataAccess;
using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public sealed class SqliteUsersProvider : IUsersProvider
    {
        private readonly UsersTableAccess usersTable;
        private readonly UserEventsTableAccess userEventsTable;
        private readonly IEventsProvider eventsProvider;

        public SqliteUsersProvider(
            UsersTableAccess usersTable,
            UserEventsTableAccess userEventsTable,
            IEventsProvider eventsProvider)
        {
            this.usersTable = usersTable;
            this.userEventsTable = userEventsTable;
            this.eventsProvider = eventsProvider;
        }

        public async Task<User?> GetUserAsync(long id)
        {
            var resultRows = usersTable.GetUsersAsync(id);
            var row = await resultRows.AssertSingleRowAsync();

            var result = new User
            {
                Id = row.Id,
                DisplayName = row.DisplayName,
                AccountId = row.AccountId
            };

            await foreach (var userEventsRow in userEventsTable.GetByUserAsync(result.Id))
            {
                var event_ = await eventsProvider.GetEventAsync(userEventsRow.EventId);
                if (event_ == null)
                {
                    throw new DataConsistencyException($"The UserEvents table contains an event ID {userEventsRow.EventId}, but no such event exists in the Events table.");
                }

                result.Events.Add(event_);
            }

            return result;
        }

        public Task<IEnumerable<User>> GetContactsAsync(long id)
        {
            // TODO
            return Task.FromResult(Enumerable.Empty<User>());
        }

        public Task<IEnumerable<Event>> GetEventsAsync(int id, int? hostId, bool? hasAccepted)
        {
            // TODO
            return Task.FromResult(Enumerable.Empty<Event>());
        }
    }
}
