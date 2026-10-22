using System.Collections.Generic;
using OnlineCourseManagementSystem.Models;

namespace OnlineCourseManagementSystem.Interfaces
{
    public interface ILessonRepository
    {
        void Add(Lesson lesson);

        List<Lesson> GetAll();

        Lesson GetById(int id);

        List<Lesson> GetByCourseId(int courseId);

        bool Update(int id, string title, string description, int duration);

        bool Delete(int id);
    }
}