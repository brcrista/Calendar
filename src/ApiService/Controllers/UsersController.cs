using Microsoft.AspNetCore.Mvc;

namespace Calendar.ApiService
{
    [ApiController]
    [Route("[controller]/{userId}")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public User GetUser([FromRoute] int userId)
        {
            return new User
            {
                Id = userId,
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