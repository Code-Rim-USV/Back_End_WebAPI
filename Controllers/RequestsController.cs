using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_End_WebAPI.Data;
using Back_End_WebAPI.Models;
using System.Net.Http.Headers;

namespace Back_End_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Requests/Get
        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetAync()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requests/Get/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Request>> GetAsync(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }
        // GET: api/Requests/GetByGroup/5
        [HttpGet("GetByGroup/{group}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetByGroupAsync(int group)
        {
            List<Request> filteredRequests = new List<Request>();
            await _context.Requests.ForEachAsync(e => { if (e.Group == group) { filteredRequests.Add(e); } });

            if (filteredRequests.Count == 0)
            {
                return NotFound();
            }

            return filteredRequests;
        }
        // GET: api/Requests/GetByUser/5
        [HttpGet("GetByUserID/{userID}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetByUserIDAsync(int userID)
        {
            List<Request> filteredRequests = new List<Request>();
            await _context.Requests.ForEachAsync(e => { if (e.ProfessorID == userID) { filteredRequests.Add(e); } });

            if (filteredRequests.Count == 0)
            {
                return NotFound();
            }

            return filteredRequests;
        }
        // PUT: api/Requests/5
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> PutAsync(int id, Request request)
        {
            if (id != request.RequestID)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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
        // PUT: api/Requests/5
        [HttpPut("PutRejected/{id}")]
        public async Task<IActionResult> PutAsync(int id, RequestPutDTO req)
        {
            if (id != req.RequestID)
            {
                return BadRequest();
            }
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return BadRequest();
            }
            request.Status = "Rejected";
            request.RejectionReason= req.RejectionReason;

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Requests
        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<Request>> PostAsync(RequestPostDTO request)
        {
            Request newRequest = new Request()
            {
                RequestID = null,
                SubjectID = request.SubjectID,
                ProfessorID = request.ProfessorID,
                Group = request.Group,
                Date = request.Date,
                Status = "Pending",
                RejectionReason = null
            };
            _context.Requests.Add(newRequest);
            await _context.SaveChangesAsync();
            
            return Ok(new
            {
                StatusCode = 201,
                message = "Created request.",

            });
        }

        // DELETE: api/Requests/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestID == id);
        }
    }
}
