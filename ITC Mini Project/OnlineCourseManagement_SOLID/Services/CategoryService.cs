using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services;

public class CategoryService
{
    private readonly ICategoryRepository _repository;
    private int _nextId = 1;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;

        // Continue IDs after any existing categories.
        List<Category> existing = _repository.GetAll();
        if (existing.Count > 0)
            _nextId = existing.Max(category => category.Id) + 1;
    }

    public void AddCategory(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name is required.");

        Category category = new Category(_nextId, name, description);
        _repository.Add(category);
        _nextId++;
    }

    public List<Category> GetAllCategories()
    {
        return _repository.GetAll();
    }

    public Category? GetCategoryById(int id)
    {
        return _repository.GetById(id);
    }
}
