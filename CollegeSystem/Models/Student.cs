using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeSystem.Models
{
    public class Student
    {

        private ICollection<Course> _courses;
        private ICollection<Module> _modules;

        public Student()
        {
            _courses = new List<Course>();
            _modules = new List<Module>();
        }

        public int StudentID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PPS { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        public virtual ICollection<Module> Modules
        {
            get { return _modules; }
            set { _modules = value; }
        }






    }
}