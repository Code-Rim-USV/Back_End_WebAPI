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
using Microsoft.CodeAnalysis.CSharp.Syntax;

using Microsoft.AspNetCore.Authorization;


namespace Back_End_WebAPI.Controllers
{
    [Authorize]
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
                return new List<RequestDTO>();
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
                        continue;
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
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetByUserIDAsync(int userID)
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
                return new List<RequestDTO>(); ;
            }



            List<RequestDTO> requestsDTO = new List<RequestDTO>();
            foreach(var req in filteredRequests)
            {
                var _subject = await _context.Subjects.FindAsync(req.SubjectID);
                var _professor = await _context.Users.FindAsync(req.ProfessorID);
                if (_professor == null || _subject == null)
                {
                    continue;
                }
                requestsDTO.Add(new RequestDTO()
                {
                    RequestID = (int)req.RequestID,
                    SubjectName = _subject.SubjectName,
                    ProfessorName = _professor.LastName + " " + _professor.FirstName,
                    Group = req.Group,
                    Date = req.Date.Day + "." + req.Date.Month + "." + req.Date.Year,
                    Status = req.Status,
                    RejectionReason = req.RejectionReason

                });
            }



            return requestsDTO;
        }
        // GET: api/Requests/GetByUser/5
        [HttpGet("GetByUserID/{userID}/{status}")]
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetByUserIDAsync(int userID,string? status)
        {

            List<Request> filteredRequests = new List<Request>();

            var StudentGroup = await _context.StudentGroups.FindAsync(userID);


            if (StudentGroup != null)
            {
                if (status == null)
                {
                    await _context.Requests.ForEachAsync(e => { if (e.Group == StudentGroup.Group) { filteredRequests.Add(e); } });
                }
                else
                {
                    await _context.Requests.ForEachAsync(e => { if (e.Group == StudentGroup.Group && e.Status.CompareTo(status)==0) { filteredRequests.Add(e); } });
                }
            }
            if (status == null)
            {
                await _context.Requests.ForEachAsync(e => { if (e.ProfessorID == userID) { filteredRequests.Add(e); } });
            }
            else
            {
                await _context.Requests.ForEachAsync(e => { if (e.ProfessorID == userID && e.Status.CompareTo(status)==0) { filteredRequests.Add(e); } });
            }

            if (filteredRequests.Count == 0)
            {
                return new List<RequestDTO>(); ;
            }



            List<RequestDTO> requestsDTO = new List<RequestDTO>();
            foreach (var req in filteredRequests)
            {
                var _subject = await _context.Subjects.FindAsync(req.SubjectID);
                var _professor = await _context.Users.FindAsync(req.ProfessorID);
                if (_professor == null || _subject == null)
                {
                    continue ;
                }
                requestsDTO.Add(new RequestDTO()
                {
                    RequestID = (int)req.RequestID,
                    SubjectName = _subject.SubjectName,
                    ProfessorName = _professor.LastName + " " + _professor.FirstName,
                    Group = req.Group,
                    Date = req.Date.Day + "." + req.Date.Month + "." + req.Date.Year,
                    Status = req.Status,
                    RejectionReason = req.RejectionReason

                });
            }



            return requestsDTO;
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
            request.Status = Constants.RequestStatus.Rejected;
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
            var _user = await _context.Users.FindAsync(request.UserID);
            var _group = await _context.StudentGroups.FindAsync(request.UserID);
            var _subject = await _context.Subjects.FindAsync(request.SubjectID);

            if (_user == null || _group == null || _subject == null)
            {
                return BadRequest();
            }

            Request newRequest = new Request()
            {
                RequestID = null,
                SubjectID = request.SubjectID,
                ProfessorID = _subject.ProfessorID,
                Group = _group.Group,
                Date = request.Date,
                Status = Constants.RequestStatus.Pending,
                RejectionReason = null
            };

            List<Request> requestList = await _context.Requests.ToListAsync();

            foreach (var item in requestList)
            {
                if (item.Group == newRequest.Group && item.SubjectID == newRequest.SubjectID && item.Status.Equals(Constants.RequestStatus.Rejected) == false)
                {
                    if (item.Status.Equals(Constants.RequestStatus.Accepted))
                    {
                        return BadRequest(Constants.HttpResponses.msg10);
                    }
                    else
                    {
                        return BadRequest(Constants.HttpResponses.msg19);
                    }
                    
                }
            }
            // All the exams, now there is a need to check they dont overlap on the same date
            List<Exam> examList = await _context.Exams.ToListAsync();

            foreach (var item in examList)
            {
                if(item.Group==newRequest.Group && item.SubjectID == newRequest.SubjectID)
                {
                    return BadRequest(Constants.HttpResponses.msg10);
                }
                if (item.Group == newRequest.Group)
                {
                    int days_diff = item.Date.DayNumber - newRequest.Date.DayNumber;
                    if (days_diff == 0 || days_diff == 1 || days_diff == -1)
                    {
                        return BadRequest(Constants.HttpResponses.msg8);
                    }

                }

            }
          




            _context.Requests.Add(newRequest);
            await _context.SaveChangesAsync();
            
            return Ok(new
            {
                StatusCode = 201,
                message = Constants.HttpResponses.msg11

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
