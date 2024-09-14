namespace ShopLand.Application.RequestPays.Commands.CreateRequestPay.Handler;

public sealed class CreateRequestPayCommandHandler(IUnitOfWork uow, IRequestPayFactory requestPayFactory)
    : ICreateRequestPayCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IRequestPayFactory _requestPayFactory = requestPayFactory;

    public async Task HandelAsync(CreateRequestPayCommandRequest request, CancellationToken token = default)
    {
        var isExist = await _uow.Users.Any(request.UserId, token);
        if (!isExist)
        {
            throw new UserNotFoundException();
        }

        var requestPay = _requestPayFactory
            .Create(request.UserId, request.Amount);

        _uow.RequestPays.Add(requestPay);
        await _uow.SaveAsync(token);
    }
}