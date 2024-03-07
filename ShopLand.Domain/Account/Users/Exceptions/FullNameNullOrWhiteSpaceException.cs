namespace ShopLand.Domain.Account.Users.Exceptions;

public class FullNameNullOrWhiteSpaceException : ShopLandNotFoundBaseExceptions
{
    public FullNameNullOrWhiteSpaceException()
        : base("FullName cannot be empty or null.") {}
}