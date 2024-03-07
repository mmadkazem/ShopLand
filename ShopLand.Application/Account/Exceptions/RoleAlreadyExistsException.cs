namespace ShopLand.Application.Account.Exceptions;

class RoleAlreadyExistsException : ShopLandBadRequestBaseExceptions
{
    public RoleAlreadyExistsException()
        : base("This role already exists Before.") {}
}