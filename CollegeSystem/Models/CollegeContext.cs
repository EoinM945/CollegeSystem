using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CollegeSystem.Models
{
    public class CollegeContext : DbContext
    {

        public CollegeContext() : base("CollegeContext")
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }

        public DbSet<Course> Courses { get; set; }





    }
}