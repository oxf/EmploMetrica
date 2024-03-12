using EmploMetrica.Application.UseCases;
using EmploMetrica.Domain.Users;
using EmploMetrica.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using IAuthenticationService = EmploMetrica.Application.UseCases.IAuthenticationService;

namespace EmploMetrica.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController(IAuthenticationService _authenticationService) : ControllerBase
    {
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            var res = _authenticationService.Register(registerDto);
            if (res.Success) return Ok(res);
            else return Unauthorized(res.Errors);
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var res = _authenticationService.Login(loginDto);
            if (res.Success) return Ok(res);
            else return Unauthorized(res.Errors);
        }
        [HttpPost("Refresh")]
        public IActionResult Refresh([FromBody] RefreshToken RefreshTokenRequest)
        {
            var res = _authenticationService.Refresh(RefreshTokenRequest);
            if (res.Success) return Ok(res);
            else return Unauthorized(res.Errors);
        }
    }
}
