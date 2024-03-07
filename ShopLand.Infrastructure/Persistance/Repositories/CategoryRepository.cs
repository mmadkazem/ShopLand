namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class CategoryRepository(DataBaseContext context)
    : ICategoryRepository
{
    private readonly DataBaseContext _context = context;
    public void Add(Category category)
        => _context.Categories.Add(category);

    public async Task<bool> Any(CategoryId id)
        => await _context.Categories
                    .AsQueryable()
                    .AnyAsync(p => p.Id == id);

    public async Task<Category> FindAsync(CategoryId id)
        => await _context.Categories
                    .AsQueryable()
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();

    public async Task<IEnumerable<Category>> GetAll(int page)
        => await _context.Categories
                    .AsQueryable()
                    .Skip((page - 1) * 25)
                    .Take(25)
                    .ToListAsync();

    public void Remove(Category category)
        => _context.Categories.Remove(category);
}