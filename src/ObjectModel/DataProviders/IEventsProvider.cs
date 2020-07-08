using System.Threading.Tasks;

using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public interface IEventsProvider
    {
        Task<Event?> GetEventAsync(long id);
    }
}