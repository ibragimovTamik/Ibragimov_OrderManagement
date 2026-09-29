namespace OrderManagement.Domain.Entities;

public sealed class Employee
{
    private Employee() { }

    public Employee(string fullName, string position)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Position = position;
    }

    public Guid Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string Position { get; private set; } = string.Empty;
    public ICollection<Order> Orders { get; private set; } = new List<Order>();
}
