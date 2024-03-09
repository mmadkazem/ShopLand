namespace ShopLand.Domain.Account.Users.Repositories;

public interface IUserRepository
{
    void Add(User user);
    void Remove(User user);
    Task<User> FindAsync(UserId id);
    Task<User> FindAsyncByEmail(Email email);
    Task<bool> Any(UserId id);
    Task RemoveRange(Guid role);
    Task<IEnumerable<User>> GetAll(int pageSize, int page);
}