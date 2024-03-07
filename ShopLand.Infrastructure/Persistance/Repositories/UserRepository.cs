namespace ShopLand.Infrastructure.Persistance.Repositories;

public sealed class UserRepository(DataBaseContext context) : IUserRepository
{
    private readonly DataBaseContext _context = context;
    public void Add(User user)
        => _context.Users.Add(user);

    public async Task<User> FindAsync(UserId id)
        => await _context.Users
                    .AsQueryable()
                    .Include("_usedInRoles")
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();

    public async Task<User> FindAsyncByEmail(Email email)
        => await _context.Users
                    .AsQueryable()
                    .Include("_usedInRoles")
                    .Where(u => u.Email == email)
                    .FirstOrDefaultAsync();

    public async Task RemoveRange(Guid role)
    {
        var userRoles = await _context.UserInRoles
                        .AsQueryable()
                        .Where(u => u.Role == role)
                        .ToListAsync();
        List<User> users = new();
        foreach (var userRole in userRoles)
        {
            users.Add(await FindAsync(userRole.UserId));
        }
        _context.RemoveRange(users);
    }

    public async Task<IEnumerable<User>> GetAll(int pageSize, int page)
        => await _context.Users
                    .Include("_usedInRoles")
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();


    public void Remove(User user)
        => _context.Users.Remove(user);
}