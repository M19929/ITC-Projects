using System;
using System.Collections.Generic;
using OnlineCourseManagementSystem.Models;
using OnlineCourseManagementSystem.Interfaces;


namespace OnlineCourseManagementSystem.Services
{
    public class LessonService
    {
        private readonly ILessonRepository repository;
        public LessonService(ILessonRepository repository)
        {
            this.repository = repository;
        }

        public bool AddLesson(Lesson lesson)
        {
            if (lesson == null)
            {
                Console.WriteLine("Lesson cannot be null.");
                return false;
            }

            if (lesson.Id <= 0)
            {
                Console.WriteLine("Lesson ID must be greater than zero.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(lesson.Title))
            {
                Console.WriteLine("Lesson title is required.");
                return false;
            }

            if (lesson.CourseId <= 0)
            {
                Console.WriteLine("Course ID must be greater than zero.");
                return false;
            }

            if (lesson.DurationInMinutes <= 0)
            {
                Console.WriteLine("Duration must be greater than zero.");
                return false;
            }

            if (repository.GetById(lesson.Id) != null)
            {
                Console.WriteLine("Lesson ID already exists.");
                return false;
            }

            repository.Add(lesson);

            Console.WriteLine("Lesson added successfully!");

            return true;
        }

        public void ShowAllLessons()
        {
            List<Lesson> lessons = repository.GetAll();

            if (lessons.Count == 0)
            {
                Console.WriteLine("No lessons found.");
                return;
            }

            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine("--------------------");
                lesson.ShowInfo();
            }
        }

        public void ShowLessonById(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Lesson ID must be greater than zero.");
                return;
            }

            Lesson lesson = repository.GetById(id);

            if (lesson == null)
            {
                Console.WriteLine("Lesson not found.");
                return;
            }

            lesson.ShowInfo();
        }

        public void ShowLessonsByCourseId(int courseId)
        {
            if (courseId <= 0)
            {
                Console.WriteLine("Course ID must be greater than zero.");
                return;
            }

            List<Lesson> lessons = repository.GetByCourseId(courseId);

            if (lessons.Count == 0)
            {
                Console.WriteLine("No lessons found for this course.");
                return;
            }

            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine("--------------------");
                lesson.ShowInfo();
            }
        }

        public bool UpdateLesson(int id, string title, string description, int duration)
        {
            if (id <= 0)
            {
                Console.WriteLine("Lesson ID must be greater than zero.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Lesson title is required.");
                return false;
            }

            if (duration <= 0)
            {
                Console.WriteLine("Duration must be greater than zero.");
                return false;
            }

            bool updated = repository.Update(id, title, description, duration);

            if (!updated)
            {
                Console.WriteLine("Lesson not found.");
                return false;
            }

            Console.WriteLine("Lesson updated successfully!");

            return true;
        }

        public bool DeleteLesson(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Lesson ID must be greater than zero.");
                return false;
            }

            bool deleted = repository.Delete(id);

            if (!deleted)
            {
                Console.WriteLine("Lesson not found.");
                return false;
            }

            Console.WriteLine("Lesson deleted successfully!");

            return true;
        }
    }
}