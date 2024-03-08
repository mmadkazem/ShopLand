namespace ShopLand.Domain.Orders.Exceptions;

public class AddressInvalidException : ShopLandBadRequestBaseExceptions
{
    public AddressInvalidException()
        : base("This address not valid."){}
}