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
    public class HasRolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HasRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HasRoles/Get
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<HasRole>>> GetAsync()
        {
            return await _context.HasRoles.ToListAsync();
        }

        // GET: api/HasRoles/Get/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<HasRole>> GetAsync(int id)
        {
            var hasRole = await _context.HasRoles.FindAsync(id);

            if (hasRole == null)
            {
                return NotFound();
            }

            return hasRole;
        }


        // POST: api/HasRoles
        [Route("Post")]
        [HttpPost]
        public async Task<ActionResult<HasRole>> PostAsync(HasRole hasRole)
        {
            _context.HasRoles.Add(hasRole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HasRoleExists((int)(hasRole.UserID==null?-1: hasRole.UserID)))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHasRole", new { id = hasRole.UserID }, hasRole);
        }

        // DELETE: api/HasRoles/Delete/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteHasRole(int id,string Role)
        {
            var hasRole = await _context.HasRoles.FindAsync(id,Role);
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
