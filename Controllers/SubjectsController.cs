using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_End_WebAPI.Data;
using Back_End_WebAPI.Models;

namespace Back_End_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Subjects/Get
        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAync()
        {
            return await _context.Subjects.ToListAsync();
        }

        // GET: api/Subjects/GetAsync/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }
        // GET: api/Subjects/GetByUserID/5
        [HttpGet("GetByUserID/{userID}")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetByUserIDAsync(int userID)
        {
            List<Subject> filteredSubjects = new List<Subject>();
            await _context.Subjects.ForEachAsync(e => { if (e.ProfessorID == userID ) { filteredSubjects.Add(e); } });

            if (filteredSubjects.Count == 0)
            {
                return NotFound();
            }

            return filteredSubjects;
        }
        // PUT: api/Subjects/Put/5

        [HttpPut("Put/{id}")]
        public async Task<IActionResult> PutSubject(int id, Subject subject)
        {
            if (id != subject.SubjectID)
            {
                return BadRequest();
            }

            _context.Entry(subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<Subject>> PostAync(SubjectPostDTO subject)
        {
            Subject newSubject = new Subject()
            {
                SubjectID = null,
                ProfessorID = subject.ProfessorID,
                SubjectName = subject.SubjectName
            };
            _context.Subjects.Add(newSubject);
            await _context.SaveChangesAsync();

            return  Ok(new
            {
                message = "Created subject.",
               
            });
        }

        // DELETE: api/Subjects/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.SubjectID == id);
        }
    }
}
