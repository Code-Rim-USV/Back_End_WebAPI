﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_End_WebAPI.Data;
using Back_End_WebAPI.Models;
using System.Collections;
using Humanizer;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Humanizer.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Back_End_WebAPI.Controllers
{
    [Authorize]
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
                return new List<ExamDTO>();
            }
            else
            {
                List<ExamDTO> listDTO= new List<ExamDTO>();
                foreach(var exam in _exams)
                {
                    var _subject = await _context.Subjects.FindAsync(exam.SubjectID);
                    var _professor = await _context.Users.FindAsync(exam.ProfessorID);
                    var _assistant = await _context.Users.FindAsync(exam.AssistantID);
                    var _location = await _context.Locations.FindAsync(exam.LocationID);
                    if (_professor == null || _subject == null || _assistant == null || _location == null)
                    {
                        continue;
                    }
                    listDTO.Add(new ExamDTO()
                    {
                        ExamID = (int)exam.ExamID,
                        Group = exam.Group,
                        SubjectName=_subject.SubjectName,
                        ProfessorName = _professor.LastName + " " + _professor.FirstName,
                        AssistantName = _assistant.LastName + " " + _assistant.FirstName,
                        Date = exam.Date.Day + "." + exam.Date.Month + "." + exam.Date.Year,
                        Location=_location.LocationName,
                        Start_Time = exam.Start_Time,
                        Duration = exam.Duration

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
            var _location = await _context.Locations.FindAsync(exam.LocationID);
            if (_professor == null || _subject == null || _assistant == null || _location == null)
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
                Location = _location.LocationName,
                Start_Time = exam.Start_Time,
                Duration = exam.Duration

            };
            return _examDTO;
        }

        // GET: api/Exams/GetByGroup/5
        [HttpGet("GetByUserID{userID}")]
        public async Task<ActionResult<IEnumerable<ExamDTO>>> GetByUserIDAsync(int userID)
        {
            List<Exam> filteredExams = new List<Exam>();
            var StudentGroup = await _context.StudentGroups.FindAsync(userID);
            if (StudentGroup != null)
            {
                await _context.Exams.ForEachAsync(e => { if (e.Group == StudentGroup.Group) { filteredExams.Add(e); } });
            }
           
            await _context.Exams.ForEachAsync(e => { if (e.ProfessorID == userID || e.AssistantID == userID) { filteredExams.Add(e); } });

            if (filteredExams.Count == 0)
            {
                return new List<ExamDTO>();
            }

            List<ExamDTO> listDTO = new List<ExamDTO>();

            foreach (var exam in filteredExams)
            {
                var _subject = await _context.Subjects.FindAsync(exam.SubjectID);
                var _professor = await _context.Users.FindAsync(exam.ProfessorID);
                var _assistant = await _context.Users.FindAsync(exam.AssistantID);
                var _location = await _context.Locations.FindAsync(exam.LocationID);
                if (_professor == null || _subject == null || _assistant == null || _location == null)
                {
                    continue;
                }
                listDTO.Add(new ExamDTO()
                {
                    ExamID = (int)exam.ExamID,
                    Group = exam.Group,
                    SubjectName = _subject.SubjectName,
                    ProfessorName = _professor.LastName + " " + _professor.FirstName,
                    AssistantName = _assistant.LastName + " " + _assistant.FirstName,
                    Date = exam.Date.Day + "." + exam.Date.Month + "." + exam.Date.Year,
                    Location = _location.LocationName,
                    Start_Time = exam.Start_Time,
                    Duration = exam.Duration

                });
            }


            return listDTO;
        }
 
       
        // PUT: api/Exams/PutAll/5
        [HttpPut("PutAll/{id}")]
        public async Task<IActionResult> PutAllAsync(int id, Exam exam)
        {
            if (id != exam.ExamID)
            {
                return BadRequest();
            }
            if (exam.Date <= DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest(Constants.HttpResponses.msg20);

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
        // PUT: api/Exams/Put/5
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> PutAsync(int id, ExamPutDTO exam)
        {
            if (id != exam.ExamID)
            {
                return BadRequest();
            }
            var _exam = await _context.Exams.FirstOrDefaultAsync(e => e.ExamID == exam.ExamID);
            var _assistant = await _context.Users.FirstOrDefaultAsync(e => e.UserID==exam.AssistantID);
            var _location = await _context.Locations.FirstOrDefaultAsync(e => e.LocationID==exam.LocationID);
            var _role = await _context.HasRoles.FindAsync(exam.AssistantID, Constants.UserRoles.Assistant);
            if ( _exam == null || _assistant == null || _location == null || _role == null)
            {
                return NotFound();
            }
           
            //_exam.LocationID = exam.LocationID;
            // _exam.AssistantID = exam.AssistantID;
            //  _exam.Start_Time = exam.Start_Time;
            // _exam.Duration = exam.Duration;

            Exam newExam = new Exam();
            newExam.LocationID = exam.LocationID;
            newExam.AssistantID = exam.AssistantID;
            newExam.Start_Time = exam.Start_Time;
            newExam.Duration = exam.Duration;
            newExam.Date = _exam.Date;

            if (_exam.ProfessorID == exam.AssistantID)
            {
                return BadRequest(Constants.HttpResponses.msg21);
            }

            List<Exam> examList = await _context.Exams.ToListAsync();

            int time1 = 0;
            string[] time_split = newExam.Start_Time.Split(":");
            int x = 0;
            Int32.TryParse(time_split[0], out x);
            time1 += x * 100;
            if (newExam.Start_Time.Contains("PM"))
            {
                time1 += 1200;
            }
            Int32.TryParse(time_split[1].Substring(0, 2), out x);
            time1 += x;

            if (time1 < 700 || time1 + newExam.Duration * 100 > 2100)
            {
                return BadRequest(Constants.HttpResponses.msg22);
            }


            foreach (var item in examList)
            {
                if (item.ExamID == exam.ExamID)
                {
                    continue;
                }
                if (item.LocationID == newExam.LocationID && item.Date.CompareTo(newExam.Date) == 0 && item.ExamID!=exam.ExamID)
                {
                    int time2 = 0;
                    try
                    {

                        time_split = item.Start_Time.Split(":");
                        x = 0;
                        Int32.TryParse(time_split[0], out x);
                        time2 += x * 100;
                        if (item.Start_Time.Contains("PM"))
                        {
                            time2 += 1200;
                        }
                        Int32.TryParse(time_split[1].Substring(0, 2), out x);
                        time2 += x;

                        // Not be within a said duration
                        if (Math.Abs(time1 - time2) < newExam.Duration*100)
                        {
                            return BadRequest(Constants.HttpResponses.msg1);
                        }
                    }
                    catch
                    {
                        return BadRequest(Constants.HttpResponses.msg2);
                    }


                }
                if (item.ProfessorID == _exam.ProfessorID)
                {
                    int time2 = 0;
                    try
                    {


                        time_split = item.Start_Time.Split(":");
                        x = 0;
                        Int32.TryParse(time_split[0], out x);
                        time2 += x * 100;
                        if (item.Start_Time.Contains("PM"))
                        {
                            time2 += 1200;
                        }
                        Int32.TryParse(time_split[1].Substring(0, 2), out x);
                        time2 += x;

                        // Not be within 3 hours of eachother
                        if (Math.Abs(time1 - time2) < newExam.Duration * 100)
                        {
                            return BadRequest(Constants.HttpResponses.msg3);
                        }
                    }
                    catch
                    {
                        return BadRequest(Constants.HttpResponses.msg2);
                    }

                }
                if (item.AssistantID == _exam.AssistantID)
                {
                    int time2 = 0;
                    try
                    {
                        time_split = item.Start_Time.Split(":");
                        x = 0;
                        Int32.TryParse(time_split[0], out x);
                        time2 += x * 100;
                        Int32.TryParse(time_split[1].Substring(0, 2), out x);
                        time2 += x;
                        if (item.Start_Time.Contains("PM"))
                        {
                            time2 += 1200;
                        }
                        // Not be within 3 hours of eachother
                        if (Math.Abs(time1 - time2) < newExam.Duration * 100)
                        {
                            return BadRequest(Constants.HttpResponses.msg4);
                        }
                    }
                    catch
                    {
                        return BadRequest(Constants.HttpResponses.msg2);
                    }

                }
            }

            _exam.LocationID = exam.LocationID;
            _exam.AssistantID = exam.AssistantID;
            _exam.Start_Time = exam.Start_Time;
            _exam.Duration = exam.Duration;

            // Saves changes
            _context.Entry(_exam).State = EntityState.Modified;

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
            if (exam.ProfessorID == exam.AssistantID)
            {
                return BadRequest(Constants.HttpResponses.msg21);
            }
            int time1 = 0;
            string[] time_split = exam.Start_Time.Split(":");
            int x = 0;
            Int32.TryParse(time_split[0], out x);
            time1 += x * 100;
            if (exam.Start_Time.Contains("PM"))
            {
                time1 += 1200;
            }
            Int32.TryParse(time_split[1].Substring(0, 2), out x);
            time1 += x;

            if (time1 < 700 || time1 + exam.Duration * 100 > 2100)
            {
                return BadRequest(Constants.HttpResponses.msg22);
            }
            Exam newExam = new Exam()
            {
                ExamID=null,
                Group=exam.Group,
                SubjectID=exam.SubjectID,
                ProfessorID=exam.ProfessorID,
                AssistantID=exam.AssistantID,
                Date=exam.Date,
                Start_Time=exam.Start_Time,
                LocationID=exam.LocationID,
                Duration=exam.Duration
            };
            _context.Exams.Add(newExam);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = Constants.HttpResponses.msg5

            });
        }
        // POST: api/Exams/PostWithRequestID
        [HttpPost]
        [Route("PostWithRequestID")]
        public async Task<ActionResult<Exam>> PostWithRequestIDAync(ExamPostWithRequestDTO exam)
        {
            var request = await _context.Requests.FindAsync(exam.RequestID);
            var assitant = await _context.Users.FindAsync(exam.AssistantID);
            var role = await _context.HasRoles.FindAsync(exam.AssistantID, Constants.UserRoles.Assistant);
            var location = await _context.Locations.FindAsync(exam.LocationID);
            if (request == null || assitant == null || role == null || location ==null) 
            {
               return NotFound();
            }
            

            if (request.Status != null && request.Status.CompareTo(Constants.RequestStatus.Pending) != 0)
            {
                return BadRequest(Constants.HttpResponses.msg6);
            }

            if (request.ProfessorID == exam.AssistantID)
            { 
                return BadRequest(Constants.HttpResponses.msg21);
            }
           

            var existingExam = await _context.Exams
                .SingleOrDefaultAsync(u => (u.Group == request.Group && u.SubjectID==request.SubjectID));

            if (existingExam != null) {
                return BadRequest(Constants.HttpResponses.msg7);
            }

            if (request.Date <= DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest(Constants.HttpResponses.msg20);

            }

            Exam newExam = new Exam()
            {
                ExamID = null,
                Group = request.Group,
                SubjectID = request.SubjectID,
                ProfessorID = request.ProfessorID,
                AssistantID = exam.AssistantID,
                Date = request.Date,
                Start_Time =exam.Start_Time ,
                LocationID = exam.LocationID,
                Duration = exam.Duration
            };

            int time1 = 0;
            string[] time_split = newExam.Start_Time.Split(":");
            int x = 0;
            Int32.TryParse(time_split[0], out x);
            time1 += x * 100;
            if (newExam.Start_Time.Contains("PM"))
            {
                time1 += 1200;
            }
            Int32.TryParse(time_split[1].Substring(0, 2), out x);
            time1 += x;

            if(time1<700 || time1 + newExam.Duration * 100 > 2100)
            {
                return BadRequest(Constants.HttpResponses.msg22);
            }


            // All the exams, now there is a need to check they dont overlap on the same date
            List<Exam> examList = await _context.Exams.ToListAsync();

            foreach (var item in examList)
            {
                if (item.Group == newExam.Group)
                {
                    int days_diff = item.Date.DayNumber - newExam.Date.DayNumber;
                    if(days_diff == 0 || days_diff == 1 || days_diff == -1)
                    {
                        return BadRequest(Constants.HttpResponses.msg8);
                    }

                }
                // Exams are considered to take around 3 hours
                // Get Exams in the same location and date
                if (item.LocationID == newExam.LocationID && item.Date.CompareTo(newExam.Date)==0)
                {
                    int time2 = 0;  
                    try
                    {
                      
                        time_split = item.Start_Time.Split(":");
                        x = 0;
                        Int32.TryParse(time_split[0], out x);
                        time2 += x * 100;
                        Int32.TryParse(time_split[1].Substring(0,2), out x);
                        time2 += x;
                        if (item.Start_Time.Contains("PM"))
                        {
                            time2 += 1200;
                        }
                        // Not be within 3 hours of eachother
                        if (Math.Abs(time1 - time2) < newExam.Duration * 100)
                        {
                            return BadRequest(Constants.HttpResponses.msg9);
                        }
                    }
                    catch
                    {
                        return BadRequest(Constants.HttpResponses.msg2);
                    }

                   
                }
                if (item.ProfessorID == newExam.ProfessorID)
                {
                    int time2 = 0;
                    try
                    {

                        time_split = item.Start_Time.Split(":");
                        x = 0;
                        Int32.TryParse(time_split[0], out x);
                        time2 += x * 100;
                        Int32.TryParse(time_split[1].Substring(0, 2), out x);
                        time2 += x;
                        if (item.Start_Time.Contains("PM"))
                        {
                            time2 += 1200;
                        }
                        // Not be within 3 hours of eachother
                        if (Math.Abs(time1 - time2) < newExam.Duration * 100)
                        {
                            return BadRequest(Constants.HttpResponses.msg3);
                        }
                    }
                    catch
                    {
                        return BadRequest(Constants.HttpResponses.msg2);
                    }

                }
                if (item.AssistantID == newExam.AssistantID)
                {
                    int time2 = 0;
                    try
                    {

                        time_split = item.Start_Time.Split(":");
                        x = 0;
                        Int32.TryParse(time_split[0], out x);
                        time2 += x * 100;
                        Int32.TryParse(time_split[1].Substring(0, 2), out x);
                        time2 += x;
                        if (item.Start_Time.Contains("PM"))
                        {
                            time2 += 1200;
                        }
                        // Not be within 3 hours of eachother
                        if (Math.Abs(time1 - time2) < newExam.Duration * 100)
                        {
                            return BadRequest(Constants.HttpResponses.msg4);
                        }
                    }
                    catch
                    {
                        return BadRequest(Constants.HttpResponses.msg2);
                    }

                }




            }



            _context.Exams.Add(newExam);
            await _context.SaveChangesAsync();

            request.Status = Constants.RequestStatus.Accepted;


            // Modify request
            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(exam.RequestID))
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
                message = Constants.HttpResponses.msg5,

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
