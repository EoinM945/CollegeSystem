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
    public class LecturersController : ApiController
    {
        private CollegeContext db = new CollegeContext();

        // GET: api/Lecturers
        public IQueryable<LecturerDTO> GetLecturers()
        {
            var lecturers = from l in db.Lecturers
                            select new LecturerDTO()
                            {
                                LecturerId = l.LecturerId,
                                Name = l.Name,
                                Surname = l.Surname,
                                Department = l.Department
                            };



            return lecturers;
        }

        // GET: api/Lecturers/5
        [ResponseType(typeof(Lecturer))]
        public async Task<IHttpActionResult> GetLecturer(int id)
        {
            Lecturer l = await db.Lecturers.FindAsync(id);
            if (l == null)
            {
                return NotFound();
            }

            LecturerDTO lecturer = new LecturerDTO
            {
                LecturerId = l.LecturerId,
                Name = l.Name,
                Surname = l.Surname,
                Department = l.Department
            };

            return Ok(lecturer);
        }

        // PUT: api/Lecturers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLecturer(int id, Lecturer lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lecturer.LecturerId)
            {
                return BadRequest();
            }

            db.Entry(lecturer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturerExists(id))
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

        // POST: api/Lecturers
        [ResponseType(typeof(Lecturer))]
        public async Task<IHttpActionResult> PostLecturer(Lecturer lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lecturers.Add(lecturer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lecturer.LecturerId }, lecturer);
        }

        // DELETE: api/Lecturers/5
        [ResponseType(typeof(Lecturer))]
        public async Task<IHttpActionResult> DeleteLecturer(int id)
        {
            Lecturer lecturer = await db.Lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            db.Lecturers.Remove(lecturer);
            await db.SaveChangesAsync();

            return Ok(lecturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LecturerExists(int id)
        {
            return db.Lecturers.Count(e => e.LecturerId == id) > 0;
        }
    }
}