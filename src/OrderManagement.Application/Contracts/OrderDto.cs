using OrderManagement.Domain.Enums;

namespace OrderManagement.Application.Contracts;

public sealed record OrderDto(
    Guid Id,
    Guid CustomerId,
    DateTime CreatedAt,
    OrderStatus Status,
    decimal TotalAmount,
    int ItemCount);
