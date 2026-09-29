using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities;

public sealed class Payment
{
    private Payment() { }

    public Payment(Guid orderId, string method)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        Method = method;
        Status = PaymentStatus.Pending;
    }

    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Order? Order { get; private set; }
    public string Method { get; private set; } = string.Empty;
    public PaymentStatus Status { get; private set; }
}
