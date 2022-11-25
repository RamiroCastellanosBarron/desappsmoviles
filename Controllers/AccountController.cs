using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace movies.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public ActionResult<LoginResponse> Login([FromQuery]User user)
        {
            if(user.Username == "Ramiro" && user.Password == "Castellanos") return Ok(new LoginResponse { Code = "Successfull" });
            
            return Ok(new LoginResponse { Code = "Error"});
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Code { get; set; }
    }
}
