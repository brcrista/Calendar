using Microsoft.AspNetCore.Mvc;

namespace Calendar.ApiService
{
    [ApiController]
    [Route("api/v1/events")]
    public class EventsV1Controller : ControllerBase
    {
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