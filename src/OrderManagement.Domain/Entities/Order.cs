using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities;

public sealed class Order
{
    private Order() { }

    public Order(Guid customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        CreatedAt = DateTime.UtcNow;
        Status = OrderStatus.New;
        Items = new List<OrderItem>();
    }

    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Customer? Customer { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public OrderStatus Status { get; private set; }
    public decimal TotalAmount => Items.Sum(item => item.UnitPrice * item.Quantity);
    public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();
    public Payment? Payment { get; private set; }
    public Delivery? Delivery { get; private set; }
    public Guid? EmployeeId { get; private set; }
    public Employee? Employee { get; private set; }

    public void AddItem(Guid productId, decimal unitPrice, int quantity)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        Items.Add(new OrderItem(Id, productId, unitPrice, quantity));
    }

    public void Confirm() => Status = OrderStatus.Confirmed;
    public void MarkPaid() => Status = OrderStatus.Paid;
    public void Ship() => Status = OrderStatus.Shipped;
    public void Deliver() => Status = OrderStatus.Delivered;
    public void Cancel() => Status = OrderStatus.Cancelled;
}
