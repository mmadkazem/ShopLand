namespace ShopLand.Domain.Orders.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Task<Order> FindAsync(OrderId id);
    Task<IEnumerable<Order>> FindAsyncByUserId(Guid userId);
    Task<IEnumerable<Order>> GetAll(int page);
}