using Microsoft.AspNetCore.Mvc;

namespace Calendar.ApiService
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersV1Controller : ControllerBase
    {
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