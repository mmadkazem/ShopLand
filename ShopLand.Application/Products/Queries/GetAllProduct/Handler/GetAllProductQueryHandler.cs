namespace ShopLand.Application.Products.Queries.GetAllProduct.Handler;

public class GetAllProductQueryHandler(IUnitOfWork uow)
    : IGetAllProductQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default)
    {
        var responses = await _uow.Products.GetAll(request.Page, token);
        if (!responses.Any())
        {
            throw new ProductNotFoundException();
        }

        return responses;
    }
}