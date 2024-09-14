namespace ShopLand.Domain.Account.Users.Repositories;

public interface IUserRepository
{
    void Add(User user);
    void Remove(User user);
    Task<bool> Any(UserId id, CancellationToken token = default);
    Task<User> FindAsync(UserId id, CancellationToken token = default);
    Task RemoveUserRoles(Guid roleId, CancellationToken token = default);
    Task<User> FindAsyncByEmail(Email email, CancellationToken token = default);
    Task<IEnumerable<User>> GetAll(int pageSize, int page, CancellationToken token = default);
    Task<IEnumerable<UserInRole>> FindAsyncUserRole(Guid roleId, CancellationToken token = default);
    Task<IResponse> GetById(UserId userId, CancellationToken token);
}