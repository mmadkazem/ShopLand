namespace ShopLand.Application.Account.Exceptions;


public class UserNotLoginException : ShopLandBadRequestBaseExceptions
{
    public UserNotLoginException()
        : base("The user could not login, the information is incorrect") {}
}