using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeSystem.Models;

namespace CollegeSystem.Controllers
{
    public class StudentsController : Controller
    {
        private CollegeModelContext db = new CollegeModelContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            //return View(student);




            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Student = db.Students.Include(s => s.Modules).First(s => s.Id == id);
            studentViewModel.AllModules = db.Modules.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.Id.ToString()
            }

            );
            studentViewModel.SelectedModules = studentViewModel.Student.Modules.Select(m => m.Id).ToList();


            return View(studentViewModel);

        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstName,Surname,PPSNumber,Phone,Email,City")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Student = db.Students.Include(s => s.Modules).First(s => s.Id == id);
            studentViewModel.AllModules = db.Modules.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.Id.ToString()
            }

            );
            studentViewModel.SelectedModules = studentViewModel.Student.Modules.Select(m => m.Id).ToList();


            return View(studentViewModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                Student student = db.Students.Include(s => s.Modules).First(s => s.Id == studentViewModel.Student.Id);
                HashSet<int> selectedModules = new HashSet<int>(studentViewModel.SelectedModules);
                foreach(Module m in db.Modules)
                {
                    if(!selectedModules.Contains(m.Id))
                    {
                        student.Modules.Remove(m);
                    }
                    else
                    {
                        student.Modules.Add(m);
                    }
                }




                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentViewModel);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
