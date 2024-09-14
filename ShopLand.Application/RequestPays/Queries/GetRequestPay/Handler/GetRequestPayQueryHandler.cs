namespace ShopLand.Application.RequestPays.Queries.GetRequestPay.Handler;

public sealed class GetRequestPayQueryHandler(IUnitOfWork uow)
    : IGetRequestPayQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<GetRequestPayQueryResponse> HandelAsync(GetRequestPayQueryRequest request, CancellationToken token = default)
    {
        var requestPay = await _uow.RequestPays.FindAsync(request.RequestPayId, token)
            ?? throw new RequestPayNotFoundException();

        return requestPay.AsResponse();
    }
}