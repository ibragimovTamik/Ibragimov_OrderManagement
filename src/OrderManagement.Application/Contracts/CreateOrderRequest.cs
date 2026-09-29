namespace OrderManagement.Application.Contracts;

public sealed record CreateOrderRequest(
    Guid CustomerId,
    IReadOnlyCollection<CreateOrderItemRequest> Items,
    string PaymentMethod,
    string DeliveryAddress);

public sealed record CreateOrderItemRequest(Guid ProductId, int Quantity);
