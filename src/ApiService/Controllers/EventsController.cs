using Microsoft.AspNetCore.Mvc;

namespace Calendar.ApiService
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
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