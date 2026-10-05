namespace OrderManagement.Application.Contracts;

public sealed record CreateUserRequest(string Login, string PassHash);

public sealed record UpdateUserRequest(string Login, string PassHash);

public sealed record UserDto(Guid Id, string Login, string PassHash);
