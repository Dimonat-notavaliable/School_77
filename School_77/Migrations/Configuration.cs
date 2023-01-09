namespace School_77.Migrations
{
    using School_77.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {
            var person = new List<Person>
            { new Person {ID = 1, LastName = "�����", FirstName = "�������", Patronymic = "���������" } };
            person.ForEach(s => context.People.AddOrUpdate(p => p.LastName, s));
            var students = new List<Student>
            {
                new Student {LastName = "����������", FirstName = "������", Patronymic = "����������"},
                new Student {LastName = "�������", FirstName = "������", Patronymic = "����������"},
                new Student {LastName = "���������", FirstName = "����", Patronymic = "������������"},
                new Student {LastName = "���������", FirstName = "���������", Patronymic = "�������������"},
                new Student {LastName = "������", FirstName = "�������", Patronymic = "���������"},
                new Student {LastName = "���������", FirstName = "���������", Patronymic = "����������"},
                new Student {LastName = "�������", FirstName = "������", Patronymic = "����������"},
                new Student {LastName = "����", FirstName = "���������", Patronymic = "�������������"},
                new Student {LastName = "�������", FirstName = "�����", Patronymic = "���������"},
                new Student {LastName = "���������", FirstName = "�������", Patronymic = "�������������"},
                new Student {LastName = "���������", FirstName = "�����", Patronymic = "����������"},
                new Student {LastName = "���������", FirstName = "���������", Patronymic = "�������������"},
                new Student {LastName = "�������", FirstName = "���������", Patronymic = "���������"},
                new Student {LastName = "��������", FirstName = "���������", Patronymic = "���������"},
                new Student {LastName = "������", FirstName = "�����", Patronymic = "����������"},
                new Student {LastName = "��������", FirstName = "�����", Patronymic = "����������"},
                new Student {LastName = "������", FirstName = "�������", Patronymic = "���������"},
                new Student {LastName = "�������", FirstName = "����", Patronymic = "������������"},
                new Student {LastName = "�������", FirstName = "�������", Patronymic = "�������"},
                new Student {LastName = "�����", FirstName = "�������", Patronymic = "�������������"},
                new Student {LastName = "��������", FirstName = "������", Patronymic = "���������"},
                new Student {LastName = "�����", FirstName = "��������", Patronymic = "��������"},
                new Student {LastName = "�������", FirstName = "�������", Patronymic = "���������"},
                new Student {LastName = "Ը�����", FirstName = "�����", Patronymic = "���������"},
                new Student {LastName = "������", FirstName = "����", Patronymic = "����������"},
                new Student {LastName = "������", FirstName = "�����", Patronymic = "���������"},
                new Student {LastName = "������", FirstName = "������", Patronymic = "��������"},
                new Student {LastName = "���������", FirstName = "��������", Patronymic = "���������"},
                new Student {LastName = "���������", FirstName = "����", Patronymic = "����������"},
                new Student {LastName = "�����������", FirstName = "����������", Patronymic = "�����������"},
                new Student {LastName = "�������", FirstName = "���������", Patronymic = "����������"},
                new Student {LastName = "����������", FirstName = "����", Patronymic = "���������"},
                new Student {LastName = "�������", FirstName = "�������", Patronymic = "��������"},
                new Student {LastName = "���������", FirstName = "�����", Patronymic = "���������"},
                new Student {LastName = "������������", FirstName = "������", Patronymic = "���������"},
                new Student {LastName = "�������", FirstName = "�����", Patronymic = "���������"},
            };

            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));

            var teachers = new List<Teacher>
            {
                new Teacher {LastName = "����������", FirstName = "�������", Patronymic = "������������"},
                new Teacher {LastName = "���������", FirstName = "���������", Patronymic = "����������"},
                new Teacher {LastName = "��������", FirstName = "���������", Patronymic = "����������"},
                new Teacher {LastName = "��������", FirstName = "�����", Patronymic = "�����������"},
                new Teacher {LastName = "������", FirstName = "������", Patronymic = "����������"},                
                new Teacher {LastName = "���������", FirstName = "�������", Patronymic = "������������"},
                new Teacher {LastName = "��������", FirstName = "������", Patronymic = "����������"},            
                new Teacher {LastName = "�������", FirstName = "������", Patronymic = "����������"},                
            };

            teachers.ForEach(s => context.Teachers.AddOrUpdate(p => p.LastName, s));

            var parents = new List<Parent>
            {   new Parent {LastName = "������", FirstName = "�������", Patronymic = "����������"},
                new Parent {LastName = "�������", FirstName = "�����", Patronymic = "������������"},
                new Parent {LastName = "�������", FirstName = "����", Patronymic = "���������"},
                new Parent {LastName = "��������", FirstName = "�����", Patronymic = "����������"},
                new Parent {LastName = "�������", FirstName = "�������", Patronymic = "����������"},
                new Parent {LastName = "��������", FirstName = "�����", Patronymic = "���������"},
                new Parent {LastName = "���������", FirstName = "�����", Patronymic = "��������"},
                new Parent {LastName = "��������", FirstName = "�������", Patronymic = "���������"},
                new Parent {LastName = "��������", FirstName = "������", Patronymic = "����������"},
                new Parent {LastName = "�������", FirstName = "��������", Patronymic = "�������"},
            };

            parents.ForEach(s => context.Parents.AddOrUpdate(p => p.LastName, s));

            var subjects = new List<Subject>
            {
                new Subject { Name = "����������", Teachers = new List<Teacher>()},
                new Subject { Name = "�����", Teachers = new List<Teacher>()},
                new Subject { Name = "��������", Teachers = new List<Teacher>()},
                new Subject { Name = "������� ����", Teachers = new List<Teacher>()},
                new Subject { Name = "���������� ��������", Teachers = new List<Teacher>()},
                new Subject { Name = "���", Teachers = new List<Teacher>()},
                new Subject { Name = "���", Teachers = new List<Teacher>()},
                new Subject { Name = "���������� ���", Teachers = new List<Teacher>()},
                new Subject { Name = "����������", Teachers = new List<Teacher>()},
                new Subject { Name = "����������� ����", Teachers = new List<Teacher>()},
                new Subject { Name = "����", Teachers = new List<Teacher>()},
                new Subject { Name = "������", Teachers = new List<Teacher>()},
            };

            subjects.ForEach(s => context.Subjects.AddOrUpdate(p => p.Name, s));

            var courses = new List<Course>
            {
                new Course {Title = "3�", Branch = "������", Students = new List<Student>()},
                new Course {Title = "2�", Branch = "������", Students = new List<Student>()},
                new Course {Title = "1�", Branch = "������", Students = new List<Student>()},
                new Course {Title = "1�", Branch = "������", Students = new List<Student>()},
            };           

            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));

            DateTime monday_1 = new DateTime(2022, 9, 5);
            DateTime tuesday_1 = new DateTime(2022, 9, 6);
            DateTime wednesday_1 = new DateTime(2022, 9, 7);
            DateTime thursday_1 = new DateTime(2022, 9, 8);
            DateTime friday_1 = new DateTime(2022, 9, 9);

            var schedules = new List<Schedule>
            {
            new Schedule {ID = 1, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = monday_1, Order = 1, 
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 2, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = monday_1, Order = 2,
            SubjectID = subjects.Single(i => i.Name == "������� ����").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 3, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = monday_1, Order = 3,
            SubjectID = subjects.Single(i => i.Name == "���������� ���").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 4, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = monday_1, Order = 4,
            SubjectID = subjects.Single(i => i.Name == "������").ID, TeacherID = teachers.Single(s => s.LastName == "������").ID },
            new Schedule {ID = 5, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = monday_1, Order = 5, 
            SubjectID = subjects.Single(i => i.Name == "��������").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },

            new Schedule {ID = 6, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = tuesday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 7, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = tuesday_1, Order = 2,
            SubjectID = subjects.Single(i => i.Name == "����").ID, TeacherID = teachers.Single(s => s.LastName == "�������").ID },
            new Schedule {ID = 8, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = tuesday_1, Order = 3,
            SubjectID = subjects.Single(i => i.Name == "������� ����").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 9, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = tuesday_1, Order = 4,
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 10, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = tuesday_1, Order = 5,
            SubjectID = subjects.Single(i => i.Name == "������").ID, TeacherID = teachers.Single(s => s.LastName == "������").ID },

            new Schedule {ID = 11, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = wednesday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 12, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = wednesday_1, Order = 2,
            SubjectID = subjects.Single(i => i.Name == "���������� ���").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 13, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = wednesday_1, Order = 3,
            SubjectID = subjects.Single(i => i.Name == "���������� ��������").ID, TeacherID = teachers.Single(s => s.LastName == "��������").ID },
            new Schedule {ID = 14, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = wednesday_1, Order = 4,
            SubjectID = subjects.Single(i => i.Name == "������� ����").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 15, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = wednesday_1, Order = 5,
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },

            new Schedule {ID = 16, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = thursday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 17, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = thursday_1, Order = 2,
            SubjectID = subjects.Single(i => i.Name == "������� ����").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 18, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = thursday_1, Order = 3,
            SubjectID = subjects.Single(i => i.Name == "���").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 19, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = thursday_1, Order = 4,
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 20, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = thursday_1, Order = 5,
            SubjectID = subjects.Single(i => i.Name == "���������� ��������").ID, TeacherID = teachers.Single(s => s.LastName == "��������").ID },

            new Schedule {ID = 21, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = friday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 22, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = friday_1, Order = 2,
            SubjectID = subjects.Single(i => i.Name == "������� ����").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },
            new Schedule {ID = 23, CourseID = courses.Single(i => i.Title == "2�").ID, DateDay = friday_1, Order = 3,
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "����������").ID },

            new Schedule {ID = 24, CourseID = courses.Single(i => i.Title == "1�").ID, DateDay = monday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "��������").ID },
            new Schedule {ID = 25, CourseID = courses.Single(i => i.Title == "1�").ID, DateDay = tuesday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "���").ID, TeacherID = teachers.Single(s => s.LastName == "��������").ID },
            new Schedule {ID = 26, CourseID = courses.Single(i => i.Title == "1�").ID, DateDay = wednesday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "����������").ID, TeacherID = teachers.Single(s => s.LastName == "��������").ID },
            new Schedule {ID = 27, CourseID = courses.Single(i => i.Title == "1�").ID, DateDay = thursday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "������� ����").ID, TeacherID = teachers.Single(s => s.LastName == "��������").ID },
            new Schedule {ID = 28, CourseID = courses.Single(i => i.Title == "1�").ID, DateDay = friday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "����").ID, TeacherID = teachers.Single(s => s.LastName == "�������").ID },
            };
            schedules.ForEach(s => context.Schedules.AddOrUpdate(p => p.ID, s));

            AddOrUpdateStudent(context, "1�", "�������");
            AddOrUpdateStudent(context, "1�", "���������");
            AddOrUpdateStudent(context, "1�", "���������");
            AddOrUpdateStudent(context, "1�", "������");
            AddOrUpdateStudent(context, "1�", "�������");
            AddOrUpdateStudent(context, "1�", "�������");
            AddOrUpdateStudent(context, "1�", "�����");
            AddOrUpdateStudent(context, "1�", "��������");
            AddOrUpdateStudent(context, "1�", "�����");
            AddOrUpdateStudent(context, "1�", "�������");
            AddOrUpdateStudent(context, "1�", "Ը�����");
            AddOrUpdateStudent(context, "1�", "������");
            AddOrUpdateStudent(context, "1�", "������");
            AddOrUpdateStudent(context, "1�", "������");
            AddOrUpdateStudent(context, "1�", "���������");
            AddOrUpdateStudent(context, "1�", "���������");
            AddOrUpdateStudent(context, "1�", "�����������");
            AddOrUpdateStudent(context, "1�", "�������");
            AddOrUpdateStudent(context, "1�", "����������");
            AddOrUpdateStudent(context, "1�", "�������");
            AddOrUpdateStudent(context, "1�", "���������");
            AddOrUpdateStudent(context, "1�", "������������");
            AddOrUpdateStudent(context, "1�", "�������");
            AddOrUpdateStudent(context, "1�", "���������");
            AddOrUpdateStudent(context, "1�", "�������");
            AddOrUpdateStudent(context, "1�", "��������");
            AddOrUpdateStudent(context, "1�", "������");
            AddOrUpdateStudent(context, "1�", "��������");
            AddOrUpdateStudent(context, "2�", "�������");
            AddOrUpdateStudent(context, "2�", "���������");
            AddOrUpdateStudent(context, "2�", "���������");
            AddOrUpdateStudent(context, "2�", "������");
            AddOrUpdateStudent(context, "3�", "����������");
            AddOrUpdateStudent(context, "3�", "���������");
            AddOrUpdateStudent(context, "3�", "�������");
            AddOrUpdateStudent(context, "3�", "����");

            AddKid(context, "������", "�������");
            AddKid(context, "������", "���������");
            AddKid(context, "������", "���������");
            AddKid(context, "�������", "�����");
            AddKid(context, "�������", "���������");
            AddKid(context, "�������", "���������");
            AddKid(context, "�������", "�������");

            AppointTeacher(context, "���������", "3�");
            AppointTeacher(context, "����������", "2�");
            AppointTeacher(context, "��������", "1�");
            AppointTeacher(context, "��������", "1�");

            AddOrUpdateTeacher(context, "����", "�������");
            AddOrUpdateTeacher(context, "���", "�������");
            AddOrUpdateTeacher(context, "���������� ��������", "��������");
            AddOrUpdateTeacher(context, "���", "���������");
            AddOrUpdateTeacher(context, "������", "������");

            context.SaveChanges();
        }

        void AddOrUpdateStudent(SchoolContext context, string courseTitle, string studentName)
        {
            var crs = context.Courses.SingleOrDefault(c => c.Title == courseTitle);
            var stud = crs.Students.SingleOrDefault(s => s.LastName == studentName);
            if (stud == null)
                crs.Students.Add(context.Students.Single(s => s.LastName == studentName));
        }
        void AddKid(SchoolContext context, string parentName, string studentName)
        {
            var prnt = context.Parents.SingleOrDefault(c => c.LastName == parentName);
            prnt.Kids.Add(context.Students.Single(s => s.LastName == studentName));
        }
        void AddOrUpdateTeacher(SchoolContext context, string subjectName, string teacherName)
        {
            var crs = context.Subjects.SingleOrDefault(c => c.Name == subjectName);
            var stud = crs.Teachers.SingleOrDefault(s => s.LastName == teacherName);
            if (stud == null)
                crs.Teachers.Add(context.Teachers.Single(s => s.LastName == teacherName));
        }

        void AppointTeacher(SchoolContext context, string TeacherName, string CourseName)
        {
            var tch = context.Teachers.SingleOrDefault(c => c.LastName == TeacherName);
            var crs = context.Courses.SingleOrDefault(s => s.Title == CourseName);
            if (tch.CourseID == null && crs.TeacherID == null) {
                tch.CourseID = crs.ID;
                crs.TeacherID = tch.ID;
            }               
        }
    }
}