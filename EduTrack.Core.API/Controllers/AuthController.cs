using EduTrack.Core.Application;
using EduTrack.Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthservice _authservice;
        public AuthController(IAuthservice authservice)
        {
                _authservice= authservice;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var result =await _authservice.LoginAsync(request);
            if (result == null)
            {
                return Unauthorized("Invalid Credentials");
            }
            else
            { 
                return Ok(result);
            }
           
        }
    }
}
