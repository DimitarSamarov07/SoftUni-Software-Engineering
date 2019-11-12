namespace P01_StudentSystem
{
    using System;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    class StartUp
    {
        public static void Main(string[] args)
        {
            StudentSystemContext db = new StudentSystemContext();
            Seed(db);
            Console.WriteLine("DONE!!");
        }

        public static void Seed(StudentSystemContext context)
        {
            var students = new[]
            {
                new Student
                {
                    Birthday = DateTime.Today,
                    Name = "Pesho",
                    PhoneNumber = "0887002231",
                    RegisteredOn = new DateTime(2016, 1, 2)
                },

                new Student
                {
                    Name = "Ivan",
                    RegisteredOn = DateTime.Now
                },

                new Student
                {
                    Name = "Gosho",
                    PhoneNumber = "0887112232",
                    RegisteredOn = new DateTime(2015,04,23)
                },

                new Student
                {
                    Birthday = new DateTime(2014,12,01),
                    Name = "Stoyan",
                    RegisteredOn = new DateTime(2019,01,01)
                },

                new Student()
                {
                    Name = "Dimitar",
                    Birthday = new DateTime(2007,04,24),
                    RegisteredOn = DateTime.Now,
                    PhoneNumber = "0882334401"
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new[]
            {
                new Course
                {
                    Description = "Blah blah",
                    StartDate = DateTime.Today,
                    EndDate = new DateTime(2020,03,03),
                    Name = "Web Development With C#",
                    Price = 480.99M,
                },

                new Course
                {
                    Name = "Turning on the Computer",
                    Description = "If you are stupid enough pay the price and join our team of idiots today!!",
                    StartDate = new DateTime(2020,03,04),
                    EndDate = new DateTime(2020,04,03),
                    Price = 350.49M
                },

                new Course
                {
                    Name = "Self-Suicide with JS",
                    Description = "Want to learn JS. Join us today. *Don't cry if you die*",
                    StartDate = DateTime.Today,
                    EndDate = new DateTime(2020,03,07),
                    Price = 777.77M
                }
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();


            var studentCourses = new[]
            {
                new StudentCourse
                {
                    StudentId = 1,
                    CourseId = 3,
                },

                new StudentCourse
                {
                    StudentId = 2,
                    CourseId = 1,
                },

                new StudentCourse
                {
                    StudentId = 3,
                    CourseId = 2,
                }
            };

            context.StudentCourses.AddRange(studentCourses);
            context.SaveChanges();


            var homeworks = new[]
            {
                new Homework
                {
                    Content = "softuni.bg/homework/2133313",
                    ContentType = ContentType.Zip,
                    SubmissionTime = DateTime.Now,
                    CourseId = 1,
                    StudentId = 2
                },

                new Homework
                {
                    Content = "softuni.bg/resources/downloads/23213144",
                    ContentType = ContentType.Pdf,
                    SubmissionTime = new DateTime(2013, 2, 2, 1, 23, 45),
                    CourseId = 2,
                    StudentId = 3
                },

                new Homework
                {
                    Content = "softuni/resources/testers/2321313",
                    ContentType = ContentType.Application,
                    SubmissionTime = new DateTime(2019, 2, 4, 13, 22, 56),
                    CourseId = 3,
                    StudentId = 1
                },
            };

            context.HomeworkSubmissions.AddRange(homeworks);
            context.SaveChanges();


            var resources = new[]
            {
                new Resource
                {
                    CourseId = 1,
                    Name = "Introduction",
                    ResourceType = ResourceType.Video,
                    Url = "softuni.bg/resources/2124213"
                },

                new Resource
                {
                    CourseId = 2,
                    Name = "Finding the computer",
                    ResourceType = ResourceType.Document,
                    Url = "softuni.bg/resources/12341241"
                },

                new Resource
                {
                    CourseId = 3,
                    Name = "The 'Basics' of JS",
                    ResourceType = ResourceType.Presentation,
                    Url = "softuni.bg/resources/123421421"
                },
            };
            
            context.Resources.AddRange(resources);
            context.SaveChanges();
        }
    }
}
