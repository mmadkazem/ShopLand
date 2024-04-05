namespace ShopLand.Application.Products.Queries.GetProduct.Response;

public record GetProductQueryResponse
(
    Guid ProductId,
    string Name,
    string Brand,
    string Description,
    uint Inventory,
    uint Price
)
{
    public List<string> Categories { get; set; } = new();
}

public static class Exception
{
    public static GetProductQueryResponse AsResponse(this Product product)
        => new
        (
            product.Id, product.ProductName, product.Brand,
            product.Description, product.Inventory, product.Price
        );
}