namespace ShopLand.Application.Account.Exceptions;

public class RoleAlreadyExistsException : ShopLandBadRequestBaseExceptions
{
    public RoleAlreadyExistsException()
        : base("This role already exists Before.") {}
}