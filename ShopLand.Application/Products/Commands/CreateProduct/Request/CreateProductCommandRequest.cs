namespace ShopLand.Application.Products.Commands.CreateProduct.Request;

public record CreateProductCommandRequest
(
    string Name,
    string Brand,
    string Description,
    uint Inventory,
    uint Price,
    List<Guid> Categories
);