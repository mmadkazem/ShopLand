namespace ShopLand.Application.Products.Queries.GetAllProduct.Handler;

public interface IGetAllProductQueryHandler
{
    Task<IEnumerable<GetAllProductQueryResponse>> HandelAsync(PageNumberRequest request);
}

public class GetAllProductQueryHandler(IUnitOfWork uow)
    : IGetAllProductQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<GetAllProductQueryResponse>> HandelAsync
        (PageNumberRequest request)
    {
        var products = await _uow.Products.GetAll(request.Page);

        return products.Select(p => p.AsResponses()).ToList();
    }
}