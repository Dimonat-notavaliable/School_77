namespace School_77.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(),
                        Title = c.String(nullable: false, maxLength: 3),
                        Branch = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Person", t => t.TeacherID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        Patronymic = c.String(maxLength: 20),
                        CourseID = c.Int(),
                        CourseID1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Parent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .ForeignKey("dbo.Course", t => t.CourseID1)
                .ForeignKey("dbo.Person", t => t.Parent_ID)
                .Index(t => t.CourseID)
                .Index(t => t.CourseID1)
                .Index(t => t.Parent_ID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Course_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.Course_ID)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                        DateDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.SubjectID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubjectID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Person", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.SubjectTeacher",
                c => new
                    {
                        SubjectID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectID, t.TeacherID })
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "Parent_ID", "dbo.Person");
            DropForeignKey("dbo.Grade", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Grade", "StudentID", "dbo.Person");
            DropForeignKey("dbo.Course", "TeacherID", "dbo.Person");
            DropForeignKey("dbo.Subject", "Course_ID", "dbo.Course");
            DropForeignKey("dbo.SubjectTeacher", "TeacherID", "dbo.Person");
            DropForeignKey("dbo.SubjectTeacher", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Schedule", "TeacherID", "dbo.Person");
            DropForeignKey("dbo.Person", "CourseID1", "dbo.Course");
            DropForeignKey("dbo.Schedule", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Schedule", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Person", "CourseID", "dbo.Course");
            DropIndex("dbo.SubjectTeacher", new[] { "TeacherID" });
            DropIndex("dbo.SubjectTeacher", new[] { "SubjectID" });
            DropIndex("dbo.Grade", new[] { "StudentID" });
            DropIndex("dbo.Grade", new[] { "SubjectID" });
            DropIndex("dbo.Schedule", new[] { "TeacherID" });
            DropIndex("dbo.Schedule", new[] { "SubjectID" });
            DropIndex("dbo.Schedule", new[] { "CourseID" });
            DropIndex("dbo.Subject", new[] { "Course_ID" });
            DropIndex("dbo.Person", new[] { "Parent_ID" });
            DropIndex("dbo.Person", new[] { "CourseID1" });
            DropIndex("dbo.Person", new[] { "CourseID" });
            DropIndex("dbo.Course", new[] { "TeacherID" });
            DropTable("dbo.SubjectTeacher");
            DropTable("dbo.Grade");
            DropTable("dbo.Schedule");
            DropTable("dbo.Subject");
            DropTable("dbo.Person");
            DropTable("dbo.Course");
        }
    }
}
