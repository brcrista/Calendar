using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Calendar.ObjectModel.DataProviders;

namespace Calendar.WebService.Controllers.Api
{
    /// <summary>
    /// Provides REST endpoints for resources about events.
    /// </summary>
    [ApiController]
    [Route("api/v1/events")]
    public class EventsV1Controller : ControllerBase
    {
        private readonly IEventsProvider eventsProvider;
        private readonly IUserEventsProvider userEventsProvider;

        public EventsV1Controller(IEventsProvider eventsProvider, IUserEventsProvider userEventsProvider)
        {
            this.eventsProvider = eventsProvider;
            this.userEventsProvider = userEventsProvider;
        }

        /// <summary>
        /// Gets data for a given event by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventAsync(long id)
        {
            var event_ = await eventsProvider.GetEventAsync(id);
            if (event_ == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(event_);
            }
        }

        /// <summary>
        /// Gets all users invited to an event.
        /// </summary>
        [HttpGet("guests")]
        public async Task<IActionResult> GetGuestsAsync(int id,  bool? hasAccepted)
        {
            var guests = await userEventsProvider.GetGuestsAsync(id, hasAccepted).ToArrayAsync();
            return Ok(guests);
        }
    }
}