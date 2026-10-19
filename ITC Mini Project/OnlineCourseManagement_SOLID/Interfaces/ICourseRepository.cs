using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Interfaces;

public interface ICourseRepository
{
    void Add(Course course);
    List<Course> GetAll();
}
