using Microsoft.AspNetCore.Mvc;

namespace Calendar.WebService.Controllers
{
    [Controller]
    [Route("users/{id}")]
    public sealed class UserViewController : Controller
    {
        public IActionResult ViewUser(long id)
        {
            return View();
        }
    }
}
