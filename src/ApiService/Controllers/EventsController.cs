using Microsoft.AspNetCore.Mvc;

namespace Calendar.ApiService.Controllers
{
    /// <summary>
    /// Provides REST endpoints for resources about events.
    /// </summary>
    [ApiController]
    [Route("api/v1/events")]
    public class EventsV1Controller : ControllerBase
    {
        /// <summary>
        /// Gets data for a given event by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public Event GetEvent(int id)
        {
            return new Event
            {
                Id = id,
            };
        }
    }
}