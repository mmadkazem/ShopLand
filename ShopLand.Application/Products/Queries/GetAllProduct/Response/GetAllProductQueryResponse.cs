namespace ShopLand.Application.Products.Queries.GetAllProduct.Response;


public record GetAllProductQueryResponse
(
    Guid ProductId, string Name, string Brand,
    uint Inventory, uint Price
) : IResponse;

public static class Extension
{
    public static GetAllProductQueryResponse AsResponses(this Product product)
        => new(product.Id, product.ProductName, product.Brand, product.Inventory, product.Price);
}