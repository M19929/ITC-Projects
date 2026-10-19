using System;
using System.Collections.Generic;
using OnlineCourseManagementSystem.Models;
using OnlineCourseManagementSystem.Data;


namespace OnlineCourseManagementSystem.Services
{
    public class LessonService
    {
       
            private readonly LessonRepository repository;

            public LessonService(LessonRepository repository)
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

            public void UpdateLesson(
                int id,
                string title,
                string description,
                int duration)
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Lesson title is required.");
                    return;
                }

                if (duration <= 0)
                {
                    Console.WriteLine("Duration must be greater than zero.");
                    return;
                }

                bool updated = repository.Update(
                    id,
                    title,
                    description,
                    duration
                );

                Console.WriteLine(
                    updated ? "Lesson updated successfully!" : "Lesson not found."
                );
            }

            public void DeleteLesson(int id)
            {
                bool deleted = repository.Delete(id);

                Console.WriteLine(
                    deleted ? "Lesson deleted successfully!" : "Lesson not found."
                );
            }
        }
    }


