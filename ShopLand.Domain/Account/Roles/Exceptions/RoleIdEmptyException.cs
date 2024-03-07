namespace ShopLand.Domain.Account.Roles.Exceptions;

public class RoleIdEmptyException : ShopLandBadRequestBaseExceptions
{
    public RoleIdEmptyException()
        : base("Role ID cannot be empty.") {}
}