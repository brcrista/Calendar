using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public sealed class MemoryEventsProvider : IEventsProvider
    {
        public Event GetEvent(int id)
        {
            return new Event
            {
                Id = id,
            };
        }
    }
}
