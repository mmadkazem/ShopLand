namespace ShopLand.Domain.Account.Users.Exceptions;

public class UserIdEmptyException : ShopLandBadRequestBaseExceptions
{
    public UserIdEmptyException()
        : base("User ID cannot be empty.")
    {
    }
}