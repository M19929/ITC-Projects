namespace OnlineCourseManagement.Models;

public class Course
{
    public int Id { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public Category Category { get; private set; }

    public Course(
        int id,
        string title,
        string description,
        decimal price,
        Category category)
    {
        if (id <= 0)
            throw new ArgumentException("Course ID must be greater than zero.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Course title is required.");

        if (price < 0)
            throw new ArgumentException("Course price cannot be negative.");

        Id = id;
        Title = title.Trim();
        Description = description?.Trim() ?? "";
        Price = price;
        Category = category ?? throw new ArgumentException("A category is required.");
    }
}
