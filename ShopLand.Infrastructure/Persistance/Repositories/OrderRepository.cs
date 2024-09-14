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

    public async Task<IEnumerable<IResponse>> GetByUserId(Guid userId, CancellationToken token = default)
        => await _context.Orders.AsQueryable()
                                .Where(o => o.UserId == userId)
                                .Select(o => o.AsResponse())
                                .AsNoTracking()
                                .ToListAsync(token);

    public async Task<IEnumerable<IResponse>> GetAll(int page, CancellationToken token = default)
        => await _context.Orders.AsQueryable()
                                .Skip((page - 1) * 25).Take(25)
                                .Select(o => o.AsResponse())
                                .AsNoTracking()
                                .ToListAsync(token);
}