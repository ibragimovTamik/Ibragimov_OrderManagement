using OrderManagement.Application.Contracts;

namespace OrderManagement.Application.Interfaces;

public interface IOrderService
{
    Task<OrderDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<OrderDto> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken);
}
