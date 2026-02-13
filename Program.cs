using InventoryManagement.Models;
using InventoryManagement.Services;

class Program
{
    static InventoryService inventory = new();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1": AddProduct(); break;
                case "2": ViewProducts(); break;
                case "3": UpdateProduct(); break;
                case "4": DeleteProduct(); break;
                case "5": return;
            }
        }
    }

    static void AddProduct()
    {
        Console.Write("Product Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Category ID: ");
        int catId = int.Parse(Console.ReadLine()!);
        Console.Write("Supplier ID: ");
        int supId = int.Parse(Console.ReadLine()!);
        Console.Write("Quantity: ");
        int qty = int.Parse(Console.ReadLine()!);
        Console.Write("Price: ");
        decimal price = decimal.Parse(Console.ReadLine()!);

        inventory.AddProduct(new Product { Name = name, CategoryId = catId, SupplierId = supId, Quantity = qty, Price = price });
        Console.WriteLine("Product added! Press any key...");
        Console.ReadKey();
    }

    static void ViewProducts()
    {
        var products = inventory.GetProducts();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id}: {p.Name} | Cat: {p.CategoryId} | Sup: {p.SupplierId} | Qty: {p.Quantity} | Price: {p.Price}");
        }
        Console.WriteLine("Press any key...");
        Console.ReadKey();
    }

    static void UpdateProduct()
    {
        Console.Write("Enter Product ID to update: ");
        int id = int.Parse(Console.ReadLine()!);
        var product = inventory.GetProductById(id);
        if (product == null) { Console.WriteLine("Not found!"); Console.ReadKey(); return; }

        Console.Write("New Name (leave empty to keep): ");
        string name = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(name)) product.Name = name;

        Console.Write("New Quantity (leave empty to keep): ");
        string qtyStr = Console.ReadLine()!;
        if (int.TryParse(qtyStr, out int qty)) product.Quantity = qty;

        inventory.UpdateProduct(product);
        Console.WriteLine("Updated! Press any key...");
        Console.ReadKey();
    }

    static void DeleteProduct()
    {
        Console.Write("Enter Product ID to delete: ");
        int id = int.Parse(Console.ReadLine()!);
        inventory.DeleteProduct(id);
        Console.WriteLine("Deleted! Press any key...");
        Console.ReadKey();
    }
}