namespace ShopLand.Application.RequestPays.Commands.CreateRequestPay.Handler;

public class CreateRequestPayCommandHandler : ICreateRequestPayCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IRequestPayFactory _requestPayFactory;
    public CreateRequestPayCommandHandler(IUnitOfWork uow,
        IRequestPayFactory requestPayFactory)
    {
        _uow = uow;
        _requestPayFactory = requestPayFactory;
    }

    public async Task HandelAsync(CreateRequestPayCommandRequest request)
    {
        var isExist = await _uow.Users.Any(request.UserId);
        if (!isExist)
        {
            throw new UserNotFoundException();
        }
        
        var requestPay = _requestPayFactory
            .Create(request.UserId, request.Amount);

        _uow.RequestPays.Add(requestPay);
        await _uow.SaveAsync();
    }
}