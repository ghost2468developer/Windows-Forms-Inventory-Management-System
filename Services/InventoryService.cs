using InventoryManagement.Models;
using InventoryManagement.Utils;

namespace InventoryManagement.Services;

public class InventoryService
{
    private readonly string _filePath = "Data/data.json";
    private List<Product> _products = new();
    private List<Category> _categories = new();
    private List<Supplier> _suppliers = new();

    public InventoryService()
    {
        var data = JsonHelper.LoadFromFile<InventoryData>(_filePath);
        if (data != null)
        {
            _products = data.Products;
            _categories = data.Categories;
            _suppliers = data.Suppliers;
        }
    }

    private void Save()
    {
        var data = new InventoryData
        {
            Products = _products,
            Categories = _categories,
            Suppliers = _suppliers
        };
        JsonHelper.SaveToFile(_filePath, data);
    }

    public void AddProduct(Product product)
    {
        product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
        _products.Add(product);
        Save();
    }

    public List<Product> GetProducts() => _products;

    public Product? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void UpdateProduct(Product updated)
    {
        var product = _products.FirstOrDefault(p => p.Id == updated.Id);
        if (product != null)
        {
            product.Name = updated.Name;
            product.CategoryId = updated.CategoryId;
            product.SupplierId = updated.SupplierId;
            product.Quantity = updated.Quantity;
            product.Price = updated.Price;
            Save();
        }
    }

    public void DeleteProduct(int id)
    {
        _products.RemoveAll(p => p.Id == id);
        Save();
    }
}

// Helper class to save all data
public class InventoryData
{
    public List<Product> Products { get; set; } = new();
    public List<Category> Categories { get; set; } = new();
    public List<Supplier> Suppliers { get; set; } = new();
}