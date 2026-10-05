using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories;

public sealed class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly OrderManagementDbContext dbContext;

    public ProductRepository(OrderManagementDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<Product>> GetByPriceRangeAsync(
        decimal minimum,
        decimal maximum,
        CancellationToken cancellationToken) =>
        await dbContext.Products
            .AsNoTracking()
            .Where(x => x.Price >= minimum && x.Price <= maximum)
            .ToArrayAsync(cancellationToken);
}
