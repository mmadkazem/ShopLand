using ShopLand.Application.RequestPays.Services;

namespace ShopLand.Infrastructure.Services.PayOff;

public class PayOffService : IPayOffService
{
    public (string Authority, long RefId) PayOff()
    {
        var authority = Guid.NewGuid().ToString();
        var refId = new Random().Next(1, 10_000);

        return (authority, refId);
    }
}