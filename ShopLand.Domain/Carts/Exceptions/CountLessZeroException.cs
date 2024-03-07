namespace ShopLand.Domain.Carts.Exceptions;


public class CountLessZeroException : ShopLandBadRequestBaseExceptions
{
    public CountLessZeroException()
        : base("The value is less than zero.") {}
}