namespace ShopLand.Domain.Orders.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Task<Order> FindAsync(OrderId id, CancellationToken token = default);
    Task<IEnumerable<IResponse>> GetAll(int page, CancellationToken token = default);
    Task<IEnumerable<IResponse>> GetByUserId(Guid userId, CancellationToken token = default);
}