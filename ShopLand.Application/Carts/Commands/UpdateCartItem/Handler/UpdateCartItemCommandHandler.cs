namespace ShopLand.Application.Carts.Commands.UpdateCartItem.Handler;

public sealed class UpdateCartItemCommandHandler(IUnitOfWork uow)
    : IUpdateCartItemCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(UpdateCartItemCommandRequest request, CancellationToken token = default)
    {
        var cart = await _uow.Carts.FindAsyncByUserId(request.UserId, token)
            ?? throw new CartNotFoundException();

        var product = await _uow.Products.FindAsync(request.ProductId, token)
            ?? throw new ProductNotFoundException();

        switch (request.CountType)
        {
            case CountType.Add:
                cart.Add(product.Id, product.Inventory);
                break;

            case CountType.Low:
                cart.Low(product.Id);
                break;
        }

        await _uow.SaveChangeAsync(token);
    }
}