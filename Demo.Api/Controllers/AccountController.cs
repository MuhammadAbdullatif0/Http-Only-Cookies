using Demo.Api.Dtos;
using Demo.Api.Entites;
using Demo.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(
        UserManager<ApplicationUser> _userManager,
        SignInManager<ApplicationUser> _signManager,
        TokenService tokenService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
            {
            var user = await _userManager.FindByEmailAsync(loginDto.UserName);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, loginDto.Password)))
                return Unauthorized("Invalid credentials.");
            var tokenString = tokenService.CreateToken(user);

            Response.Cookies.Append("jwt", tokenString, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                IsEssential= true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddMinutes(15)
            });

            return Ok(new { message = "Login successful" });
        }

        [HttpGet("userinfo")]
        [Authorize]
        public async Task<IActionResult> GetUserData()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized("User ID is missing in the token.");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found."); 
            }

            return Ok(new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.UserName,
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {        
            _signManager.SignOutAsync();
            Response.Cookies.Delete("jwt"); 

            return Ok(new { message = "Logout successful" });
        }

        [HttpGet("auth-status")]
        public ActionResult GetAuthState()
        {
            return Ok(new { IsAuthenticated = User.Identity?.IsAuthenticated ?? false });
        }
    }
}
