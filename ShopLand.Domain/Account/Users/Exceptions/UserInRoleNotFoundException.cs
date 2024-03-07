namespace ShopLand.Domain.Account.Users.Exceptions;

public class UserInRoleNotFoundException : ShopLandNotFoundBaseExceptions
{
    public UserInRoleNotFoundException()
        : base("This Role not found.") {}
}