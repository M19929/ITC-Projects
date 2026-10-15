
using OnlineCourseManagement;

List<Category> categories = new List<Category>();
List<Course> courses = new List<Course>();

// Default categories
categories.Add(new Category(1, "Programming", "Programming courses"));
categories.Add(new Category(2, "Database", "Database courses"));
categories.Add(new Category(3, "Networking", "Networking courses"));

int nextCategoryId = 4;
int nextCourseId = 1;

while (true)
{
    Console.WriteLine("\n=== Courses & Categories Management ===");
    Console.WriteLine("1. Add Category");
    Console.WriteLine("2. Show Categories");
    Console.WriteLine("3. Add Course");
    Console.WriteLine("4. Show Courses");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            Console.Write("Enter category name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter category description: ");
            string description = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Category name is required.");
                break;
            }

            categories.Add(
                new Category(nextCategoryId++, name, description)
            );

            Console.WriteLine("Category added successfully!");
            break;

        case "2":
            Console.WriteLine("\n--- Categories ---");

            foreach (Category category in categories)
            {
                category.ShowInfo();
                Console.WriteLine("---------------------------");
            }
            break;

        case "3":
            Console.Write("Enter course title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Enter course description: ");
            string courseDescription = Console.ReadLine() ?? "";

            Console.Write("Enter course price: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal price)
                || price < 0)
            {
                Console.WriteLine("Invalid price.");
                break;
            }

            Console.WriteLine("\nAvailable Categories:");

            foreach (Category category in categories)
            {
                Console.WriteLine($"{category.Id}. {category.Name}");
            }

            Console.Write("Enter category ID: ");

            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("Invalid category ID.");
                break;
            }

            Category? selectedCategory =
                categories.Find(c => c.Id == categoryId);

            if (selectedCategory == null)
            {
                Console.WriteLine("Category not found.");
                break;
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Course title is required.");
                break;
            }

            Course course = new Course(
                nextCourseId++,
                title,
                courseDescription,
                price,
                selectedCategory
            );

            courses.Add(course);

            Console.WriteLine("Course added successfully!");
            break;

        case "4":
            Console.WriteLine("\n--- All Courses ---");

            if (courses.Count == 0)
            {
                Console.WriteLine("No courses available.");
            }
            else
            {
                foreach (Course c in courses)
                {
                    c.ShowInfo();
                }
            }
            break;

        case "5":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
}
