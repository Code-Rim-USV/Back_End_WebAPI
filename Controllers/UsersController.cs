using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_End_WebAPI.Data;
using Back_End_WebAPI.Models;
using System.Collections;
using Microsoft.AspNetCore.Authorization;

namespace Back_End_WebAPI.Controllers
{
    //TO DO Protect passwords with a DTO
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Route("Get")]

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAsync()
        {
            List<UserDTO> filteredUsers = new List<UserDTO>();
            await _context.Users.ForEachAsync(e => filteredUsers.Add(new UserDTO
            {
                UserID = (int)e.UserID,
                UserName = e.LastName + " " + e.FirstName,
                Email = e.Email

            }));
            return filteredUsers;
        }

        // GET: api/Users/Get/5
      
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<UserDTO>> GetAync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            UserDTO userDTO =new UserDTO
            {
                UserID = (int)user.UserID,
                UserName = user.LastName + " " + user.FirstName,
                Email = user.Email

            };

            return userDTO;
        }
        // GET: api/Users/GetByGroup/5
        [HttpGet("GetByGroup/{group}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetByGroupAsync(int group)
        {

            List<int> listIDs = new List<int>();
            await _context.StudentGroups.Where(e => e.Group == group).ForEachAsync(e => listIDs.Add((e.UserID != null ? (int)e.UserID : -1)));
            

            List<User> filteredUsers = new List<User>();
            await _context.Users.ForEachAsync(e => { if (listIDs.Contains(e.UserID != null ? (int)e.UserID : -1)) { filteredUsers.Add(e); } });

            if (filteredUsers.Count == 0)
            {
                return NotFound();
            }

            List<UserDTO> usersDTO = new List<UserDTO>();

            foreach(var user in filteredUsers)
            {
                usersDTO.Add(new UserDTO
                {
                    UserID = (int)user.UserID,
                    UserName = user.LastName + " " + user.FirstName,
                    Email = user.Email

                });
            }

            return usersDTO;
        }
        // GET: api/Users/GetByGroup/5
        [HttpGet("GetByRole/{role}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetByRoleAsync(string role)
        {

            List<int> listIDs = new List<int>();
            await _context.HasRoles.Where(e => e.Role.Equals(role)).ForEachAsync(e => listIDs.Add((e.UserID != null ? (int)e.UserID : -1)));


            List<User> filteredUsers = new List<User>();
            await _context.Users.ForEachAsync(e => { if (listIDs.Contains(e.UserID != null ? (int)e.UserID : -1)) { filteredUsers.Add(e); } });

            if (filteredUsers.Count == 0)
            {
                return NotFound();
            }

            List<UserDTO> usersDTO = new List<UserDTO>();

            foreach (var user in filteredUsers)
            {
                usersDTO.Add(new UserDTO
                {
                    UserID = (int)user.UserID,
                    UserName = user.LastName + " " + user.FirstName,
                    Email = user.Email

                });
            }

            return usersDTO;
        }
        // PUT: api/Users/5
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // PUT: api/Users/5
        [HttpPut("PutPassword/{id}")]
        public async Task<IActionResult> PutUser(int id, UserPutPasssordDTO user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }
            if (user.NewPassword == null || user.NewPassword.Length<5)
            {
                return BadRequest(Constants.HttpResponses.msg17);
            }
            var _user = await _context.Users.FindAsync(user.UserID);
            if (_user == null) {
                return NotFound();
            }
            if (_user.Password.CompareTo(user.OldPassword) != 0)
            {
                return BadRequest(Constants.HttpResponses.msg22);
            }
            _user.Password=user.NewPassword.Trim();
            _context.Entry(_user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
       
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<User>> PostAync(UserPostDTO user)
        {

            User newUser = new User()
            {
                UserID = null,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email=user.Email,
                Password=user.Password,
            };
           
            _context.Add(newUser);
            await _context.SaveChangesAsync();
            return  Ok(new
            {
                message = Constants.HttpResponses.msg18,
               
            });
            
        }

        // DELETE: api/Users/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
      
    }
}
