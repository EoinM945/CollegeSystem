using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeSystem.Models
{
    public class Module
    {
        private ICollection<Lecturer> _lecturers;
        private ICollection<Course> _courses;

        public Module()
        {
            _lecturers = new List<Lecturer>();
            _courses = new List<Course>();
        }

        public int ModuleId { get; set; }

        public string Name { get; set; }

        public string Duration { get; set; }

        public virtual ICollection<Lecturer> Lecturers
        {
            get { return _lecturers; }
            set { _lecturers = value; }
        }


        public virtual ICollection<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }






    }
}