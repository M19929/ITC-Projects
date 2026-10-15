using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Repositories;
using OnlineCourseManagement.Services;

ICategoryRepository categoryRepository = new InMemoryCategoryRepository();
ICourseRepository courseRepository = new InMemoryCourseRepository();

CategoryService categoryService = new CategoryService(categoryRepository);
CourseService courseService = new CourseService(courseRepository, categoryRepository);

// Sample categories to make the program ready to test.
categoryService.AddCategory("Programming", "Programming courses");
categoryService.AddCategory("Database", "Database courses");
categoryService.AddCategory("Networking", "Networking courses");

while (true)
{
    Console.WriteLine("\n=== Online Course Management System ===");
    Console.WriteLine("1. Add Category");
    Console.WriteLine("2. Show Categories");
    Console.WriteLine("3. Add Course");
    Console.WriteLine("4. Show Courses");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine() ?? "";

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Category name: ");
                string categoryName = Console.ReadLine() ?? "";

                Console.Write("Category description: ");
                string categoryDescription = Console.ReadLine() ?? "";

                categoryService.AddCategory(categoryName, categoryDescription);
                Console.WriteLine("Category added successfully.");
                break;

            case "2":
                List<OnlineCourseManagement.Models.Category> categories =
                    categoryService.GetAllCategories();

                Console.WriteLine("\n--- Categories ---");
                if (categories.Count == 0)
                {
                    Console.WriteLine("No categories found.");
                    break;
                }

                foreach (var category in categories)
                {
                    Console.WriteLine(
                        $"ID: {category.Id} | Name: {category.Name} | Description: {category.Description}");
                }
                break;

            case "3":
                Console.Write("Course title: ");
                string title = Console.ReadLine() ?? "";

                Console.Write("Course description: ");
                string courseDescription = Console.ReadLine() ?? "";

                Console.Write("Course price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.WriteLine("Invalid price. Please enter a number.");
                    break;
                }

                Console.WriteLine("\nAvailable categories:");
                foreach (var category in categoryService.GetAllCategories())
                {
                    Console.WriteLine($"{category.Id}. {category.Name}");
                }

                Console.Write("Category ID: ");
                if (!int.TryParse(Console.ReadLine(), out int categoryId))
                {
                    Console.WriteLine("Invalid category ID.");
                    break;
                }

                courseService.AddCourse(title, courseDescription, price, categoryId);
                Console.WriteLine("Course added successfully.");
                break;

            case "4":
                List<OnlineCourseManagement.Models.Course> courses =
                    courseService.GetAllCourses();

                Console.WriteLine("\n--- Courses ---");
                if (courses.Count == 0)
                {
                    Console.WriteLine("No courses found.");
                    break;
                }

                foreach (var course in courses)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"ID: {course.Id}");
                    Console.WriteLine($"Title: {course.Title}");
                    Console.WriteLine($"Description: {course.Description}");
                    Console.WriteLine($"Price: {course.Price:0.00} EGP");
                    Console.WriteLine($"Category: {course.Category.Name}");
                }
                break;

            case "5":
                Console.WriteLine("Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid choice. Please choose from 1 to 5.");
                break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
