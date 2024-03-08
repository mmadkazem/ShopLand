using ShopLand.Application.RequestPays.Commands.CreateRequestPay.Request;
using ShopLand.Application.RequestPays.Services;
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
    private readonly IPayOffService _payOffService;

    public CreateRequestPayCommandHandler(IUnitOfWork uow,
        IRequestPayFactory requestPayFactory,
        IPayOffService payOffService)
    {
        _uow = uow;
        _requestPayFactory = requestPayFactory;
        _payOffService = payOffService;
    }

    public async Task HandelAsync(CreateRequestPayCommandRequest request)
    {
        var requestPay = _requestPayFactory.Create(request.UserId, request.Amount);

        _uow.RequestPays.Add(requestPay);

        var (authority, amount) = _payOffService.PayOff();

        requestPay.PayOff(authority, amount);
        await _uow.SaveAsync();
    }
}