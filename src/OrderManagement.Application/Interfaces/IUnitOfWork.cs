using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces;

/// <summary>Координирует несколько репозиториев и общую фиксацию изменений.</summary>
public interface IUnitOfWork
{
    IRepository<Product> Products { get; }
    IRepository<Customer> Customers { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
