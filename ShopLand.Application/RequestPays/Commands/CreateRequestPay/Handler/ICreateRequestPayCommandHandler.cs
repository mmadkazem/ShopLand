using ShopLand.Application.RequestPays.Commands.CreateRequestPay.Request;

namespace ShopLand.Application.RequestPays.Commands.CreateRequestPay.Handler;

public interface ICreateRequestPayCommandHandler
{
    Task HandelAsync(CreateRequestPayCommandRequest request);
}
