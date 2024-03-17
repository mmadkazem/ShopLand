namespace ShopLand.Domain.Carts.Repositories;


public interface ICartRepository
{
    void Add(Cart cart);
    void Remove(Cart cart);
    void RemoveCartItem(IEnumerable<CartItem> cartItems);
    Task<Cart> FindAsync(CartId cartId);
    Task<IEnumerable<CartItem>> FindAsyncCartItem(Guid productId);
    Task<Cart> FindAsyncByUserId(Guid userId);
}