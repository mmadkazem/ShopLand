namespace ShopLand.Test.Domain.Entities;

public class CartTest
{

    [Fact]
    public void AddCartItem_Throw_CartItemAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
    {
        //ARRANGE
        var Cart = GetCart();
        var ProductId = Guid.NewGuid();
        Cart.AddCartItem(ProductId, 5, 11);

        //ACT
        var exception = Record.Exception(() => Cart.AddCartItem(ProductId, 5, 11));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CartItemAlreadyExistsException>();
    }

    [Fact]
    public void RemoveCartItem_Throws_CartItemOneRoleException_When_There_It_Has_A_CartItem_Cannot_Be_Deleted()
    {
        //ARRANGE
        var Cart = GetCart();
        var productId = Guid.NewGuid();
        Cart.AddCartItem(productId, 10, 11);

        //ACT
        var exception = Record.Exception(() => Cart.RemoveCartItem(productId));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CartItemOneRoleException>();

    }

    [Fact]
    public void GetCartItem_Throws_CartItemNotFoundException_When_There_CartItem_Not_Found()
    {
        //ARRANGE
        var cart = GetCart();
        cart.AddCartItem(Guid.NewGuid(), 10, 11);

        //ACT
        var exception = Record.Exception(() => cart.GetCartItem(Guid.NewGuid()));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CartItemNotFoundException>();

    }

    #region ARRANGE

    private Cart GetCart()
    {
        var cart = _factory.Create(Guid.NewGuid());
        return cart;
    }

    private readonly ICartFactory _factory;

    public CartTest()
    {
        _factory = new CartFactory();
    }

    #endregion
}