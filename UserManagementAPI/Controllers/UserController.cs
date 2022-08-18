using System.Collections.Generic;
using UserManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UserManagementAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<Users> _oUsers = new List<Users>() {
            new Users() {Id=1, Name="Juan Dela Cruz", UserId= 1 },
            new Users() {Id=2, Name="Jose Rizal", UserId= 2  },
            new Users() {Id=3, Name="Andres Bonifacio", UserId= 3 },
            new Users() {Id=4, Name="General Luna", UserId= 4 },
            new Users() {Id=5, Name="Juan Luna", UserId= 5 },
        };

        [HttpGet]
        public IActionResult Gets()
        {
            if(_oUsers.Count == 0)
            {
                return NotFound("No users found.");
            }
            return Ok(_oUsers);
        }
        [HttpGet("GetUser")]
        public IActionResult Get(int id)
        {
            var oUser = _oUsers.SingleOrDefault(x => x.Id == id);
            if (oUser == null)
            {
                return NotFound("No user found.");
            }
            return Ok(oUser);
        }
        [HttpPost]
        public IActionResult Save(Users oUser)
        {
            _oUsers.Add(oUser);
            if (_oUsers.Count == 0)
            {
                return NotFound("No list found.");
            }
            return Ok(_oUsers);
        }
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var oUser = _oUsers.SingleOrDefault(x => x.Id == id);
            if (oUser == null)
            {
                return NotFound("No user found");
            }
            _oUsers.Remove(oUser);
            if (_oUsers.Count == 0)
            {
                return NotFound("No list found.");
            }
            return Ok(_oUsers);

        }

    }

}
