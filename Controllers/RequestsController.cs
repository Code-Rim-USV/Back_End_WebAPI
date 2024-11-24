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
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetAync()
        {
            var _requests = await _context.Requests.ToListAsync();
            if(_requests == null)
            {
                return NotFound();
            }
            else
            {
                List<RequestDTO> listDTO = new List<RequestDTO>();
                foreach(var request in _requests)
                {
                    var _subject = await _context.Subjects.FindAsync(request.SubjectID);
                    var _professor = await _context.Users.FindAsync(request.ProfessorID);
                    if (_professor == null || _subject == null)
                    {
                        return NotFound();
                    }
                    listDTO.Add(
                        new RequestDTO()
                        {
                            RequestID = (int)request.RequestID,
                            SubjectName = _subject.SubjectName,
                            ProfessorName = _professor.LastName + " " + _professor.FirstName,
                            Group = request.Group,
                            Date = request.Date.Day + "." + request.Date.Month + "." + request.Date.Year,
                            Status = request.Status,
                            RejectionReason = request.RejectionReason

                        });
                }
                return listDTO;
            }
        }

        // GET: api/Requests/Get/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<RequestDTO>> GetAsync(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            var _subject = await _context.Subjects.FindAsync(request.SubjectID);
            var _professor = await _context.Users.FindAsync(request.ProfessorID);
            if(_professor == null || _subject == null)
            {
                return NotFound();
            }
            RequestDTO _requestDTO = new RequestDTO()
            {
                RequestID = (int)request.RequestID,
                SubjectName = _subject.SubjectName,
                ProfessorName = _professor.LastName + " " + _professor.FirstName,
                Group = request.Group,
                Date = request.Date.Day + "." + request.Date.Month + "." + request.Date.Year,
                Status = request.Status,
                RejectionReason = request.RejectionReason

            };

            return _requestDTO;
        }
     
        // GET: api/Requests/GetByUser/5
        [HttpGet("GetByUserID/{userID}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetByUserIDAsync(int userID)
        {

            List<Request> filteredRequests = new List<Request>();

            var StudentGroup = await _context.StudentGroups.FindAsync(userID);

            if(StudentGroup != null)
            {
                await _context.Requests.ForEachAsync(e => { if (e.Group == StudentGroup.Group) { filteredRequests.Add(e); } });
            }
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
