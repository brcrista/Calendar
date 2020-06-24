using Microsoft.AspNetCore.Mvc;

namespace Calendar.ApiService
{
    /// <summary>
    /// Provides REST endpoints for resources about users.
    /// </summary>
    [ApiController]
    [Route("api/v1/users")]
    public class UsersV1Controller : ControllerBase
    {
        /// <summary>
        /// Gets data for a given user by their ID.
        /// </summary>
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return new User
            {
                Id = id,
                DisplayName = "Jane Doe",
                Account = new Account
                {
                    Id = 1,
                    Email = "jane.doe@email.com",
                    Password = "1234"
                }
            };
        }
    }
}