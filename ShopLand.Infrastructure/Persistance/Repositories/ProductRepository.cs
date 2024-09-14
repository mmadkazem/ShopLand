namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class ProductRepository(DataBaseContext context)
    : IProductRepository
{
    private readonly DataBaseContext _context = context;

    public void Add(Product product)
        => _context.Products.Add(product);

    public void Remove(Product product)
        => _context.Products.Remove(product);

    public async Task<bool> Any(ProductId id, CancellationToken token = default)
        => await _context.Products.AsQueryable().AnyAsync(p => p.Id == id, token);

    public async Task<Product> FindAsync(ProductId id, CancellationToken token = default)
        => await _context.Products.AsQueryable()
                                    .Include(p => p.ProductCategories)
                                    .Where(p => p.Id == id)
                                    .FirstOrDefaultAsync(token);

    public async Task<Product> FindAsyncByProductName(ProductName productName, CancellationToken token = default)
        => await _context.Products.AsQueryable()
                                    .Include(p => p.ProductCategories)
                                    .Where(p => p.ProductName == productName)
                                    .FirstOrDefaultAsync(token);
    public async Task<IEnumerable<Product>> GetAll(int page, CancellationToken token = default)
        => await _context.Products.Include(p => p.ProductCategories)
                                    .Skip((page - 1) * 25)
                                    .Take(25)
                                    .ToListAsync(token);


    public async Task RemoveProductCategories(Guid categoryId, CancellationToken token = default)
        => await _context.ProductCategories.Where(p => p.Category == categoryId)
                                            .ExecuteDeleteAsync(token);
}