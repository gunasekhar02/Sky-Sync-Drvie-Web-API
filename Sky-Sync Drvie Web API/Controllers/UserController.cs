using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sky_Sync_Drvie_Web_API.Models;

namespace Sky_Sync_Drvie_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public UserController(AppDbContext dbContext) { 
            _appDbContext = dbContext;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAlluser()
        {
            try
            {
                var users= _appDbContext.Users;
                return Ok(users);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _appDbContext.Users.Find(id);
                if (user == null)
                {
                    return NotFound("user not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUserById/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _appDbContext.Users.Find(id);
                if (user == null)
                {
                    return NotFound("user not found to delete");
                }
                _appDbContext.Users.Remove(user);
                _appDbContext.SaveChanges();
                return Ok("user deleted");
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

    }
}
