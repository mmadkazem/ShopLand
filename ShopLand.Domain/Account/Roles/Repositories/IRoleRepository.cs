namespace ShopLand.Domain.Account.Roles.Repositories;

public interface IRoleRepository
{
    void Add(Role role);
    void Remove(Role role);
    Task<Role> FindAsync(RoleId id);
    Task<Role> FindAsyncByName(RoleName name);
    Task<bool> Any(RoleName name);
    Task<bool> Any(RoleId id);
    Task<List<Role>> GetAll(int page);
}