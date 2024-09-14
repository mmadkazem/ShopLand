namespace ShopLand.Application.Products.Queries.GetAllProduct.Handler;

public interface IGetAllProductQueryHandler
{
    Task<IEnumerable<IResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default);
}
