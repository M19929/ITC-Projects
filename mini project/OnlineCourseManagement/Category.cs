
namespace OnlineCourseManagement;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Category(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Category ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
    }
}
