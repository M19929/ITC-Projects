using System;
using System.Collections.Generic;
using System.Linq;
using OnlineCourseManagementSystem.Models;

namespace OnlineCourseManagementSystem.Data
{
    public class LessonRepository
    {
        private readonly List<Lesson> lessons = new List<Lesson>();

        public void Add(Lesson lesson)
        {
            lessons.Add(lesson);
        }

        public List<Lesson> GetAll()
        {
            return lessons;
        }

        public Lesson GetById(int id)
        {
            return lessons.FirstOrDefault(lesson => lesson.Id == id);
        }

        public List<Lesson> GetByCourseId(int courseId)
        {
            return lessons
                .Where(lesson => lesson.CourseId == courseId)
                .ToList();
        }

        public bool Update(int id, string title, string description, int duration)
        {
            Lesson lesson = GetById(id);

            if (lesson == null)
            {
                return false;
            }

            lesson.Title = title;
            lesson.Description = description;
            lesson.DurationInMinutes = duration;

            return true;
        }  

        public bool Delete(int id)
        {
            Lesson lesson = GetById(id);

            if (lesson == null)
            {
                return false;
            }

            lessons.Remove(lesson);

            return true;
        }
    }
}