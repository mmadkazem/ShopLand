namespace ShopLand.Domain.Products.Category_Aggregate.Repositories;

public interface ICategoryRepository
{
    void Add(Category category);
    void Remove(Category category);
    Task<Category> FindAsync(CategoryId id);
    Task<bool> Any(CategoryId id);
    Task<IEnumerable<Category>> GetAll(int page);
}