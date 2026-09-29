namespace OrderManagement.Domain.Entities;

public sealed class Product
{
    private Product() { }

    public Product(string name, decimal price, Guid categoryId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        CategoryId = categoryId;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }
    public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
    public ICollection<Inventory> Inventory { get; private set; } = new List<Inventory>();
}
