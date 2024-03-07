namespace ShopLand.Domain.Products.Product_Aggregate.Factories;

public class ProductFactory : IProductFactory
{
    public Product Create(Brand brand, ProductName productName,
        ProductDescription description,
        ProductPrice price, Inventory inventory)

            => new(Guid.NewGuid(), brand, productName, inventory, description, price);
}