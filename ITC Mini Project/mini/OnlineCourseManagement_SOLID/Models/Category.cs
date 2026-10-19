namespace OnlineCourseManagement.Models;

public class Category
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Category(int id, string name, string description)
    {
        if (id <= 0)
            throw new ArgumentException("Category ID must be greater than zero.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name is required.");

        Id = id;
        Name = name.Trim();
        Description = description?.Trim() ?? "";
    }
}
