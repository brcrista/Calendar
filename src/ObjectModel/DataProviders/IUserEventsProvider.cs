using System.Collections.Generic;

using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    /// <summary>
    /// Provides methods for dealing with event invitations and attendance.
    /// </summary>
    /// <remarks>
    /// Because .NET dependency injection won't let implementations of <see cref="IEventsProvider"/> and <see cref="IUsersProvider"/>
    /// have a circular dependency, these methods need to exist on a separate type.
    /// </remarks>
    public interface IUserEventsProvider
    {
        IAsyncEnumerable<Event> GetEventsAsync(long userId, long? hostId, bool? hasAccepted);

        IAsyncEnumerable<Guest> GetGuestsAsync(long eventId, bool? hasAccepted);
    }
}
