namespace ShopLand.Domain.Products.Product_Aggregate.Repositories;

public interface IProductRepository
{
    void Add(Product product);
    void Remove(Product product);
    Task RemoveProductCategories(Guid id);
    Task<Product> FindAsync(ProductId id);
    Task<bool> Any(ProductId id);
    Task<Product> FindAsyncByProductName(ProductName productName);
    Task<IEnumerable<Product>> GetAll(int page);
}