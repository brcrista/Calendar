using Microsoft.AspNetCore.Mvc;

namespace Calendar.WebService.Controllers.View
{
    [Controller]
    [Route("events/{id}")]
    public sealed class EventController : Controller
    {
        public IActionResult GetEvent(long id)
        {
            ViewBag.Title = "TITLE";
            return View();
        }
    }
}
