
namespace KodaStore.Api.Models;

public sealed class Product
{
    // [Required]
    // [StringLength(30)]
    public string ProductCode { get; }
    public string Name { get; }
    public decimal Price { get; }
    public int Stock { get; }
    public string Category { get; }

    public Product(string productCode, string name, decimal price, int stock, string category)
    {
        if (string.IsNullOrWhiteSpace(productCode))
        {
            throw new ArgumentException("Product code is Required", nameof(productCode));
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product code is Required", nameof(name));
        }
        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative");
        }
        if (stock < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stock), "stock cannot be negative");
        }
        if (string.IsNullOrWhiteSpace(category))
        {
            throw new ArgumentException("Category code is Required", nameof(category));
        }
        ProductCode = productCode;
        Name = name;
        Price = price;
        Stock = stock;
        Category = category.Trim();
    }
}