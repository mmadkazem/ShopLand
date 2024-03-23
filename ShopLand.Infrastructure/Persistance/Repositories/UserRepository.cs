
namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class UserRepository(DataBaseContext context) : IUserRepository
{
    private readonly DataBaseContext _context = context;
    public void Add(User user)
        => _context.Users.Add(user);

    public async Task<User> FindAsync(UserId id)
        => await _context.Users
                    .AsQueryable()
                    .Include(u => u.UsedInRoles)
                    .Include(u => u.UserTokens)
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();

    public async Task<User> FindAsyncByEmail(Email email)
        => await _context.Users
                    .AsQueryable()
                    .Include(u => u.UsedInRoles)
                    .Where(u => u.Email == email)
                    .FirstOrDefaultAsync();

    public async Task<IEnumerable<User>> GetAll(int pageSize, int page)
        => await _context.Users
                    .Include(u => u.UsedInRoles)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

    public async Task<bool> Any(UserId id)
        => await _context.Users
            .AsQueryable()
            .AnyAsync(u => u.Id == id);


    public async Task<IEnumerable<UserInRole>> FindAsyncUserRole(Guid roleId)
        => await _context.UserInRoles
                     .AsQueryable()
                     .Where(r => r.Role == roleId)
                     .ToListAsync();
    public void Remove(User user)
        => _context.Users.Remove(user);
    public void RemoveUserRoles(IEnumerable<UserInRole> userInRoles)
        => _context.UserInRoles.RemoveRange(userInRoles);
}