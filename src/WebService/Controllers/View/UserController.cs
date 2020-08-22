using System.Linq;
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
                var events = usersProvider.GetEventsAsync(id, hostId: null, hasAccepted: null);
                user.Events = await events.ToListAsync();

                ViewBag.Title = $"{user.DisplayName}'s profile";
                return View(user);
            }
        }
    }
}
