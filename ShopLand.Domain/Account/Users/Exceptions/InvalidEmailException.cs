namespace ShopLand.Domain.Account.Users.Exceptions;

public class InvalidEmailException : ShopLandBadRequestBaseExceptions
{
    public InvalidEmailException()
        : base("Your email not valid.") {}
}