namespace ShopLand.Domain.Carts.Factories;

public class CartFactory : ICartFactory
{
    public Cart Create(Guid userId)
        => new(Guid.NewGuid(), userId);

    public CartItem CreateCartItem(Count count, uint inventory, Guid productId, CartId cartId, uint productPrice)
    {
        CartItem cartItem = new(count, productId, cartId, productPrice);
        cartItem.Count.IsValid(inventory);

        return cartItem;
    }
}