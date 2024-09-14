namespace ShopLand.Application.Products.Commands.RemoveProduct.Handler;

public interface IRemoveProductCommandHandler
{
    Task HandelAsync(RemoveProductCommandRequest request, CancellationToken token = default);
}
