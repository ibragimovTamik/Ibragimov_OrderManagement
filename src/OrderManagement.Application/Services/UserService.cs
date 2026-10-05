using OrderManagement.Application.Contracts;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Services;

public sealed class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<UserDto> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        Validate(request.Login, request.PassHash);
        if (await userRepository.ExistsByLoginAsync(request.Login, null, cancellationToken))
            throw new InvalidOperationException("Пользователь с таким логином уже существует.");

        var user = new User(request.Login.Trim(), request.PassHash.Trim());
        await userRepository.AddAsync(user, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);
        return ToDto(user);
    }

    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, cancellationToken);
        return user is null ? null : ToDto(user);
    }

    public async Task<UserDto?> UpdateAsync(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        Validate(request.Login, request.PassHash);
        var user = await userRepository.GetByIdAsync(id, cancellationToken);
        if (user is null) return null;
        if (await userRepository.ExistsByLoginAsync(request.Login, id, cancellationToken))
            throw new InvalidOperationException("Пользователь с таким логином уже существует.");

        user.Update(request.Login.Trim(), request.PassHash.Trim());
        userRepository.Update(user);
        await userRepository.SaveChangesAsync(cancellationToken);
        return ToDto(user);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, cancellationToken);
        if (user is null) return false;
        userRepository.Delete(id);
        await userRepository.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static void Validate(string login, string passHash)
    {
        if (string.IsNullOrWhiteSpace(login))
            throw new ArgumentException("Логин не может быть пустым.", nameof(login));
        if (string.IsNullOrWhiteSpace(passHash))
            throw new ArgumentException("PassHash не может быть пустым. Передавайте хеш пароля.", nameof(passHash));
    }

    private static UserDto ToDto(User user) => new(user.Id, user.Login, user.PassHash);
}
