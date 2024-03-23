namespace ShopLand.Domain.Account.Users.Exceptions;


public sealed class UserTokenNotExistException : ShopLandUnauthorizedBaseExceptions
{
    public UserTokenNotExistException()
        : base("This user not authorized. please login"){}
}