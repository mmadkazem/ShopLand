namespace ShopLand.Application.Products.Queries.GetProduct.Handler;

public interface IGetProductQueryHandler
{
    Task<IResponse> HandelAsync(GetProductQueryRequest request, CancellationToken token = default);
}
