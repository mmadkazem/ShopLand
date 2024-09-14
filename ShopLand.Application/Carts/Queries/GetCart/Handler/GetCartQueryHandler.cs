namespace ShopLand.Application.Carts.Queries.GetCart.Handler;

public sealed class GetCartQueryHandler(IUnitOfWork uow)
    : IGetCartQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> HandelAsync(GetCartQueryRequest request, CancellationToken token = default)
        => await _uow.Carts.Get(request.userId, token)
            ?? throw new CartNotFoundException();
}