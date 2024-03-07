using ShopLand.Domain.Carts.Factories;

namespace ShopLand.Domain.Carts.Entities;

public class Cart : BaseEntity<CartId>, IAggregateRoot
{
    public Guid UserId { get; private set; }
    public bool Finished { get; private set; } = default;
    public readonly LinkedList<CartItem> CartItems = new();
    internal Cart(CartId id, Guid userId)
        : base(id)
    {
        UserId = userId;
    }

    internal Cart(CartId id, Guid userId, LinkedList<CartItem> cartItems)
        : base(id)
    {
        UserId = userId;
        CartItems = cartItems;
    }

    public void AddCartItem(Guid productId, Count count, uint inventory)
    {
        var alreadyExists = CartItems.Any(c => c.ProductId == productId);

        if (alreadyExists)
        {
            throw new ProductCategoryAlreadyExistsException();
        }
        var cartItem = new CartFactory().CreateCartItem
            (count, inventory, productId, Id);

        CartItems.AddLast(cartItem);
    }

    public void RemoveCartItem(Guid productId)
    {
        if (CartItems.Count == 1)
        {
            throw new CartItemOneRoleException();
        }
        var category = GetCartItem(productId);
        CartItems.Remove(category);
    }

    public void Add(Guid productId, uint inventory)
    {
        var cartItem = GetCartItem(productId);
        cartItem.Count.Add(inventory);
    }

    public void Low(Guid productId, uint inventory)
    {
        var cartItem = GetCartItem(productId);
        cartItem.Count.Low(inventory);
    }
    public void IsFinished()
    {
        Finished = true;
    }
    public CartItem GetCartItem(Guid productId)
    {
        var cartItem = CartItems
            .FirstOrDefault(c => c.ProductId == productId);

        if (cartItem is null)
        {
            throw new CartItemNotFoundException();
        }

        return cartItem;
    }
}