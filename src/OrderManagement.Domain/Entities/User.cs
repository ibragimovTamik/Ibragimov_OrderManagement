namespace OrderManagement.Domain.Entities;

public sealed class User
{
    private User() { }

    public User(string login, string passHash)
    {
        Id = Guid.NewGuid();
        Login = login;
        PassHash = passHash;
    }

    public Guid Id { get; private set; }
    public string Login { get; private set; } = string.Empty;
    public string PassHash { get; private set; } = string.Empty;

    public void Update(string login, string passHash)
    {
        Login = login;
        PassHash = passHash;
    }
}
