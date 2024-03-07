namespace ShopLand.Domain.Account.Users.Exceptions;

public class UserInRoleOneRoleException : ShopLandBadRequestBaseExceptions
{
    public UserInRoleOneRoleException()
        : base("It has a role, it cannot be deleted.") {}
}