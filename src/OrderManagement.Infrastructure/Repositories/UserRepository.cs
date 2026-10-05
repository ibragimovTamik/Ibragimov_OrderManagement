using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories;

public sealed class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly OrderManagementDbContext dbContext;

    public UserRepository(OrderManagementDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<bool> ExistsByLoginAsync(
        string login,
        Guid? excludedId,
        CancellationToken cancellationToken) =>
        dbContext.Users.AnyAsync(
            x => x.Login == login && (!excludedId.HasValue || x.Id != excludedId.Value),
            cancellationToken);
}
