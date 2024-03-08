namespace ShopLand.Application.RequestPays.Exceptions;

public class RequestPayNotFoundException : ShopLandNotFoundBaseExceptions
{
    public RequestPayNotFoundException()
        : base("No request pay found with this information"){}
}