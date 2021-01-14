using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CollegeSystem.Models
{
    public class CollegeModelContext : DbContext
    {

        public CollegeModelContext() : base("CollegeModelContext")
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }



    }
}