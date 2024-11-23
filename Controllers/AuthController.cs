using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_End_WebAPI.Data;
using Back_End_WebAPI.Models;

namespace Back_End_WebAPI.Controllers
{
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

         

            return Ok(new
            {
                message = "Login successful.",
                userId = user.UserID,
                email = user.Email,
                firstName = user.FirstName,
                lastName = user.LastName,
                roles = String.Join(",",userRole)
            });
        }
    }
}