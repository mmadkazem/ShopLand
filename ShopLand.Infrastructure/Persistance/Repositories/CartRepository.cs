namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class CartRepository(DataBaseContext context)
    : ICartRepository
{
    private readonly DataBaseContext _context = context;

    public void Add(Cart cart)
        => _context.Add(cart);

    public async Task<Cart> FindAsync(CartId cartId)
        => await _context.Carts
                    .AsQueryable()
                    .Include(p => p.CartItems)
                    .Where(p => p.Id == cartId)
                    .FirstOrDefaultAsync();

    public async Task<IEnumerable<CartItem>> FindAsyncCartItem(Guid productId)
         => await _context.CartItems
                     .AsQueryable()
                     .Where(c => c.ProductId == productId)
                     .ToListAsync();


    public async Task<Cart> FindAsyncByUserId(Guid userId)
        => await _context.Carts
                    .AsQueryable()
                    .Include(p => p.CartItems)
                    .Where(p => p.UserId == userId)
                    .FirstOrDefaultAsync();

    public void Remove(Cart cart)
        => _context.Carts.Remove(cart);

    public void RemoveCartItem(IEnumerable<CartItem> cartItems)
        => _context.CartItems.RemoveRange(cartItems);
}