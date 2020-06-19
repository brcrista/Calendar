using Microsoft.AspNetCore.Mvc;

namespace Calendar.ApiService
{
    [ApiController]
    [Route("[controller]/{eventId}")]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public Event GetEvent([FromRoute] int eventId)
        {
            return new Event
            {
                Id = eventId,
            };
        }
    }
}