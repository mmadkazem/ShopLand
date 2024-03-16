namespace ShopLand.Domain.Account.Users.Entities;

public class User : BaseEntity<UserId>, IAggregateRoot
{
    public FullName FullName { get; private set; }
    public Email Email { get; private set; }
    private Password _password;

    public readonly LinkedList<UserInRole> UsedInRoles = new();

    public User(UserId id, FullName fullName, Email email, Password password)
        : base(id)
    {
        FullName = fullName;
        Email = email;
        _password = password;
    }
    internal User(UserId id, FullName fullName, Email email, Password password,
        LinkedList<UserInRole> userInRoles) : this(id, fullName, email, password)
    {
        UsedInRoles = userInRoles;
    }

    // For Test
    public User(): base(Guid.NewGuid()){}

    public void ChangePassword(string newPassword, string confirmNewPassword)
    {
        _password = new Password(newPassword, confirmNewPassword);
    }
    public void AddRole(Guid role)
    {
        var alreadyExists = UsedInRoles.Any(r => r.Role == role);

        if (alreadyExists)
        {
            throw new UserInRoleAlreadyExistsException();
        }

        UsedInRoles.AddLast(new UserInRole(role, Id));
    }

    public void AddRole(IEnumerable<Guid> roles)
    {
        foreach (var role in roles)
        {
            AddRole(role);
        }
    }

    public void RemoveRole(Guid role)
    {
        var userRole = GetRole(role);
        if (UsedInRoles.Count == 1)
        {
            throw new UserInRoleOneRoleException();
        }
        UsedInRoles.Remove(userRole);
    }

    public UserInRole GetRole (Guid role)
    {
        var userRole = UsedInRoles.FirstOrDefault(r => r.Role == role);

        if (userRole is null)
        {
            throw new UserInRoleNotFoundException();
        }

        return userRole;
    }

    public bool UserLogin(string email, string password)
    {
        if (email == Email.Value && Hash.GetSha256Hash(password) == _password.Value)
        {
            return true;
        }
        return false;
    }
}