
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace School_77.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasOptional(a => a.Teacher)
                .WithMany()
                .HasForeignKey(a => a.TeacherID);

            modelBuilder.Entity<Teacher>()
                .HasOptional(b => b.Course)
                .WithMany()
                .HasForeignKey(b => b.CourseID);

            modelBuilder.Entity<Subject>()
                .HasMany(c => c.Teachers).WithMany(i => i.Subjects)
                .Map(t => t.MapLeftKey("SubjectID")
                    .MapRightKey("TeacherID")
                    .ToTable("SubjectTeacher"));
        }
    }
}