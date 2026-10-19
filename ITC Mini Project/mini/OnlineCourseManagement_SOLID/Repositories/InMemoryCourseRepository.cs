using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Repositories;

public class InMemoryCourseRepository : ICourseRepository
{
    private readonly List<Course> _courses = new();

    public void Add(Course course)
    {
        _courses.Add(course);
    }

    public List<Course> GetAll()
    {
        return _courses.ToList();
    }
}
