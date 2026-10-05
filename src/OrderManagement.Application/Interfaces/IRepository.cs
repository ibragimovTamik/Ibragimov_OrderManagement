namespace OrderManagement.Application.Interfaces;

/// <summary>Базовый обобщённый репозиторий для сущностей с Guid-идентификатором.</summary>
public interface IRepository<T> where T : class
{
    T? GetById(Guid id);
    IReadOnlyCollection<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(Guid id);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
