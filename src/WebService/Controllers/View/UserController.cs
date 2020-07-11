using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Calendar.ObjectModel.DataProviders;

namespace Calendar.WebService.Controllers.View
{
    [Controller]
    [Route("users/{id}")]
    public sealed class UserController : Controller
    {
        private readonly IUsersProvider usersProvider;

        public UserController(IUsersProvider usersProvider)
        {
            this.usersProvider = usersProvider;
        }

        public async Task<IActionResult> GetUser(long id)
        {
            var user = await usersProvider.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.Title = $"{user.DisplayName}'s profile";
                return View(user);
            }
        }
    }
}
