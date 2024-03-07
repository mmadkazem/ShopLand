namespace ShopLand.Application.Account.Exceptions;

class RoleNotFoundException : ShopLandNotFoundBaseExceptions
{
    public RoleNotFoundException()
        : base("No role found with this information") {}

}