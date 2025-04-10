using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repos.Models;
using Repos.Repositories;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        using var context = new MyDbContext();

        var userRepository = new UserRepository(context);

        var newUser = new User { Name = "Misa", Age = 25 };
        userRepository.Add(newUser);

        // работа с представлением
        var hobbiesOfPeople = context.Set<ProductCategoryView>()
            .FromSqlRaw("SELECT * FROM ProductCategoryView")
            .ToList();

        foreach (var record in hobbiesOfPeople)
        {
            Console.WriteLine($"{record.category_name} : {record.product_name}");
        }
    }
}