namespace ShopLand.Application.Products.Commands.UpdateProduct.Handler;

public interface IUpdateProductCommandHandler
{
    Task HandelAsync(UpdateProductCommandRequest request, CancellationToken token = default);
}