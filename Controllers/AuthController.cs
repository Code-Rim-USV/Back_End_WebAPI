using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_End_WebAPI.Data;
using Back_End_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Back_End_WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // {urlBase}/Auth
        
        [HttpPut]
        public async Task<IActionResult> UserLogin(UserLoginDTO userLoginDto)
        {
            

            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Email == userLoginDto.Email);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            if (user.Password != userLoginDto.Password)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }
            List<String> userRole = new List<string>();
           
            
             await _context.HasRoles
                .Where(hr => hr.UserID == user.UserID)
                .Select(hr => hr.Role)
                .ForEachAsync<string>(e => userRole.Add(e));

            if (userRole.Count==0)
            {
                return BadRequest(new { message = "User role not found." });
            }

            String _role = "";
            if (userRole.Contains("Professor"))
            {
                _role = "Professor";
            }else if (userRole.Contains("Assistant"))
            {
                _role = "Professor";
            }else if (userRole.Contains("GroupLeader"))
            {
                _role = "GroupLeader";
            }
            else if(userRole.Contains("Student"))
            {
                _role = "Student";
            }

            return Ok(new
            {
                userId = user.UserID,             
                roles = _role
            });
        }
    }
}