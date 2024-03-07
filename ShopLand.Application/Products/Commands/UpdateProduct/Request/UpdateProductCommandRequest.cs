namespace ShopLand.Application.Products.Commands.UpdateProduct.Request;


public record UpdateProductCommandRequest
(
    Guid ProductId,
    string Name,
    string Brand,
    string Description,
    uint Inventory,
    uint Price
);