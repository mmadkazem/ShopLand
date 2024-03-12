namespace ShopLand.Domain.Carts.Exceptions;

public class CountZeroValueException : ShopLandBadRequestBaseExceptions
{
    public CountZeroValueException()
        : base("Count It should not be zero"){}
}