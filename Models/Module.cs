using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeSystem.Models
{
    
    public class Module
    {
        
        public int Id { get; set; }

        public String Name { get; set; }

        public int Duration { get; set; }

        public ICollection<Lecturer> Lecturers { get; set; }

        public ICollection<Course> Courses { get; set; }



    }
}