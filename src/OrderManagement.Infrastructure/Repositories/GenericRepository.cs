using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories;

/// <summary>Универсальная реализация CRUD-операций через Entity Framework Core.</summary>
public class GenericRepository<T>(OrderManagementDbContext dbContext) : IRepository<T>
    where T : class
{
    protected DbSet<T> Set => dbContext.Set<T>();

    public T? GetById(Guid id) => Set.Find(id);

    public IReadOnlyCollection<T> GetAll() => Set.AsNoTracking().ToArray();

    public void Add(T entity) => Set.Add(entity);

    public void Update(T entity) => Set.Update(entity);

    public void Delete(Guid id)
    {
        var entity = GetById(id);
        if (entity is not null) Set.Remove(entity);
    }

    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        Set.FindAsync([id], cancellationToken).AsTask();

    public async Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await Set.AsNoTracking().ToArrayAsync(cancellationToken);

    public Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
        Set.AddAsync(entity, cancellationToken).AsTask();

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
