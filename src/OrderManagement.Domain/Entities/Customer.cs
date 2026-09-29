namespace OrderManagement.Domain.Entities;

public sealed class Customer
{
    private Customer() { }

    public Customer(string fullName, string email, string phone)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Email = email;
        Phone = phone;
    }

    public Guid Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public ICollection<Order> Orders { get; private set; } = new List<Order>();
}
