namespace ShopLand.Domain.Account.Users.ValueObject;

public record UserInRole
{
    public Guid Role { get; private set; }
    public UserId UserId { get; private set; }


    public UserInRole(Guid role, UserId userId)
    {
        UserId = userId;
        Role = role;
    }
}