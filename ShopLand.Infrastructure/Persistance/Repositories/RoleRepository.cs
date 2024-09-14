namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class RoleRepository(DataBaseContext context) : IRoleRepository
{
    private readonly DataBaseContext _context = context;

    public void Add(Role role)
        => _context.Roles.Add(role);

    public void Remove(Role role)
        => _context.Roles.Remove(role);

    public async Task<bool> Any(RoleName name, CancellationToken token = default)
        => await _context.Roles.AsQueryable().AnyAsync(r => r.Name == name, token);

    public async Task<bool> Any(RoleId id, CancellationToken token = default)
        => await _context.Roles.AsQueryable().AnyAsync(r => r.Id == id, token);

    public async Task<Role> FindAsync(RoleId id, CancellationToken token = default)
        => await _context.Roles.AsQueryable()
                                .Where(r => r.Id == id)
                                .FirstOrDefaultAsync(token);

    public async Task<Role> FindAsyncByName(RoleName name, CancellationToken token = default)
        => await _context.Roles.AsQueryable()
                                .Where(r => r.Name == name)
                                .FirstOrDefaultAsync(token);

    public async Task<List<Role>> GetAll(int page, CancellationToken token = default)
    => await _context.Roles.AsQueryable()
                            .Skip((page - 1) * 25)
                            .Take(25)
                            .ToListAsync(token);
}