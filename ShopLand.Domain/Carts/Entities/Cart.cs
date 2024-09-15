using ShopLand.Domain.Carts.Factories;

namespace ShopLand.Domain.Carts.Entities;

public class Cart : BaseEntity<CartId>, IAggregateRoot
{
    public Guid UserId { get; private set; }
    public bool Finished { get; private set; } = default;
    public readonly List<CartItem> CartItems = [];
    public Cart(CartId id, Guid userId)
        : base(id)
    {
        UserId = userId;
    }

    // For Test
    public Cart() : base(Guid.NewGuid()) { }

    internal Cart(CartId id, Guid userId, List<CartItem> cartItems)
        : base(id)
    {
        UserId = userId;
        CartItems = cartItems;
    }

    public void AddCartItem(Guid productId, Count count, uint inventory, uint productPrice)
    {
        var cartItem = CartItems.FirstOrDefault(c => c.ProductId == productId);
        if (cartItem is not null)
        {
            cartItem.AddCount(count);
            return;
        }

        var newCartItem = new CartFactory().CreateCartItem(count, inventory, productId, Id, productPrice);
        CartItems.Add(cartItem);
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

    public void Low(Guid productId)
    {
        var cartItem = GetCartItem(productId);
        cartItem.Count.Low();
    }
    public void IsFinished()
    {
        Finished = true;
    }
    public CartItem GetCartItem(Guid productId)
        => CartItems.FirstOrDefault(c => c.ProductId == productId)
            ?? throw new CartItemNotFoundException();

    public uint TotalAmount()
        => (uint)CartItems.Sum(c => c.TotalPrice);
}