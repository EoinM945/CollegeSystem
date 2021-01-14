using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CollegeSystem.Models;

namespace CollegeSystem.API
{
    public class StudentsController : ApiController
    {
        private CollegeContext db = new CollegeContext();

        // GET: api/Students
        public IQueryable<StudentDTO> GetStudents()
        {
            var students = from s in db.Students
                           select new StudentDTO()
                           {
                               StudentID = s.StudentID,
                               Name = s.Name,
                               Surname = s.Surname,
                               PPS = s.PPS,
                               Phone = s.Phone,
                               Email = s.Email,
                               City = s.City,
                               Courses = s.Courses.Select(c => new CourseDTO()
                               {
                                   CourseId = c.CourseId,
                                   Name = c.Name,
                                   Year = c.Year
                               }

                               ).ToList(),
                               Modules = s.Modules.Select(m => new ModuleDTO()
                               {
                                   ModuleId = m.ModuleId,
                                   Name = m.Name,
                                   Duration = m.Duration,
                                   Lecturers = (List<LecturerDTO>)m.Lecturers,
                                   Courses = (List<CourseDTO>)m.Courses
                               }

                               ).ToList()
                           };
            return students;
        }

        // GET: api/Students/5
        [ResponseType(typeof(StudentDTO))]
        public async Task<IHttpActionResult> GetStudent(int id)
        {
            Student s = await db.Students.FindAsync(id);
            if (s == null)
            {
                return NotFound();
            }

            StudentDTO student = new StudentDTO
            {
                StudentID = s.StudentID,
                Name = s.Name,
                Surname = s.Surname,
                PPS = s.PPS,
                Phone = s.Phone,
                Email = s.Email,
                City = s.City,
                Courses = s.Courses.Select(c => new CourseDTO()
                {
                    CourseId = c.CourseId,
                    Name = c.Name,
                    Year = c.Year
                }

                               ).ToList(),
                Modules = s.Modules.Select(m => new ModuleDTO()
                {
                    ModuleId = m.ModuleId,
                    Name = m.Name,
                    Duration = m.Duration,
                    Lecturers = (List<LecturerDTO>)m.Lecturers,
                    Courses = (List<CourseDTO>)m.Courses
                }

                               ).ToList()
            };



            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentID)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = student.StudentID }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            await db.SaveChangesAsync();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.StudentID == id) > 0;
        }
    }
}