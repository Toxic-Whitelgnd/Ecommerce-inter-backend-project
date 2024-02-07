using EcommerceWebsite.Db;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginSignupController : Controller
    {
        private readonly ApplicationUsercontext _db;

        public LoginSignupController(ApplicationUsercontext db)
        {
            _db  = db;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserModel u1)
        {
            _db.Add(u1);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string email,string password)
        {
            UserModel u1 = _db.userdetails.FirstOrDefault(x => x.Password == password
            && x.Email == email);
            if(u1 != null)
            {
                Console.WriteLine("Login successfull");
                return Ok(u1);
            }
            else
            {
                Console.WriteLine("Invalid user");
                return Ok("Invalid user");
            }
        }

        [HttpGet("getuserdatabyid")]
        public IActionResult GetUserDetails(int id)
        {
            UserModel u2 = _db.userdetails.FirstOrDefault(x => x.Id == id);
            return Ok(u2);
        }

        [HttpPut("updateuserdata")]
        public IActionResult UpdateUserdata (UserModel u2)
        {
           
            _db.Update(u2);
            _db.SaveChanges();
            return Ok("Updated");
        }
    }
}
