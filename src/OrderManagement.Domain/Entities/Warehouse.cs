namespace OrderManagement.Domain.Entities;

public sealed class Warehouse
{
    private Warehouse() { }

    public Warehouse(string name, string address)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public ICollection<Inventory> Inventory { get; private set; } = new List<Inventory>();
}
