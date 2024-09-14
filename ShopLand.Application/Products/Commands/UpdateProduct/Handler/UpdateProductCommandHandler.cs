namespace ShopLand.Application.Products.Commands.UpdateProduct.Handler;

public sealed class UpdateProductCommandHandler(IUnitOfWork uow)
    : IUpdateProductCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(UpdateProductCommandRequest request, CancellationToken token = default)
    {
        var (id, name, brand, description, inventory, price) = request;

        var product = await _uow.Products.FindAsync(id, token)
            ?? throw new ProductNotFoundException();

        product.Update(brand, inventory, name, description, price);
        await _uow.SaveChangeAsync(token);
    }
}