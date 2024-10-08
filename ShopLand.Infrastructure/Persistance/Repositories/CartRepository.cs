namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class CartRepository(DataBaseContext context)
    : ICartRepository
{
    private readonly DataBaseContext _context = context;

    public void Add(Cart cart)
        => _context.Add(cart);

    public async Task<Cart> FindAsync(CartId cartId, CancellationToken token = default)
        => await _context.Carts.AsQueryable()
                                .Include(p => p.CartItems)
                                .Where(p => p.Id == cartId)
                                .FirstOrDefaultAsync(token);

    public async Task<IEnumerable<CartItem>> FindAsyncCartItem(Guid productId, CancellationToken token = default)
        => await _context.CartItems.AsQueryable()
                                    .Where(c => c.ProductId == productId)
                                    .ToListAsync(token);


    public async Task<Cart> FindAsyncByUserId(Guid userId, CancellationToken token = default)
        => await _context.Carts.AsQueryable()
                                .Include(p => p.CartItems)
                                .Where(p => p.UserId == userId)
                                .FirstOrDefaultAsync(token);

    public void Remove(Cart cart)
        => _context.Carts.Remove(cart);

    public async Task RemoveCartItem(Guid productId, CancellationToken token = default)
        => await _context.CartItems.AsQueryable()
                                    .Where(c => c.ProductId == productId)
                                    .ExecuteDeleteAsync(token);

    public async Task<IResponse> Get(Guid userId, CancellationToken token = default)
        => await _context.Carts.AsQueryable()
                                .Where(u => u.UserId == userId)
                                .Select(s => s.AsResponse())
                                .AsNoTracking()
                                .FirstOrDefaultAsync(token);

    public async Task UpdatedProduct(Guid productId, uint productPrice, CancellationToken token = default)
        => await _context.CartItems.Where(c => c.ProductId == productId)
                                    .ExecuteUpdateAsync(s => s.SetProperty(c => c.ProductPrice, productPrice), token);
}