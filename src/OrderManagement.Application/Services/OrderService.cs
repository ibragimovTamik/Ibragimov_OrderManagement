using OrderManagement.Application.Contracts;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Services;

public sealed class OrderService(
    IOrderRepository orderRepository,
    IProductRepository productRepository) : IOrderService
{
    public async Task<OrderDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(id, cancellationToken);
        return order is null ? null : ToDto(order);
    }

    public async Task<OrderDto> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        if (request.Items.Count == 0)
            throw new ArgumentException("Заказ должен содержать хотя бы один товар.", nameof(request));

        var order = new Order(request.CustomerId);
        foreach (var item in request.Items)
        {
            var product = await productRepository.GetByIdAsync(item.ProductId, cancellationToken)
                ?? throw new KeyNotFoundException($"Товар {item.ProductId} не найден.");
            order.AddItem(product.Id, product.Price, item.Quantity);
        }

        order.Confirm();
        await orderRepository.AddAsync(order, cancellationToken);
        await orderRepository.SaveChangesAsync(cancellationToken);
        return ToDto(order);
    }

    private static OrderDto ToDto(Order order) => new(
        order.Id,
        order.CustomerId,
        order.CreatedAt,
        order.Status,
        order.TotalAmount,
        order.Items.Count);
}
