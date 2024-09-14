namespace ShopLand.Application.Products.Commands.UpdateProduct.Request;


public readonly record struct UpdateProductCommandRequest
(
    Guid ProductId,
    string Name, string Brand, string Description,
    uint Inventory, uint Price
)
{
    public static UpdateProductCommandRequest Create(Guid productId, UpdateProductDTO model)
        => new(productId, model.Name, model.Brand, model.Description, model.Inventory, model.Price);
}

public readonly record struct UpdateProductDTO
(
    string Name, string Brand, string Description,
    uint Inventory, uint Price
);