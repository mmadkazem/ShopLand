namespace ShopLand.Application.RequestPays.Commands.CreateRequestPay.Handler;

public interface ICreateRequestPayCommandHandler
{
    Task HandelAsync(CreateRequestPayCommandRequest request, CancellationToken token = default);
}
