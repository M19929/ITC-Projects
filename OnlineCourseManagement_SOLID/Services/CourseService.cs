using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services;

public class CourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ICategoryRepository _categoryRepository;
    private int _nextId = 1;

    public CourseService(
        ICourseRepository courseRepository,
        ICategoryRepository categoryRepository)
    {
        _courseRepository = courseRepository;
        _categoryRepository = categoryRepository;

        List<Course> existing = _courseRepository.GetAll();
        if (existing.Count > 0)
            _nextId = existing.Max(course => course.Id) + 1;
    }

    public void AddCourse(
        string title,
        string description,
        decimal price,
        int categoryId)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Course title is required.");

        if (price < 0)
            throw new ArgumentException("Course price cannot be negative.");

        Category? category = _categoryRepository.GetById(categoryId);
        if (category is null)
            throw new ArgumentException("Category not found. Please choose a valid category ID.");

        Course course = new Course(_nextId, title, description, price, category);
        _courseRepository.Add(course);
        _nextId++;
    }

    public List<Course> GetAllCourses()
    {
        return _courseRepository.GetAll();
    }
}
