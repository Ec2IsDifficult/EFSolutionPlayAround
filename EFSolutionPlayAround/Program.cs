using System;
using EFSolutionPlayAround.Domain;
using Npgsql;

namespace EFSolutionPlayAround
{
    class Program
    {
        static void Main()
        {
            var database = new EfFunctions();
            var newCategory = new Category {Name = "Fanta", Description = "Orange"};
            database.CreateCategory(newCategory);
            
            foreach (var category in database.GetCategories())
            {
                Console.WriteLine(category);
            }
        }
    }
}