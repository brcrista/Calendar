using Microsoft.AspNetCore.Mvc;

namespace Calendar.WebService.Controllers.View
{
    [Controller]
    [Route("users/{id}")]
    public sealed class UserController : Controller
    {
        public IActionResult GetUser(long id)
        {
            ViewBag.Title = "DISPLAY_NAME's profile";
            return View();
        }
    }
}
