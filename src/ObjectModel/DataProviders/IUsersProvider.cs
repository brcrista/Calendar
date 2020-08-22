using System.Collections.Generic;
using System.Threading.Tasks;

using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public interface IUsersProvider
    {
        Task<User?> GetUserAsync(long id);

        IAsyncEnumerable<User> GetContactsAsync(long id);
    }
}