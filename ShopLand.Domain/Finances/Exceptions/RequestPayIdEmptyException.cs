namespace ShopLand.Domain.Finances.Exceptions;

public class RequestPayIdEmptyException : ShopLandBadRequestBaseExceptions
{
    public RequestPayIdEmptyException()
        : base("Request Pay ID cannot be empty."){}
}