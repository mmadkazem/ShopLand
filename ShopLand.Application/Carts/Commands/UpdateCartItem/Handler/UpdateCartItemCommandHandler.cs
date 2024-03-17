using ShopLand.Application.Carts.Commands.UpdateCartItem.Request;

namespace ShopLand.Application.Carts.Commands.UpdateCartItem.Handler;

public class UpdateCartItemCommandHandler(IUnitOfWork uow)
    : IUpdateCartItemCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(UpdateCartItemCommandRequest request)
    {
        var cart = await _uow.Carts.FindAsyncByUserId(request.UserId);
        if (cart is null)
        {
            throw new CartNotFoundException();
        }

        var product = await _uow.Products.FindAsync(request.ProductId);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        if (request.CountType == CountType.Add)
        {
            cart.Add(product.Id, product.Inventory);
        }
        else
        {
            cart.Low(product.Id);
        }
        await _uow.SaveAsync();
    }
}