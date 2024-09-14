namespace ShopLand.Domain.Products.Category_Aggregate.Repositories;

public interface ICategoryRepository
{
    void Add(Category category);
    void Remove(Category category);
    Task<bool> Any(CategoryId id, CancellationToken token = default);
    Task<bool> Any(CategoryName name, CancellationToken token = default);
    Task<Category> FindAsync(CategoryId id, CancellationToken token = default);
    Task<IEnumerable<IResponse>> GetAll(int page, CancellationToken token = default);
    Task<IResponse> Get(CategoryId id, CancellationToken token = default);
}