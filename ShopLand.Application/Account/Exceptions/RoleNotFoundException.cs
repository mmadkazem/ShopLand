namespace ShopLand.Application.Account.Exceptions;

public class RoleNotFoundException : ShopLandNotFoundBaseExceptions
{
    public RoleNotFoundException()
        : base("No role found with this information") {}

}