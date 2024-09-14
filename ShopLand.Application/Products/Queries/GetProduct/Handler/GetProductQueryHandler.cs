namespace ShopLand.Application.Products.Queries.GetProduct.Handler;



public sealed class GetProductQueryHandler(IUnitOfWork uow)
    : IGetProductQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> HandelAsync(GetProductQueryRequest request, CancellationToken token = default)
        => await _uow.Products.Get(request.ProductId, token)
            ?? throw new ProductNotFoundException();
}