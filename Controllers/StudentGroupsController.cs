using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_End_WebAPI.Data;
using Back_End_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace Back_End_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGroupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentGroups/GetAsync
        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentGroup>>> GetAsync()
        {
            return await _context.StudentGroups.ToListAsync();
        }

        // GET: api/StudentGroups/GetAync/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<StudentGroup>> GetAsync(int id)
        {
            var studentGroup = await _context.StudentGroups.FindAsync(id);

            if (studentGroup == null)
            {
                return NotFound();
            }

            return studentGroup;
        }

        // PUT: api/StudentGroups/GetAsync/5
   
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> PutAsync(int id, StudentGroup studentGroup)
        {
            if (id != studentGroup.UserID)
            {
                return BadRequest();
            }

            _context.Entry(studentGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentGroupExists(id))
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

        // POST: api/StudentGroups/PostAync
        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<StudentGroup>> PostAsync(StudentGroup studentGroup)
        {
            _context.StudentGroups.Add(studentGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentGroup", new { id = studentGroup.UserID }, studentGroup);
        }

        // DELETE: api/StudentGroups/DeleteAync/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var studentGroup = await _context.StudentGroups.FindAsync(id);
            if (studentGroup == null)
            {
                return NotFound();
            }

            _context.StudentGroups.Remove(studentGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentGroupExists(int id)
        {
            return _context.StudentGroups.Any(e => e.UserID == id);
        }
    }
}
