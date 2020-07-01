using System.Collections.Generic;

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
        public User GetUser(int id)
        {
            return usersProvider.GetUser(id);
        }

        /// <summary>
        /// Gets all future events that a user has been invited to.
        /// </summary>
        [HttpGet("events")]
        public IEnumerable<Event> GetEvents(int id, int? hostId, bool? hasAccepted)
        {
            return usersProvider.GetEvents(id, hostId, hasAccepted);
        }

        /// <summary>
        /// Gets the other users that the user has connected with.
        /// </summary>
        [HttpGet("contacts")]
        public IEnumerable<User> GetContacts(int id)
        {
            return usersProvider.GetContacts(id);
        }
    }
}