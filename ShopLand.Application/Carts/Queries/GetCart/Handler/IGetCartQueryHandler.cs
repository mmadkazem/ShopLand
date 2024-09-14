namespace ShopLand.Application.Carts.Queries.GetCart.Handler;

public interface IGetCartQueryHandler
{
    Task<IResponse> HandelAsync(GetCartQueryRequest request, CancellationToken token = default);
}
