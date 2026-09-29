using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities;

public sealed class Delivery
{
    private Delivery() { }

    public Delivery(Guid orderId, string address)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        Address = address;
        Status = DeliveryStatus.Preparing;
    }

    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Order? Order { get; private set; }
    public string Address { get; private set; } = string.Empty;
    public DeliveryStatus Status { get; private set; }
}
