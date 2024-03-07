namespace ShopLand.Domain.Account.Users.Exceptions;

public class UserInRoleAlreadyExistsException : ShopLandBadRequestBaseExceptions
{
    public UserInRoleAlreadyExistsException()
        : base("This role already exists Before.") {}
}