namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class RoleRepository(DataBaseContext context) : IRoleRepository
{
    private readonly DataBaseContext _context = context;

    public void Add(Role role)
        => _context.Roles.Add(role);

    public async Task<bool> Any(RoleName name)
        => await _context.Roles
                .AsQueryable()
                .AnyAsync(r => r.Name == name);

    public async Task<bool> Any(RoleId id)
        => await _context.Roles
                .AsQueryable()
                .AnyAsync(r => r.Id == id);

    public async Task<Role> FindAsync(RoleId id)
        => await _context.Roles
                    .Where(r => r.Id == id)
                    .FirstOrDefaultAsync();

    public async Task<Role> FindAsyncByName(RoleName name)
        => await _context.Roles
                    .Where(r => r.Name == name)
                    .FirstOrDefaultAsync();

    public async Task<List<Role>> GetAll(int page)
    => await _context.Roles
                    .Skip((page - 1) * 25)
                    .Take(25)
                    .ToListAsync();
    public void Remove(Role role)
        => _context.Roles.Remove(role);
}