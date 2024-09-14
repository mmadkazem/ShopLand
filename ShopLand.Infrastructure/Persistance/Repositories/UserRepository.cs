namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class UserRepository(DataBaseContext context) : IUserRepository
{
    private readonly DataBaseContext _context = context;
    public void Add(User user)
        => _context.Users.Add(user);

    public void Remove(User user)
        => _context.Users.Remove(user);

    public async Task<User> FindAsync(UserId id, CancellationToken token = default)
        => await _context.Users.AsQueryable()
                                .Include(u => u.UsedInRoles)
                                .Include(u => u.UserTokens)
                                .Where(u => u.Id == id)
                                .FirstOrDefaultAsync(token);

    public async Task<User> FindAsyncByEmail(Email email, CancellationToken token = default)
        => await _context.Users.AsQueryable()
                                .Include(u => u.UsedInRoles)
                                .Where(u => u.Email == email)
                                .FirstOrDefaultAsync(token);

    public async Task<IEnumerable<User>> GetAll(int pageSize, int page, CancellationToken token = default)
        => await _context.Users.AsQueryable()
                                .Include(u => u.UsedInRoles)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync(token);

    public async Task<bool> Any(UserId id, CancellationToken token = default)
        => await _context.Users.AsQueryable().AnyAsync(u => u.Id == id, token);


    public async Task<IEnumerable<UserInRole>> FindAsyncUserRole(Guid roleId, CancellationToken token = default)
        => await _context.UserInRoles.AsQueryable()
                                        .Where(r => r.Role == roleId)
                                        .ToListAsync(token);
    public async Task RemoveUserRoles(Guid roleId, CancellationToken token = default)
        => await _context.UserInRoles.Where(r => r.Role == roleId)
                                        .ExecuteDeleteAsync(token);
}