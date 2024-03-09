using ShopLand.Application.RequestPays.Commands.CreateRequestPay.Request;
using ShopLand.Domain.Finances.Factories;

namespace ShopLand.Application.RequestPays.Commands.CreateRequestPay.Handler;

public interface ICreateRequestPayCommandHandler
{
    Task HandelAsync(CreateRequestPayCommandRequest request);
}

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
        var requestPay = _requestPayFactory
            .Create(request.UserId, request.Amount);

        _uow.RequestPays.Add(requestPay);
        await _uow.SaveAsync();
    }
}