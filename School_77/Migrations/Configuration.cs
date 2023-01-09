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
            { new Person {ID = 1, LastName = "Шушин", FirstName = "Дмитрий", Patronymic = "Сергеевич" } };
            person.ForEach(s => context.People.AddOrUpdate(p => p.LastName, s));
            var students = new List<Student>
            {
                new Student {LastName = "Мельникова", FirstName = "Ксения", Patronymic = "Витальевна"},
                new Student {LastName = "Пименов", FirstName = "Максим", Patronymic = "Евгеньевич"},
                new Student {LastName = "Самбикина", FirstName = "Юлия", Patronymic = "Владимировна"},
                new Student {LastName = "Безуглова", FirstName = "Анастасия", Patronymic = "Александровна"},
                new Student {LastName = "Белюга", FirstName = "Татьяна", Patronymic = "Сергеевна"},
                new Student {LastName = "Седенкова", FirstName = "Анастасия", Patronymic = "Максимовна"},
                new Student {LastName = "Храмова", FirstName = "Полина", Patronymic = "Дмитриевна"},
                new Student {LastName = "Бирт", FirstName = "Елизавета", Patronymic = "Александровна"},
                new Student {LastName = "Власова", FirstName = "Мария", Patronymic = "Борисовна"},
                new Student {LastName = "Пискунова", FirstName = "Валерия", Patronymic = "Александровна"},
                new Student {LastName = "Бажаткова", FirstName = "Элина", Patronymic = "Эдуардовна"},
                new Student {LastName = "Казанцева", FirstName = "Елизавета", Patronymic = "Александровна"},
                new Student {LastName = "Бондина", FirstName = "Анастасия", Patronymic = "Борисовна"},
                new Student {LastName = "Лебедева", FirstName = "Екатерина", Patronymic = "Сергеевна"},
                new Student {LastName = "Мощева", FirstName = "Алина", Patronymic = "Георгиевна"},
                new Student {LastName = "Моругина", FirstName = "Ирина", Patronymic = "Николаевна"},
                new Student {LastName = "Носков", FirstName = "Соломон", Patronymic = "Тарасович"},
                new Student {LastName = "Романов", FirstName = "Петр", Patronymic = "Вячеславович"},
                new Student {LastName = "Андреев", FirstName = "Евдоким", Patronymic = "Кимович"},
                new Student {LastName = "Рябов", FirstName = "Тимофей", Patronymic = "Христофорович"},
                new Student {LastName = "Субботин", FirstName = "Мартин", Patronymic = "Миронович"},
                new Student {LastName = "Буров", FirstName = "Всеволод", Patronymic = "Егорович"},
                new Student {LastName = "Пахомов", FirstName = "Ермолай", Patronymic = "Дамирович"},
                new Student {LastName = "Фёдоров", FirstName = "Рубен", Patronymic = "Иринеевич"},
                new Student {LastName = "Осипов", FirstName = "Наум", Patronymic = "Даниилович"},
                new Student {LastName = "Бобров", FirstName = "Тарас", Patronymic = "Романович"},
                new Student {LastName = "Попова", FirstName = "Ясмина", Patronymic = "Фроловна"},
                new Student {LastName = "Нестерова", FirstName = "Каторина", Patronymic = "Матвеевна"},
                new Student {LastName = "Воробьёва", FirstName = "Гера", Patronymic = "Адольфовна"},
                new Student {LastName = "Владимирова", FirstName = "Святослава", Patronymic = "Геннадьевна"},
                new Student {LastName = "Королёва", FirstName = "Елизавета", Patronymic = "Эдуардовна"},
                new Student {LastName = "Коновалова", FirstName = "Крис", Patronymic = "Вадимовна"},
                new Student {LastName = "Якушева", FirstName = "Агнесса", Patronymic = "Ефимовна"},
                new Student {LastName = "Анисимова", FirstName = "Ульна", Patronymic = "Федотовна"},
                new Student {LastName = "Селиверстова", FirstName = "Инесса", Patronymic = "Тарасовна"},
                new Student {LastName = "Крылова", FirstName = "Клара", Patronymic = "Тарасовна"},
            };

            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));

            var teachers = new List<Teacher>
            {
                new Teacher {LastName = "Андрианова", FirstName = "Людмила", Patronymic = "Владимировна"},
                new Teacher {LastName = "Нестерова", FirstName = "Анастасия", Patronymic = "Евгеньевна"},
                new Teacher {LastName = "Миронова", FirstName = "Елизавета", Patronymic = "Валерьевна"},
                new Teacher {LastName = "Ануфриев", FirstName = "Денис", Patronymic = "Григорьевич"},
                new Teacher {LastName = "Белюга", FirstName = "Максим", Patronymic = "Евгеньевич"},                
                new Teacher {LastName = "Лутовинов", FirstName = "Дмитрий", Patronymic = "Владимирович"},
                new Teacher {LastName = "Горюшкин", FirstName = "Сергей", Patronymic = "Валерьевич"},            
                new Teacher {LastName = "Баранов", FirstName = "Андрей", Patronymic = "Николаевич"},                
            };

            teachers.ForEach(s => context.Teachers.AddOrUpdate(p => p.LastName, s));

            var parents = new List<Parent>
            {   new Parent {LastName = "Попова", FirstName = "Валерия", Patronymic = "Николаевна"},
                new Parent {LastName = "Вавилов", FirstName = "Артур", Patronymic = "Владимирович"},
                new Parent {LastName = "Баженов", FirstName = "Илья", Patronymic = "Андреевич"},
                new Parent {LastName = "Новикова", FirstName = "София", Patronymic = "Леонидовна"},
                new Parent {LastName = "Кузьмин", FirstName = "Дмитрий", Patronymic = "Максимович"},
                new Parent {LastName = "Вавилова", FirstName = "Элина", Patronymic = "Маратовна"},
                new Parent {LastName = "Свиридова", FirstName = "Софья", Patronymic = "Марковна"},
                new Parent {LastName = "Ковалева", FirstName = "Аделина", Patronymic = "Никитична"},
                new Parent {LastName = "Савельев", FirstName = "Андрей", Patronymic = "Дмитриевич"},
                new Parent {LastName = "Комаров", FirstName = "Владимир", Patronymic = "Никитич"},
            };

            parents.ForEach(s => context.Parents.AddOrUpdate(p => p.LastName, s));

            var subjects = new List<Subject>
            {
                new Subject { Name = "Математика", Teachers = new List<Teacher>()},
                new Subject { Name = "Химия", Teachers = new List<Teacher>()},
                new Subject { Name = "Биология", Teachers = new List<Teacher>()},
                new Subject { Name = "Русский язык", Teachers = new List<Teacher>()},
                new Subject { Name = "Физическая культура", Teachers = new List<Teacher>()},
                new Subject { Name = "ИЗО", Teachers = new List<Teacher>()},
                new Subject { Name = "ОБЖ", Teachers = new List<Teacher>()},
                new Subject { Name = "Окружающий мир", Teachers = new List<Teacher>()},
                new Subject { Name = "Литература", Teachers = new List<Teacher>()},
                new Subject { Name = "Иностранный язык", Teachers = new List<Teacher>()},
                new Subject { Name = "Труд", Teachers = new List<Teacher>()},
                new Subject { Name = "Музыка", Teachers = new List<Teacher>()},
            };

            subjects.ForEach(s => context.Subjects.AddOrUpdate(p => p.Name, s));

            var courses = new List<Course>
            {
                new Course {Title = "3А", Branch = "ХимБио", Students = new List<Student>()},
                new Course {Title = "2В", Branch = "СоцГум", Students = new List<Student>()},
                new Course {Title = "1А", Branch = "ХимБио", Students = new List<Student>()},
                new Course {Title = "1Б", Branch = "ФизМат", Students = new List<Student>()},
            };           

            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));

            DateTime monday_1 = new DateTime(2022, 9, 5);
            DateTime tuesday_1 = new DateTime(2022, 9, 6);
            DateTime wednesday_1 = new DateTime(2022, 9, 7);
            DateTime thursday_1 = new DateTime(2022, 9, 8);
            DateTime friday_1 = new DateTime(2022, 9, 9);

            var schedules = new List<Schedule>
            {
            new Schedule {ID = 1, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = monday_1, Order = 1, 
            SubjectID = subjects.Single(i => i.Name == "Математика").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 2, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = monday_1, Order = 2,
            SubjectID = subjects.Single(i => i.Name == "Русский язык").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 3, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = monday_1, Order = 3,
            SubjectID = subjects.Single(i => i.Name == "Окружающий мир").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 4, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = monday_1, Order = 4,
            SubjectID = subjects.Single(i => i.Name == "Музыка").ID, TeacherID = teachers.Single(s => s.LastName == "Белюга").ID },
            new Schedule {ID = 5, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = monday_1, Order = 5, 
            SubjectID = subjects.Single(i => i.Name == "Биология").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },

            new Schedule {ID = 6, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = tuesday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "Математика").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 7, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = tuesday_1, Order = 2,
            SubjectID = subjects.Single(i => i.Name == "Труд").ID, TeacherID = teachers.Single(s => s.LastName == "Баранов").ID },
            new Schedule {ID = 8, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = tuesday_1, Order = 3,
            SubjectID = subjects.Single(i => i.Name == "Русский язык").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 9, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = tuesday_1, Order = 4,
            SubjectID = subjects.Single(i => i.Name == "Литература").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 10, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = tuesday_1, Order = 5,
            SubjectID = subjects.Single(i => i.Name == "Музыка").ID, TeacherID = teachers.Single(s => s.LastName == "Белюга").ID },

            new Schedule {ID = 11, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = wednesday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "Литература").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 12, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = wednesday_1, Order = 2,
            SubjectID = subjects.Single(i => i.Name == "Окружающий мир").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 13, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = wednesday_1, Order = 3,
            SubjectID = subjects.Single(i => i.Name == "Физическая культура").ID, TeacherID = teachers.Single(s => s.LastName == "Горюшкин").ID },
            new Schedule {ID = 14, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = wednesday_1, Order = 4,
            SubjectID = subjects.Single(i => i.Name == "Русский язык").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 15, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = wednesday_1, Order = 5,
            SubjectID = subjects.Single(i => i.Name == "Математика").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },

            new Schedule {ID = 16, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = thursday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "Математика").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 17, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = thursday_1, Order = 2,
            SubjectID = subjects.Single(i => i.Name == "Русский язык").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 18, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = thursday_1, Order = 3,
            SubjectID = subjects.Single(i => i.Name == "ИЗО").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 19, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = thursday_1, Order = 4,
            SubjectID = subjects.Single(i => i.Name == "Литература").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 20, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = thursday_1, Order = 5,
            SubjectID = subjects.Single(i => i.Name == "Физическая культура").ID, TeacherID = teachers.Single(s => s.LastName == "Горюшкин").ID },

            new Schedule {ID = 21, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = friday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "Математика").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 22, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = friday_1, Order = 2,
            SubjectID = subjects.Single(i => i.Name == "Русский язык").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },
            new Schedule {ID = 23, CourseID = courses.Single(i => i.Title == "2В").ID, DateDay = friday_1, Order = 3,
            SubjectID = subjects.Single(i => i.Name == "Литература").ID, TeacherID = teachers.Single(s => s.LastName == "Андрианова").ID },

            new Schedule {ID = 24, CourseID = courses.Single(i => i.Title == "1А").ID, DateDay = monday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "Математика").ID, TeacherID = teachers.Single(s => s.LastName == "Ануфриев").ID },
            new Schedule {ID = 25, CourseID = courses.Single(i => i.Title == "1А").ID, DateDay = tuesday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "ИЗО").ID, TeacherID = teachers.Single(s => s.LastName == "Ануфриев").ID },
            new Schedule {ID = 26, CourseID = courses.Single(i => i.Title == "1А").ID, DateDay = wednesday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "Литература").ID, TeacherID = teachers.Single(s => s.LastName == "Ануфриев").ID },
            new Schedule {ID = 27, CourseID = courses.Single(i => i.Title == "1А").ID, DateDay = thursday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "Русский язык").ID, TeacherID = teachers.Single(s => s.LastName == "Ануфриев").ID },
            new Schedule {ID = 28, CourseID = courses.Single(i => i.Title == "1А").ID, DateDay = friday_1, Order = 1,
            SubjectID = subjects.Single(i => i.Name == "Труд").ID, TeacherID = teachers.Single(s => s.LastName == "Баранов").ID },
            };
            schedules.ForEach(s => context.Schedules.AddOrUpdate(p => p.ID, s));

            AddOrUpdateStudent(context, "1А", "Власова");
            AddOrUpdateStudent(context, "1А", "Пискунова");
            AddOrUpdateStudent(context, "1А", "Бажаткова");
            AddOrUpdateStudent(context, "1А", "Носков");
            AddOrUpdateStudent(context, "1А", "Романов");
            AddOrUpdateStudent(context, "1А", "Андреев");
            AddOrUpdateStudent(context, "1А", "Рябов");
            AddOrUpdateStudent(context, "1А", "Субботин");
            AddOrUpdateStudent(context, "1А", "Буров");
            AddOrUpdateStudent(context, "1А", "Пахомов");
            AddOrUpdateStudent(context, "1А", "Фёдоров");
            AddOrUpdateStudent(context, "1А", "Осипов");
            AddOrUpdateStudent(context, "1А", "Бобров");
            AddOrUpdateStudent(context, "1А", "Попова");
            AddOrUpdateStudent(context, "1А", "Нестерова");
            AddOrUpdateStudent(context, "1А", "Воробьёва");
            AddOrUpdateStudent(context, "1А", "Владимирова");
            AddOrUpdateStudent(context, "1А", "Королёва");
            AddOrUpdateStudent(context, "1А", "Коновалова");
            AddOrUpdateStudent(context, "1А", "Якушева");
            AddOrUpdateStudent(context, "1А", "Анисимова");
            AddOrUpdateStudent(context, "1А", "Селиверстова");
            AddOrUpdateStudent(context, "1А", "Крылова");
            AddOrUpdateStudent(context, "1Б", "Казанцева");
            AddOrUpdateStudent(context, "1Б", "Бондина");
            AddOrUpdateStudent(context, "1Б", "Лебедева");
            AddOrUpdateStudent(context, "1Б", "Мощева");
            AddOrUpdateStudent(context, "1Б", "Моругина");
            AddOrUpdateStudent(context, "2В", "Пименов");
            AddOrUpdateStudent(context, "2В", "Самбикина");
            AddOrUpdateStudent(context, "2В", "Безуглова");
            AddOrUpdateStudent(context, "2В", "Белюга");
            AddOrUpdateStudent(context, "3А", "Мельникова");
            AddOrUpdateStudent(context, "3А", "Седенкова");
            AddOrUpdateStudent(context, "3А", "Храмова");
            AddOrUpdateStudent(context, "3А", "Бирт");

            AddKid(context, "Попова", "Власова");
            AddKid(context, "Попова", "Пискунова");
            AddKid(context, "Попова", "Безуглова");
            AddKid(context, "Баженов", "Буров");
            AddKid(context, "Баженов", "Самбикина");
            AddKid(context, "Кузьмин", "Нестерова");
            AddKid(context, "Комаров", "Пименов");

            AppointTeacher(context, "Нестерова", "3А");
            AppointTeacher(context, "Андрианова", "2В");
            AppointTeacher(context, "Ануфриев", "1А");
            AppointTeacher(context, "Миронова", "1Б");

            AddOrUpdateTeacher(context, "Труд", "Баранов");
            AddOrUpdateTeacher(context, "ОБЖ", "Баранов");
            AddOrUpdateTeacher(context, "Физическая культура", "Горюшкин");
            AddOrUpdateTeacher(context, "ИЗО", "Лутовинов");
            AddOrUpdateTeacher(context, "Музыка", "Белюга");

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