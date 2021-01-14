using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeSystem.Models
{
    public class Lecturer
    {

        public Lecturer()
        {

        }

        public int LecturerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Department { get; set; }



    }
}