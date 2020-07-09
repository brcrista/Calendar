using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Calendar.ObjectModel.DataProviders;
using Calendar.ObjectModel.Models;

namespace Calendar.ApiService.Controllers
{
    /// <summary>
    /// Provides REST endpoints for resources about a user.
    /// </summary>
    [ApiController]
    [Route("api/v1/users/{id}")]
    public class UsersV1Controller : ControllerBase
    {
        private readonly IUsersProvider usersProvider;

        public UsersV1Controller(IUsersProvider usersProvider)
        {
            this.usersProvider = usersProvider;
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
        public async Task<IEnumerable<Event>> GetEventsAsync(int id, int? hostId, bool? hasAccepted)
        {
            return await usersProvider.GetEventsAsync(id, hostId, hasAccepted);
        }

        /// <summary>
        /// Gets the other users that the user has connected with.
        /// </summary>
        [HttpGet("contacts")]
        public async Task<IEnumerable<User>> GetContactsAsync(long id)
        {
            return await usersProvider.GetContactsAsync(id);
        }
    }
}