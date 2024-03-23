namespace ShopLand.Share.Abstract.Exceptions;


public abstract class ShopLandUnauthorizedBaseExceptions : Exception
{
    protected ShopLandUnauthorizedBaseExceptions(string message)
    : base(message) { }
}