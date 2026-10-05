using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IReadOnlyCollection<Product>> GetByPriceRangeAsync(
        decimal minimum,
        decimal maximum,
        CancellationToken cancellationToken);
}
