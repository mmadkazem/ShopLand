namespace ShopLand.Domain.Products.Product_Aggregate.Factories;

public interface IProductFactory
{
    Product Create
    (
        Brand brand,
        ProductName productName,
        ProductDescription description,
        ProductPrice price,
        Inventory inventory
    );
}