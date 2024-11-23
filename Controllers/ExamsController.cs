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

namespace Back_End_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        

        public ExamsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/Exams/Get
        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamDTO>>> GetAsync()
        {
            var _exams = await _context.Exams.ToListAsync();
            if(_exams == null)
            {
                return NotFound();
            }
            else
            {
                List<ExamDTO> listDTO= new List<ExamDTO>();
                foreach(var exam in _exams)
                {
                    var _subject = await _context.Subjects.FindAsync(exam.SubjectID);
                    var _professor = await _context.Users.FindAsync(exam.ProfessorID);
                    var _assistant = await _context.Users.FindAsync(exam.AssistantID);
                    if (_professor == null || _subject == null || _assistant == null)
                    {
                        return NotFound();
                    }
                    listDTO.Add(new ExamDTO()
                    {
                        ExamID = (int)exam.ExamID,
                        Group = exam.Group,
                        SubjectName=_subject.SubjectName,
                        ProfessorName = _professor.LastName + " " + _professor.FirstName,
                        AssistantName = _assistant.LastName + " " + _assistant.FirstName,
                        Date = exam.Date.Day + "." + exam.Date.Month + "." + exam.Date.Year,
                        Location=exam.Location,
                        Start_Time = exam.Start_Time

                    });
                }
                return listDTO;
            }
        }

        // GET: api/Exams/Get/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ExamDTO>> GetAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);

            if (exam == null)
            {
                return NotFound();
            }
            var _subject = await _context.Subjects.FindAsync(exam.SubjectID);
            var _professor = await _context.Users.FindAsync(exam.ProfessorID);
            var _assistant = await _context.Users.FindAsync(exam.AssistantID);

            if(_professor == null || _subject == null || _assistant == null)
            {
                return NotFound();
            }

            ExamDTO _examDTO = new ExamDTO()
            {
                ExamID = (int)exam.ExamID,
                Group = exam.Group,
                SubjectName = _subject.SubjectName,
                ProfessorName = _professor.LastName + " " + _professor.FirstName,
                AssistantName = _assistant.LastName + " " + _assistant.FirstName,
                Date = exam.Date.Day + "." + exam.Date.Month + "." + exam.Date.Year,
                Location = exam.Location,
                Start_Time = exam.Start_Time

            };
            return _examDTO;
        }

        // GET: api/Exams/GetByGroup/5
        [HttpGet("GetByUserID{userID}")]
        public async Task<ActionResult<IEnumerable<ExamDTO>>> GetByUserIDAsync(int userID)
        {
            List<Exam> filteredExams = new List<Exam>();
            var StudentGroup = await _context.StudentGroups.FindAsync(userID);
            if (StudentGroup == null)
            {
                //return NotFound();
            }
            else
            {
                await _context.Exams.ForEachAsync(e => { if (e.Group == StudentGroup.Group) { filteredExams.Add(e); } });

            }
            await _context.Exams.ForEachAsync(e => { if (e.ProfessorID == userID || e.AssistantID == userID) { filteredExams.Add(e); } });

            if (filteredExams.Count == 0)
            {
                return NotFound();
            }

            List<ExamDTO> listDTO = new List<ExamDTO>();

            foreach (var exam in filteredExams)
            {
                var _subject = await _context.Subjects.FindAsync(exam.SubjectID);
                var _professor = await _context.Users.FindAsync(exam.ProfessorID);
                var _assistant = await _context.Users.FindAsync(exam.AssistantID);
                if (_professor == null || _subject == null || _assistant == null)
                {
                    return NotFound();
                }
                listDTO.Add(new ExamDTO()
                {
                    ExamID = (int)exam.ExamID,
                    Group = exam.Group,
                    SubjectName = _subject.SubjectName,
                    ProfessorName = _professor.LastName + " " + _professor.FirstName,
                    AssistantName = _assistant.LastName + " " + _assistant.FirstName,
                    Date = exam.Date.Day + "." + exam.Date.Month + "." + exam.Date.Year,
                    Location = exam.Location,
                    Start_Time = exam.Start_Time

                });
            }


            return listDTO;
        }
 
       
        // PUT: api/Exams/Put/5
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> PutAsync(int id, Exam exam)
        {
            if (id != exam.ExamID)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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

        // POST: api/Exams/Post
        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<Exam>> PostAync(ExamPostDTO exam)
        {
            Exam newExam = new Exam()
            {
                ExamID=null,
                Group=exam.Group,
                SubjectID=exam.SubjectID,
                ProfessorID=exam.ProfessorID,
                AssistantID=exam.AssistantID,
                Date=exam.Date,
                Start_Time=exam.Start_Time,
                Location=exam.Location
            };
            _context.Exams.Add(newExam);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Created exam.",

            });
        }
        // POST: api/Exams/PostWithRequestID
        [HttpPost]
        [Route("PostWithRequestID")]
        public async Task<ActionResult<Exam>> PostAync(int RequestID,int AssistantID,String Start_Time,String Location)
        {
            var request = await _context.Requests.FindAsync(RequestID);
            if (request == null)
            {
                return NotFound();
            }

            Exam newExam = new Exam()
            {
                ExamID = null,
                Group = request.Group,
                SubjectID = request.SubjectID,
                ProfessorID = request.ProfessorID,
                AssistantID = AssistantID,
                Date = request.Date,
                Start_Time =Start_Time ,
                Location = Location
            };
            _context.Exams.Add(newExam);
            await _context.SaveChangesAsync();

            request.Status = "Accepted";


            // Modify request
            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(RequestID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new
            {
                message = "Created exam.",

            });
        }

        // DELETE: api/Exams/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamExists(int id)
        {
            return _context.Exams.Any(e => e.ExamID == id);
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestID == id);
        }
    }
}
