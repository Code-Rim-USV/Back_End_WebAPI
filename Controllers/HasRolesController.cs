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
    public class HasRolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HasRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HasRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HasRole>>> GetHasRole()
        {
            return await _context.HasRoles.ToListAsync();
        }

        // GET: api/HasRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HasRole>> GetHasRole(int id)
        {
            var hasRole = await _context.HasRoles.FindAsync(id);

            if (hasRole == null)
            {
                return NotFound();
            }

            return hasRole;
        }

        // PUT: api/HasRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHasRole(int id, HasRole hasRole)
        {
            if (id != hasRole.UserID)
            {
                return BadRequest();
            }

            _context.Entry(hasRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HasRoleExists(id))
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

        // POST: api/HasRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HasRole>> PostHasRole(HasRole hasRole)
        {
            _context.HasRoles.Add(hasRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHasRole", new { id = hasRole.UserID }, hasRole);
        }

        // DELETE: api/HasRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHasRole(int id)
        {
            var hasRole = await _context.HasRoles.FindAsync(id);
            if (hasRole == null)
            {
                return NotFound();
            }

            _context.HasRoles.Remove(hasRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HasRoleExists(int id)
        {
            return _context.HasRoles.Any(e => e.UserID == id);
        }
    }
}
