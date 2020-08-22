using System;
using System.Collections.Generic;

using Calendar.DataAccess;
using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public sealed class SqliteUserEventsProvider : IUserEventsProvider
    {
        private readonly UserEventsTableAccess userEventsTable;
        private readonly IEventsProvider eventsProvider;
        private readonly IUsersProvider usersProvider;

        public SqliteUserEventsProvider(
            UserEventsTableAccess userEventsTable,
            IEventsProvider eventsProvider,
            IUsersProvider usersProvider)
        {
            this.userEventsTable = userEventsTable;
            this.eventsProvider = eventsProvider;
            this.usersProvider = usersProvider;
        }

        public async IAsyncEnumerable<Event> GetEventsAsync(long id, long? hostId, bool? hasAccepted)
        {
            // TODO hostId and hasAccepted
            await foreach (var userEventsRow in userEventsTable.GetByUserAsync(id))
            {
                var event_ = await eventsProvider.GetEventAsync(userEventsRow.EventId);
                if (event_ == null)
                {
                    throw new DataConsistencyException($"The UserEvents table contains an event ID {userEventsRow.EventId}, but no such event exists in the Events table.");
                }

                yield return event_;
            }
        }

        public async IAsyncEnumerable<Guest> GetGuestsAsync(long id, bool? hasAccepted)
        {
            // TODO hasAccepted
            await foreach (var userEventsRow in userEventsTable.GetByEventAsync(id))
            {
                var user = await usersProvider.GetUserAsync(userEventsRow.UserId);
                if (user == null)
                {
                    throw new DataConsistencyException($"The UserEvents table contains a user ID {userEventsRow.EventId}, but no such user exists in the Users table.");
                }

                yield return new Guest
                {
                    User = user,
                    HasAccepted = Convert.ToBoolean(userEventsRow.Accepted)
                };
            }
        }
    }
}
