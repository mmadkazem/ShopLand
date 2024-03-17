namespace ShopLand.Domain.Account.Users.Repositories;

public interface IUserRepository
{
    void Add(User user);
    void Remove(User user);
    void RemoveUserRoles(IEnumerable<UserInRole> userInRoles);
    Task<User> FindAsync(UserId id);
    Task<User> FindAsyncByEmail(Email email);
    Task<IEnumerable<UserInRole>> FindAsyncUserRole(Guid roleId);
    Task<bool> Any(UserId id);
    Task<IEnumerable<User>> GetAll(int pageSize, int page);
}