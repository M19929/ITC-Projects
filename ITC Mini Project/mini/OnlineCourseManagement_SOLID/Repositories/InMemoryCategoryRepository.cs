using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Repositories;

public class InMemoryCategoryRepository : ICategoryRepository
{
    private readonly List<Category> _categories = new();

    public void Add(Category category)
    {
        _categories.Add(category);
    }

    public List<Category> GetAll()
    {
        return _categories.ToList();
    }

    public Category? GetById(int id)
    {
        return _categories.FirstOrDefault(category => category.Id == id);
    }
}
