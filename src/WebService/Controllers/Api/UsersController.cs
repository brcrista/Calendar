using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Calendar.ObjectModel.DataProviders;

namespace Calendar.WebService.Controllers.Api
{
    /// <summary>
    /// Provides REST endpoints for resources about a user.
    /// </summary>
    [ApiController]
    [Route("api/v1/users/{id}")]
    public class UsersV1Controller : ControllerBase
    {
        private readonly IUsersProvider usersProvider;
        private readonly IUserEventsProvider userEventsProvider;

        public UsersV1Controller(IUsersProvider usersProvider, IUserEventsProvider userEventsProvider)
        {
            this.usersProvider = usersProvider;
            this.userEventsProvider = userEventsProvider;
        }

        /// <summary>
        /// Gets data for a given user by their ID.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUserAsync(long id)
        {
            var user = await usersProvider.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        /// <summary>
        /// Gets all future events that a user has been invited to.
        /// </summary>
        [HttpGet("events")]
        public async Task<IActionResult> GetEventsAsync(int id, int? hostId, bool? hasAccepted)
        {
            var events = await userEventsProvider.GetEventsAsync(id, hostId, hasAccepted).ToArrayAsync();
            return Ok(events);
        }

        /// <summary>
        /// Gets the other users that the user has connected with.
        /// </summary>
        [HttpGet("contacts")]
        public async Task<IActionResult> GetContactsAsync(long id)
        {
            var contacts = await usersProvider.GetContactsAsync(id).ToArrayAsync();
            return Ok(contacts);
        }
    }
}