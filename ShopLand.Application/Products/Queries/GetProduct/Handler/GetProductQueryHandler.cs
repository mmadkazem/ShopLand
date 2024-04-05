namespace ShopLand.Application.Products.Queries.GetProduct.Handler;


public interface IGetProductQueryHandler
{
    Task<GetProductQueryResponse> HandelAsync(GetProductQueryRequest request);
}

public class GetProductQueryHandler(IUnitOfWork uow) : IGetProductQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<GetProductQueryResponse> HandelAsync
        (GetProductQueryRequest request)
    {
        var product = await _uow.Products.FindAsync(request.ProductId);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        var response = product.AsResponse();

        foreach (var productCategory in product.ProductCategories)
        {
            var result = await _uow.Categories.FindAsync(productCategory.Category);
            response.Categories?.Add(result.CategoryName);
        }

        return response;
    }
}