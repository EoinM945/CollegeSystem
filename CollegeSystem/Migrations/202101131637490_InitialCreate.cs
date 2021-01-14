namespace CollegeSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Module_ModuleId = c.Int(),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Modules", t => t.Module_ModuleId)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .Index(t => t.Module_ModuleId)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        LecturerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Department = c.String(),
                        Module_ModuleId = c.Int(),
                    })
                .PrimaryKey(t => t.LecturerId)
                .ForeignKey("dbo.Modules", t => t.Module_ModuleId)
                .Index(t => t.Module_ModuleId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.String(),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.ModuleId)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PPS = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.Courses", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.Lecturers", "Module_ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Courses", "Module_ModuleId", "dbo.Modules");
            DropIndex("dbo.Modules", new[] { "Student_StudentID" });
            DropIndex("dbo.Lecturers", new[] { "Module_ModuleId" });
            DropIndex("dbo.Courses", new[] { "Student_StudentID" });
            DropIndex("dbo.Courses", new[] { "Module_ModuleId" });
            DropTable("dbo.Students");
            DropTable("dbo.Modules");
            DropTable("dbo.Lecturers");
            DropTable("dbo.Courses");
        }
    }
}
