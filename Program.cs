using Database_first.Models;

namespace Database_first;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        using (var context = new MyDbContext())
        {
            var categories = context.Categories
                                    .Where(c => c.Id > 5)
                                    .ToList();

            var c = new Category() { Name = "TEST_PV421" };
            context.Categories.Add(c);
            context.SaveChanges();

            foreach (var category in categories)
            {
                Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
            }
        }
        Console.WriteLine("END OF PROGRAM!");
    }
}