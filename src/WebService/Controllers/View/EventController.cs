using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Calendar.ObjectModel.DataProviders;

namespace Calendar.WebService.Controllers.View
{
    [Controller]
    [Route("events/{id}")]
    public sealed class EventController : Controller
    {
        private readonly IEventsProvider eventsProvider;
        private readonly IUserEventsProvider userEventsProvider;

        public EventController(IEventsProvider eventsProvider, IUserEventsProvider userEventsProvider)
        {
            this.eventsProvider = eventsProvider;
            this.userEventsProvider = userEventsProvider;
        }

        public async Task<IActionResult> GetEvent(long id)
        {
            var event_ = await eventsProvider.GetEventAsync(id);
            if (event_ == null)
            {
                return NotFound();
            }
            else
            {
                var guests = userEventsProvider.GetGuestsAsync(id, hasAccepted: null);
                event_.Guests = await guests.ToListAsync();

                ViewBag.Title = event_.Title;
                return View(event_);
            }
        }
    }
}
