namespace OrderManagement.Domain.Entities;

public sealed class Category
{
    private Category() { }

    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public ICollection<Product> Products { get; private set; } = new List<Product>();
}
