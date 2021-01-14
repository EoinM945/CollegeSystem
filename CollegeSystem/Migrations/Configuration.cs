namespace CollegeSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using CollegeSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CollegeSystem.Models.CollegeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CollegeSystem.Models.CollegeContext";
        }

        protected override void Seed(CollegeSystem.Models.CollegeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var students = new List<Student>
            {
                new Student {Name="John", Surname="Smith", PPS="12345678G", Phone="0871234562", Email="JohnSmith@gmail.com", City="Dublin"},
                new Student {Name="Mary", Surname="Doyle", PPS="5643647H", Phone="0894587132", Email="MaryDoyle@gmail.com", City="Louth"},
                new Student {Name="Shane", Surname="Murphy", PPS="8902685Y", Phone="0876712900", Email="ShaneMurphy@hotmail.com", City="Cork"},
                new Student {Name="Alice", Surname="Dunne", PPS="6839850H", Phone="0869867234", Email="AliceDunne@yahoo.com", City="Dublin"},
                new Student {Name="Peter", Surname="Nolan", PPS="1964933L", Phone="0858900792", Email="PeterNolan@gmail.com", City="Meath"},
                new Student {Name="Carly", Surname="McDonald", PPS="68001234K", Phone="0879876543", Email="CarlyMcDonald@hotmail.com", City="Kildare"},
                new Student {Name="Niall", Surname="Jones", PPS="99445834N", Phone="0839120459", Email="NiallJones@gmail.com", City="Wicklow"}
            };
            students.ForEach(s => context.Students.AddOrUpdate(Student => Student.Name, s));
            context.SaveChanges();

            var modules = new List<Module>
            {
                new Module {Name="Object Oriented Programming", Duration="5 Months"},
                new Module {Name="Web Development", Duration="7 Months"},
                new Module {Name="Software Engineering", Duration="6 Months"},
                new Module {Name="Maths", Duration="5 Months"},
                new Module {Name="Business Analysis", Duration="5 Months"},
                new Module {Name="Databases", Duration="6 Months"}

            };
            modules.ForEach(m => context.Modules.AddOrUpdate(Module => Module.Name, m));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {Name="Computing", Year=1},
                new Course {Name="Business", Year=2},
                new Course {Name="Engineering", Year=3},
                new Course {Name="Data Science", Year=4},
                new Course {Name="Psychology", Year=1},
                new Course {Name="English", Year=3}


            };
            courses.ForEach(c => context.Courses.AddOrUpdate(Course => Course.Name, c));
            context.SaveChanges();


            var lecturers = new List<Lecturer>
            {
                new Lecturer {Name="Michael", Surname="Clarke",Department="Computing"},
                new Lecturer {Name="Sheila", Surname="Dunne",Department="Business"},
                new Lecturer {Name="Anne", Surname="Crawford",Department="Psychology"},
                new Lecturer {Name="Pat", Surname="Nolan",Department="Engineering"},
                new Lecturer {Name="James", Surname="Bryan",Department="Data Science"},
                new Lecturer {Name="Lisa", Surname="Jones",Department="English"}


            };
            lecturers.ForEach(l => context.Lecturers.AddOrUpdate(Lecturer => Lecturer.Name, l));
            context.SaveChanges();


        }
    }
}
