using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeSystem.Models
{
    public class Student
    {


        public int Id { get; set; }

        public String firstName { get; set; }

        public String Surname { get; set; }

        public String PPSNumber { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        public String City { get; set; }

       

        public ICollection<Module> Modules { get; set; }


        

    }
}