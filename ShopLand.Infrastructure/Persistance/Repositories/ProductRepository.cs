using System.Collections.Immutable;
using ShopLand.Application.Products.Queries.GetProduct.Response;

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
    public async Task<IEnumerable<IResponse>> GetAll(int page, CancellationToken token = default)
        => await _context.Products.AsQueryable()
                                    .Select(p => p.AsResponses())
                                    .Skip((page - 1) * 25)
                                    .Take(25)
                                    .AsNoTracking()
                                    .ToListAsync(token);


    public async Task RemoveProductCategories(Guid categoryId, CancellationToken token = default)
        => await _context.ProductCategories.Where(p => p.Category == categoryId)
                                            .ExecuteDeleteAsync(token);

    public async Task<IResponse> Get(ProductId id, CancellationToken token)
        => await _context.Products.AsQueryable()
                                    .Where(p => p.Id == id)
                                    .Select(p => p.AsResponse())
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(token);
}