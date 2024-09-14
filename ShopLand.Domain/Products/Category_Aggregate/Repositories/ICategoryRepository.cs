namespace ShopLand.Domain.Products.Category_Aggregate.Repositories;

public interface ICategoryRepository
{
    void Add(Category category);
    void Remove(Category category);
    Task<bool> Any(CategoryId id, CancellationToken token = default);
    Task<Category> FindAsync(CategoryId id, CancellationToken token = default);
    Task<IEnumerable<Category>> GetAll(int page, CancellationToken token = default);
}