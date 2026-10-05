using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories;

public sealed class UnitOfWork(OrderManagementDbContext dbContext) : IUnitOfWork
{
    public IRepository<Product> Products { get; } = new GenericRepository<Product>(dbContext);
    public IRepository<Customer> Customers { get; } = new GenericRepository<Customer>(dbContext);
    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
