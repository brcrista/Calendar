using System.Collections.Generic;
using System.Threading.Tasks;

using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public interface IUsersProvider
    {
        Task<User> GetUserAsync(int id);

        Task<IEnumerable<Event>> GetEventsAsync(int id, int? hostId, bool? hasAccepted);

        Task<IEnumerable<User>> GetContactsAsync(int id);
    }
}