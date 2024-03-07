namespace ShopLand.Application.Products.Commands.UpdateProduct.Handler;

public class UpdateProductCommandHandler(IUnitOfWork uow) : IUpdateProductCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(UpdateProductCommandRequest request)
    {
        var (id, name, brand, description, inventory, price) = request;

        var product = await _uow.Products.FindAsync(id);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        product.Update(brand, inventory, name, description, price);
        await _uow.SaveAsync();
    }
}