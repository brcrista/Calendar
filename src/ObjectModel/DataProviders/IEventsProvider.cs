using Calendar.ObjectModel.Models;

namespace Calendar.ObjectModel.DataProviders
{
    public interface IEventsProvider
    {
        Event GetEvent(int id);
    }
}