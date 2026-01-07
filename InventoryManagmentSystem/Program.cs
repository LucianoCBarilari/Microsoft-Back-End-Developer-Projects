using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Product
{
    public decimal Price { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}

public class Program
{
    static List<Product> ProductsDetails = new();

    public static void Main(string[] args)
    {
        List<string> MenuOptions = new List<string>
        {
            "1. Add New Product",
            "2. Update a Product",
            "3. View All Products",
            "4. Remove a Product",
            "5. Exit"
        };

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("---------------------------");
            foreach (var option in MenuOptions)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine("---------------------------");
            Console.Write("Select an option and press Enter: ");

            string userInput = Console.ReadLine();

            Console.WriteLine();

            switch (userInput)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    Console.Write("Enter the name of the product to update: ");
                    string nameToUpdate = Console.ReadLine().Trim().ToLower();
                    UpdateProduct(nameToUpdate);
                    break;
                case "3":
                    ViewAllProducts();
                    break;
                case "4":
                    Console.Write("Enter the name of the product to remove: ");
                    string nameToRemove = Console.ReadLine().Trim().ToLower();
                    RemoveProduct(nameToRemove);
                    break;
                case "5":
                    exit = true;
                    continue;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    public static bool AddProduct()
    {
        Product newProduct = new Product();

        Console.Write("Enter Name: ");
        string name = Console.ReadLine().Trim().ToLower();
        if (!Regex.IsMatch(name, @"^[a-zA-Z0-9\s]+$") || string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid product name. Only letters, numbers, and spaces are allowed.");
            return false;
        }
        newProduct.Name = name;

        Console.Write("Enter Price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
        {
            Console.WriteLine("Invalid price format. Please enter a non-negative number.");
            return false;
        }
        newProduct.Price = price;

        Console.Write("Enter Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity format. Please enter a non-negative integer.");
            return false;
        }
        newProduct.Quantity = quantity;

        ProductsDetails.Add(newProduct);
        Console.WriteLine("Product added successfully.");
        return true;
    }

    public static bool UpdateProduct(string nameOfProduct)
    {
        Product productToUpdate = ProductsDetails.FirstOrDefault(p => p.Name.Equals(nameOfProduct, StringComparison.OrdinalIgnoreCase));

        if (productToUpdate == null)
        {
            Console.WriteLine("Product not found.");
            return false;
        }

        Console.Write("Enter new name (or press Enter to keep current): ");
        string newNameInput = Console.ReadLine().Trim().ToLower();
        if (!string.IsNullOrEmpty(newNameInput))
        {
             if (Regex.IsMatch(newNameInput, @"^[a-zA-Z0-9\s]+$"))
            {
                productToUpdate.Name = newNameInput;
            }
            else
            {
                 Console.WriteLine("Invalid product name. Name not updated.");
            }
        }

        Console.Write("Enter new price: ");
        string priceInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal newPrice) && newPrice >= 0)
        {
            productToUpdate.Price = newPrice;
        }
        else if (!string.IsNullOrWhiteSpace(priceInput))
        {
            Console.WriteLine("Invalid price format. Price not updated.");
        }


        Console.Write("Enter new quantity: ");
        string quantityInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(quantityInput) && int.TryParse(quantityInput, out int newQuantity) && newQuantity >= 0)
        {
            productToUpdate.Quantity = newQuantity;
        }
        else if (!string.IsNullOrWhiteSpace(quantityInput))
        {
            Console.WriteLine("Invalid quantity format. Quantity not updated.");
        }

        Console.WriteLine("Update successful!");
        return true;
    }

    public static bool RemoveProduct(string nameOfProduct)
    {
        Product productToRemove = ProductsDetails.FirstOrDefault(p => p.Name.Equals(nameOfProduct, StringComparison.OrdinalIgnoreCase));

        if (productToRemove == null)
        {
            Console.WriteLine("Product not found.");
            return false;
        }

        ProductsDetails.Remove(productToRemove);
        Console.WriteLine("Product removed successfully.");
        return true;
    }

    public static void ViewAllProducts()
    {
        if (ProductsDetails.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Console.WriteLine("Current Inventory:");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("{0,-25} | {1,10} | {2,10}", "Name", "Price", "Stock");
        Console.WriteLine("---------------------------------------------");

        foreach (var product in ProductsDetails)
        {
            Console.WriteLine("{0,-25} | {1,10:C} | {2,10}", product.Name, product.Price, product.Quantity);
        }

        Console.WriteLine("---------------------------------------------");
    }
}