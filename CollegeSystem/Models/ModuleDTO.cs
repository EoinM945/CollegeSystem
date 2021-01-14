using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeSystem.Models
{
    public class ModuleDTO
    {
        public int ModuleId { get; set; }

        public string Name { get; set; }

        public string Duration { get; set; }

        public List<LecturerDTO> Lecturers { get; set; }


        public List<CourseDTO> Courses { get; set; }



    }
}