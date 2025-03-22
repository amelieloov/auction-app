using GrupparbeteAuktion.Core.Interfaces;
using GrupparbeteAuktion.Domain.DTOs;
using GrupparbeteAuktion.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GrupparbeteAuktion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCurrentUser()
        {
            var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            return Ok(new { userID = userID, username = username });
        }

        [HttpPost("login")]
        public IActionResult Login(UserDTO userDto)
        {
            try
            {
                var token = _userService.AuthenticateUser(userDto);

                //// Set JWT token in HttpOnly cookie
                //Response.Cookies.Append("AuthToken", token, new CookieOptions
                //{
                //    HttpOnly = true,        // Ensures the cookie is only accessible by the server
                //    Secure = true,          // Ensures the cookie is only sent over HTTPS (for production)
                //    SameSite = SameSiteMode.Lax,  // Restricts cross-site cookie sharing
                //    Expires = DateTime.UtcNow.AddDays(1)  // Set the cookie expiration time (1 day in this case)
                //});

                //return Ok(new { message = "Login successful" });
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { ex.Message });
            }
        }

        [HttpPost("add")]
        public IActionResult AddUser(UserDTO userDto)
        {
            try
            {
                _userService.RegisterUser(userDto);
                return Ok(new { message = "User created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateUser(UserDTO userDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            try
            {
                _userService.UpdateUser(userId, userDto);
                return Ok(new { message = "User updated successfully" });
            }
            catch (Exception ex)
            {
                return NotFound(new { ex.Message });
            }
        }
    }
}
