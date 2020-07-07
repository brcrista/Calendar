using System.Threading.Tasks;

using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public sealed class MemoryEventsProvider : IEventsProvider
    {
        public Task<Event> GetEventAsync(int id)
        {
            return Task.FromResult(new Event
            {
                Id = id,
            });
        }
    }
}
