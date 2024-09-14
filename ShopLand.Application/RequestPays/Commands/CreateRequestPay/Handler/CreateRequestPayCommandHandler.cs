namespace ShopLand.Application.RequestPays.Commands.CreateRequestPay.Handler;

public sealed class CreateRequestPayCommandHandler(IUnitOfWork uow, IRequestPayFactory requestPayFactory)
    : ICreateRequestPayCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IRequestPayFactory _requestPayFactory = requestPayFactory;

    public async Task HandelAsync(CreateRequestPayCommandRequest request, CancellationToken token = default)
    {
        var cart = await _uow.Carts.FindAsyncByUserId(request.UserId)
            ?? throw new CartNotFoundException();

        var requestPay = _requestPayFactory.Create(request.UserId, cart.TotalAmount());

        _uow.RequestPays.Add(requestPay);
        await _uow.SaveChangeAsync(token);
    }
}