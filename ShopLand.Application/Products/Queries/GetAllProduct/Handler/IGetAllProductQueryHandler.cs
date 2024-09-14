namespace ShopLand.Application.Products.Queries.GetAllProduct.Handler;

public interface IGetAllProductQueryHandler
{
    Task<IEnumerable<GetAllProductQueryResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default);
}
