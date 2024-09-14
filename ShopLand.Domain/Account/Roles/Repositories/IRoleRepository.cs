namespace ShopLand.Domain.Account.Roles.Repositories;

public interface IRoleRepository
{
    void Add(Role role);
    void Remove(Role role);
    Task<IEnumerable<IResponse>> GetAll(int page, CancellationToken token = default);
    Task<Role> FindAsyncByName(RoleName name, CancellationToken token = default);
    Task<Role> FindAsync(RoleId id, CancellationToken token = default);
    Task<bool> Any(RoleName name, CancellationToken token = default);
    Task<bool> Any(RoleId id, CancellationToken token = default);
}