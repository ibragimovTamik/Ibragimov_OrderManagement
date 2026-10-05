using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<bool> ExistsByLoginAsync(string login, Guid? excludedId, CancellationToken cancellationToken);
}
