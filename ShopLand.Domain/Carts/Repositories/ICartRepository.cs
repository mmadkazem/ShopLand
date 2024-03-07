namespace ShopLand.Domain.Carts.Repositories;


public interface ICartRepository
{
    void Add(Cart cart);
    void Remove(Cart cart);
    Task<Cart> FindAsync(CartId cartId);
    Task<Cart> FindAsyncByUserId(Guid userId);
}