namespace ShopLand.Application.Account.Exceptions;

public class UserNotFoundException : ShopLandNotFoundBaseExceptions
{
    public UserNotFoundException()
        : base("No user found with this information") {}

}