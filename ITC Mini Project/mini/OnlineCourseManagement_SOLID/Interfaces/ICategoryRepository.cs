using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Interfaces;

public interface ICategoryRepository
{
    void Add(Category category);
    List<Category> GetAll();
    Category? GetById(int id);
}
