
namespace OnlineCourseManagement;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }

    public Course(
        int id,
        string title,
        string description,
        decimal price,
        Category category)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Category = category;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Course ID: {Id}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Price: {Price} EGP");
        Console.WriteLine($"Category: {Category.Name}");
        Console.WriteLine("---------------------------");
    }
}
