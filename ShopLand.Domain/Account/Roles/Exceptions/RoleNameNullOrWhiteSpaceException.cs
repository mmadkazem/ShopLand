namespace ShopLand.Domain.Account.Roles.Exceptions;

public class RoleNameNullOrWhiteSpaceException : ShopLandBadRequestBaseExceptions
{
    public RoleNameNullOrWhiteSpaceException()
        : base("RoleName cannot be empty or null.") {}
}