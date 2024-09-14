namespace ShopLand.Application.Products.Queries.GetProduct.Handler;


public interface IGetProductQueryHandler
{
    Task<GetProductQueryResponse> HandelAsync(GetProductQueryRequest request, CancellationToken token = default);
}

public class GetProductQueryHandler(IUnitOfWork uow) : IGetProductQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<GetProductQueryResponse> HandelAsync(GetProductQueryRequest request, CancellationToken token = default)
    {
        var product = await _uow.Products.FindAsync(request.ProductId, token)
            ?? throw new ProductNotFoundException();

        var response = product.AsResponse();

        foreach (var productCategory in product.ProductCategories)
        {
            var result = await _uow.Categories.FindAsync(productCategory.Category, token);
            response.Categories?.Add(result.CategoryName);
        }
        return response;
    }
}