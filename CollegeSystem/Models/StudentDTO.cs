using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeSystem.Models
{
    public class StudentDTO
    {

        public int StudentID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PPS { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public List<CourseDTO> Courses { get; set; }

        public List<ModuleDTO> Modules { get; set; }



    }
}