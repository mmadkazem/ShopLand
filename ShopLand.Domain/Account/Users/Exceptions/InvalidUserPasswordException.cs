namespace ShopLand.Domain.Account.Users.Exceptions;

public class InvalidUserPasswordException : ShopLandBadRequestBaseExceptions
{
    public InvalidUserPasswordException(string message)
        : base(message)
    {
    }
}