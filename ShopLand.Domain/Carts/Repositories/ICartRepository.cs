namespace ShopLand.Domain.Carts.Repositories;


public interface ICartRepository
{
    void Add(Cart cart);
    void Remove(Cart cart);
    Task<Cart> FindAsync(CartId cartId, CancellationToken token = default);
    Task<Cart> FindAsyncByUserId(Guid userId, CancellationToken token = default);
    Task RemoveCartItem(Guid productId, CancellationToken token = default);
    Task<IEnumerable<CartItem>> FindAsyncCartItem(Guid productId, CancellationToken token = default);
}