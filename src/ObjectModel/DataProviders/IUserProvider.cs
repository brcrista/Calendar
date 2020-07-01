using System.Collections.Generic;

using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public interface IUserProvider
    {
        User GetUser(int id);

        IEnumerable<Event> GetEvents(int id, int? hostId, bool? hasAccepted);

        IEnumerable<User> GetContacts(int id);
    }
}