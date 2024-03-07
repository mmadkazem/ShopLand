namespace ShopLand.Share.Abstract.Exceptions;

public abstract class ShopLandBadRequestBaseExceptions : Exception
{
    protected ShopLandBadRequestBaseExceptions(string message)
        : base(message) {}
}