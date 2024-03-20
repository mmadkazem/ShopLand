namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class ProductRepository(DataBaseContext context)
    : IProductRepository
{
    private readonly DataBaseContext _context = context;

    public void Add(Product product)
        => _context.Products.Add(product);

    public async Task<bool> Any(ProductId id)
        => await _context.Products
                    .AsQueryable()
                    .AnyAsync(p => p.Id == id);

    public async Task<Product> FindAsync(ProductId id)
        => await _context.Products
                    .AsQueryable()
                    .Include(p => p.ProductCategories)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

    public async Task<Product> FindAsyncByProductName(ProductName productName)
        => await _context.Products
                    .AsQueryable()
                    .Include(p => p.ProductCategories)
                    .Where(p => p.ProductName == productName)
                    .FirstOrDefaultAsync();
    public async Task<IEnumerable<Product>> GetAll(int page)
        => await _context.Products
                    .Include(p => p.ProductCategories)
                    .Skip((page - 1) * 25)
                    .Take(25)
                    .ToListAsync();

    public void Remove(Product product)
        => _context.Products.Remove(product);

    public async Task RemoveProductCategories(Guid categoryId)
    {
        var categories = await _context.ProductCategories
            .AsQueryable()
            .Where( pc => pc.Category == categoryId)
            .ToListAsync();

        _context.ProductCategories.RemoveRange(categories);
    }
}