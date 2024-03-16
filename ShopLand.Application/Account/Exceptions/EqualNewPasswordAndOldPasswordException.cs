namespace ShopLand.Application.Account.Exceptions;


public class EqualNewPasswordAndOldPasswordException
    : ShopLandBadRequestBaseExceptions
{
    public EqualNewPasswordAndOldPasswordException()
        : base("The new password and the old password are the same") {}
}