namespace ShopLand.Domain.Products.Product_Aggregate.Repositories;

public interface IProductRepository
{
    void Add(Product product);
    void Remove(Product product);
    Task<bool> Any(ProductId id, CancellationToken token = default);
    Task RemoveProductCategories(Guid id, CancellationToken token = default);
    Task<Product> FindAsync(ProductId id, CancellationToken token = default);
    Task<IEnumerable<IResponse>> GetAll(int page, CancellationToken token = default);
    Task<Product> FindAsyncByProductName(ProductName productName, CancellationToken token = default);
    Task<IResponse> Get(ProductId id, CancellationToken token);
}