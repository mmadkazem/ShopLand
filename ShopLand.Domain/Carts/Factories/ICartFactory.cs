namespace ShopLand.Domain.Carts.Factories;


public interface ICartFactory
{
    Cart Create(Guid userId);
    CartItem CreateCartItem(Count count, uint inventory, Guid productId, CartId cartId, uint productPrice);
}