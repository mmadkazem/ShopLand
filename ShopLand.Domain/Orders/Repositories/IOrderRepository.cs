namespace ShopLand.Domain.Orders.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Task<Order> FindAsync(OrderId id, CancellationToken token = default);
    Task<IEnumerable<Order>> GetAll(int page, CancellationToken token = default);
    Task<IEnumerable<Order>> FindAsyncByUserId(Guid userId, CancellationToken token = default);
}