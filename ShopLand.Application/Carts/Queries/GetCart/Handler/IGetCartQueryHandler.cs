namespace ShopLand.Application.Carts.Queries.GetCart.Handler;

public interface IGetCartQueryHandler
{
    Task<GetCartQueryResponse> HandelAsync(GetCartQueryRequest request);
}
