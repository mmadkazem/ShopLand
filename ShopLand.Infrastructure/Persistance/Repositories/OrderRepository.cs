namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class OrderRepository(DataBaseContext context)
    : IOrderRepository
{
    private readonly DataBaseContext _context = context;

    public void Add(Order order)
        => _context.Orders.Add(order);

    public async Task<Order> FindAsync(OrderId id)
        => await _context.Orders
                        .AsQueryable()
                        .Where(o => o.Id == id)
                        .FirstOrDefaultAsync();

    public async Task<IEnumerable<Order>> FindAsyncByUserId(Guid userId)
        => await _context.Orders
                        .AsQueryable()
                        .Where(o => o.UserId == userId)
                        .ToListAsync();

    public async Task<IEnumerable<Order>> GetAll(int page)
        => await _context.Orders
                        .AsQueryable()
                        .Include(o => o.OrderDetails)
                        .Skip((page - 1) * 25).Take(25)
                        .ToListAsync();
}