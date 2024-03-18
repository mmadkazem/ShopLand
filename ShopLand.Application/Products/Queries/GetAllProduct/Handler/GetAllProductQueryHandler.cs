namespace ShopLand.Application.Products.Queries.GetAllProduct.Handler;

public class GetAllProductQueryHandler(IUnitOfWork uow)
    : IGetAllProductQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<GetAllProductQueryResponse>> HandelAsync
        (PageNumberRequest request)
    {
        var products = await _uow.Products.GetAll(request.Page);
        if (products.Count() is 0)
        {
            throw new ProductNotFoundException();
        }

        return products.Select(p => p.AsResponses()).ToList();
    }
}