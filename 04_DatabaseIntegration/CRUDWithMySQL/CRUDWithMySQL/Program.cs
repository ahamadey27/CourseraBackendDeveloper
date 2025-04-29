using CRUDWithMySQL.Models;
using System;
using System.Linq;

//Implementing CRUD Operations
class Program
{
    static void Main(string[] args)
    {
        using var context = new ApplicationDbContext();

        //Create
        var newProduct = new Product { Name = "Laptop", Price = 1500.99m };
        context.Products.Add(newProduct);
        context.SaveChanges();

        //Read
        var allProducts = context.Products.ToList();
        Console.WriteLine("All Prodcuts");
        allProducts.ForEach(p => Console.WriteLine($"{p.Id}: {p.Name} - {p.Price}"));

        var singleProduct = context.Products.Find(1);
        Console.WriteLine($"Product Found: {singleProduct.Name} - ${singleProduct.Price}");

        //Update
        singleProduct.Price = 1100.99m;
        context.SaveChanges();

        //Delete
        context.Products.Remove(singleProduct);
        context.SaveChanges();



    }
}