using System;
using OnlineCourseManagementSystem.Models;
using OnlineCourseManagementSystem.Services;
using OnlineCourseManagementSystem.Data;


namespace OnlineCourseManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LessonRepository repository = new LessonRepository();

            LessonService service = new LessonService(repository);

            Lesson lesson1 = new Lesson(
                1,
                "Introduction to C#",
                "Learn the basics of C#",
                1,
                30
            );

            Lesson lesson2 = new Lesson(
                2,
                "Variables",
                "Learn variables and data types",
                1,
                45
            );

            Lesson lesson3 = new Lesson(
                3,
                "Object Oriented Programming",
                "Learn the basics of OOP",
                2,
                60
            );

            service.AddLesson(lesson1);
            service.AddLesson(lesson2);
            service.AddLesson(lesson3);

            Console.WriteLine("\n=== ALL LESSONS ===");
            service.ShowAllLessons();

            Console.WriteLine("\n=== LESSON WITH ID 2 ===");
            service.ShowLessonById(2);

            Console.WriteLine("\n=== LESSONS FOR COURSE 1 ===");
            service.ShowLessonsByCourseId(1);

            Console.WriteLine("\n=== UPDATE LESSON ===");
            service.UpdateLesson(
                2,
                "Variables and Data Types",
                "Learn variables and different data types",
                50
            );

            Console.WriteLine("\n=== DELETE LESSON ===");
            service.DeleteLesson(3);

            Console.WriteLine("\n=== LESSONS AFTER CHANGES ===");
            service.ShowAllLessons();

            Console.ReadKey();
        }
    }
}