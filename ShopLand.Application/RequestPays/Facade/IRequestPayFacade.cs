namespace ShopLand.Application.RequestPays.Facade;

public interface IRequestPayFacade
{
    ICreateRequestPayCommandHandler CreateRequestPay { get; }
    IGetRequestPayQueryHandler GetRequestPay { get; }
    IGetRequestPaysUserQueryHandler GetRequestPaysUser { get; }
}

public class RequestPayFacade : IRequestPayFacade
{
    public RequestPayFacade(ICreateRequestPayCommandHandler createRequestPay,
        IGetRequestPayQueryHandler getRequestPay,
    IGetRequestPaysUserQueryHandler getRequestPaysUser)
    {
        _createRequestPay = createRequestPay;
        _getRequestPay = getRequestPay;
        _getRequestPaysUser = getRequestPaysUser;
    }

    private readonly ICreateRequestPayCommandHandler _createRequestPay;
    public ICreateRequestPayCommandHandler CreateRequestPay
        => _createRequestPay;

    private readonly IGetRequestPayQueryHandler _getRequestPay;
    public IGetRequestPayQueryHandler GetRequestPay
        => _getRequestPay;

    private readonly IGetRequestPaysUserQueryHandler _getRequestPaysUser;
    public IGetRequestPaysUserQueryHandler GetRequestPaysUser
        => _getRequestPaysUser;
}