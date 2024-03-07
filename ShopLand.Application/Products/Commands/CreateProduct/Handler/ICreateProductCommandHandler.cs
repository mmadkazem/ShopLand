namespace ShopLand.Application.Products.Commands.CreateProduct.Handler;

public interface ICreateProductCommandHandler
{
    Task<Guid> HandelAsync(CreateProductCommandRequest request);
}