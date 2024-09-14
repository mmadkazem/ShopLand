namespace ShopLand.Application.Products.Commands.CreateProduct.Request;

public readonly record struct CreateProductCommandRequest
(
    string Name,
    string Brand,
    string Description,
    uint Inventory,
    uint Price,
    List<Guid> Categories
);