using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Sky_Sync_Drvie_Web_API.Models;
using Sky_Sync_Drvie_Web_API.Services;
using static Sky_Sync_Drvie_Web_API.Models.RequestClasses;

namespace Sky_Sync_Drvie_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupRequestDto signupUser)
        {
            var user = await _userService.RegisterUser(signupUser);
            return Ok(new { user.Id, signupUser.Email });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginUser)
        {
            var user = await _userService.AuthenticateUser(loginUser);
            if (user == null)
                return Unauthorized();

            var token = _tokenService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
    }
}
