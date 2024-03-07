namespace ShopLand.Share.Abstract.Exceptions;

public abstract class ShopLandNotFoundBaseExceptions : Exception
{
    protected ShopLandNotFoundBaseExceptions(string message)
        : base(message) {}
}