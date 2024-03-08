namespace ShopLand.Domain.Orders.Exceptions;

public class OrderStateAlreadyExistException : ShopLandBadRequestBaseExceptions
{
    public OrderStateAlreadyExistException()
        : base("This Order state already exists Before."){}
}