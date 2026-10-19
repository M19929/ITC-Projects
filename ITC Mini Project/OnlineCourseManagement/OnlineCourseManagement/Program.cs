using System;
using OnlineCourseManagementSystem.Models;
using OnlineCourseManagementSystem.Data;
using OnlineCourseManagementSystem.Services;
using OnlineCourseManagementSystem.Interfaces;

namespace OnlineCourseManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILessonRepository repository = new LessonRepository();
            LessonService service = new LessonService(repository);

            while (true)
            {
                Console.WriteLine("\n===== Online Course Management System =====");
                Console.WriteLine("1. Add Lesson");
                Console.WriteLine("2. Show All Lessons");
                Console.WriteLine("3. Search Lesson By ID");
                Console.WriteLine("4. Show Lessons By Course ID");
                Console.WriteLine("5. Update Lesson");
                Console.WriteLine("6. Delete Lesson");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddLesson(service);
                        break;

                    case "2":
                        service.ShowAllLessons();
                        break;

                    case "3":
                        int searchId = ReadNumber("Enter Lesson ID: ");
                        service.ShowLessonById(searchId);
                        break;

                    case "4":
                        int courseId = ReadNumber("Enter Course ID: ");
                        service.ShowLessonsByCourseId(courseId);
                        break;

                    case "5":
                        UpdateLesson(service);
                        break;

                    case "6":
                        int deleteId = ReadNumber("Enter Lesson ID to delete: ");
                        service.DeleteLesson(deleteId);
                        break;

                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static int ReadNumber(string message)
        {
            int number;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out number))
                    return number;

                Console.WriteLine("Please enter a valid number.");
            }
        }

        static string ReadText(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? "";
        }

        static void AddLesson(LessonService service)
        {
            Console.WriteLine("\n--- Add New Lesson ---");

            int id = ReadNumber("Enter Lesson ID: ");
            string title = ReadText("Enter Lesson Title: ");
            string description = ReadText("Enter Description: ");
            int courseId = ReadNumber("Enter Course ID: ");
            int duration = ReadNumber("Enter Duration in Minutes: ");

            Lesson lesson = new Lesson(
                id,
                title,
                description,
                courseId,
                duration
            );

            service.AddLesson(lesson);
        }

        static void UpdateLesson(LessonService service)
        {
            Console.WriteLine("\n--- Update Lesson ---");

            int id = ReadNumber("Enter Lesson ID: ");
            string title = ReadText("Enter New Title: ");
            string description = ReadText("Enter New Description: ");
            int duration = ReadNumber("Enter New Duration: ");

            service.UpdateLesson(id, title, description, duration);
        }
    }
}