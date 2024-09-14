namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class OrderRepository(DataBaseContext context)
    : IOrderRepository
{
    private readonly DataBaseContext _context = context;

    public void Add(Order order)
        => _context.Orders.Add(order);

    public async Task<Order> FindAsync(OrderId id, CancellationToken token = default)
        => await _context.Orders.AsQueryable()
                                .Where(o => o.Id == id)
                                .FirstOrDefaultAsync(token);

    public async Task<IEnumerable<Order>> FindAsyncByUserId(Guid userId, CancellationToken token = default)
        => await _context.Orders.AsQueryable()
                                .Where(o => o.UserId == userId)
                                .ToListAsync(token);

    public async Task<IEnumerable<Order>> GetAll(int page, CancellationToken token = default)
        => await _context.Orders.AsQueryable()
                                .Include(o => o.OrderDetails)
                                .Skip((page - 1) * 25).Take(25)
                                .ToListAsync(token);
}