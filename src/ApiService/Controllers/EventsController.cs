using Microsoft.AspNetCore.Mvc;

using Calendar.ObjectModel.Models;
using Calendar.ObjectModel.DataProviders;

namespace Calendar.ApiService.Controllers
{
    /// <summary>
    /// Provides REST endpoints for resources about events.
    /// </summary>
    [ApiController]
    [Route("api/v1/events")]
    public class EventsV1Controller : ControllerBase
    {
        private readonly IEventsProvider eventsProvider;

        public EventsV1Controller(IEventsProvider eventsProvider)
        {
            this.eventsProvider = eventsProvider;
        }

        /// <summary>
        /// Gets data for a given event by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public Event GetEvent(int id)
        {
            return eventsProvider.GetEvent(id);
        }
    }
}