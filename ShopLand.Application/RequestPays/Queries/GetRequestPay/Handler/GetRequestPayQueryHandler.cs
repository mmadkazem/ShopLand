namespace ShopLand.Application.RequestPays.Queries.GetRequestPay.Handler;

public class GetRequestPayQueryHandler : IGetRequestPayQueryHandler
{
    private readonly IUnitOfWork _uow;

    public GetRequestPayQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<GetRequestPayQueryResponse> HandelAsync
        (GetRequestPayQueryRequest request)
    {
        var requestPay = await _uow.RequestPays
            .FindAsync(request.RequestPayId);

        if (requestPay is null)
        {
            throw new RequestPayNotFoundException();
        }

        return requestPay.AsResponse();
    }
}