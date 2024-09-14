namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class RequestPayRepository(DataBaseContext context)
    : IRequestPayRepository
{
    private readonly DataBaseContext _context = context;

    public void Add(RequestPay requestPay)
        => _context.requestPays.Add(requestPay);

    public async Task<RequestPay> FindAsync(RequestPayId Id, CancellationToken token = default)
        => await _context.requestPays.AsQueryable()
                                        .Where(p => p.Id == Id)
                                        .FirstOrDefaultAsync(token);

    public async Task<IResponse> Get(RequestPayId id, CancellationToken token)
        => await _context.requestPays.AsQueryable()
                                        .Where(p => p.Id == id)
                                        .Select(r => r.AsResponse())
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(token);

    public async Task<IEnumerable<IResponse>> GetByUserId(Guid userId, CancellationToken token = default)
        => await _context.requestPays.AsQueryable()
                                        .Where(p => p.UserId == userId)
                                        .Select(r => r.AsResponse())
                                        .AsNoTracking()
                                        .ToListAsync(token);
}