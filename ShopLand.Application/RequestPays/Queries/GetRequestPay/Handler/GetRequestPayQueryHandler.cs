namespace ShopLand.Application.RequestPays.Queries.GetRequestPay.Handler;

public sealed class GetRequestPayQueryHandler(IUnitOfWork uow)
    : IGetRequestPayQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> HandelAsync(GetRequestPayQueryRequest request, CancellationToken token = default)
        => await _uow.RequestPays.Get(request.RequestPayId, token)
            ?? throw new RequestPayNotFoundException();
}