using ShopLand.Application.Carts.Commands.AddCartItem.Handler;
using ShopLand.Application.Carts.Commands.RemoveCartItem.Handler;
using ShopLand.Application.Carts.Commands.UpdateCartItem.Handler;
using ShopLand.Application.Carts.Queries.GetCart.Handler;

namespace ShopLand.Application.Carts.Facade;

public interface ICartFacade
{
    IAddCartItemCommandHandler AddCartItem { get; }
    IUpdateCartItemCommandHandler UpdateCartItem { get; }
    IRemoveCartItemCommandHandler RemoveCartItem { get; }
    IGetCartQueryHandler GetCart { get; }
}

public class CartFacade : ICartFacade
{
    public CartFacade(IAddCartItemCommandHandler addCartItem,
            IUpdateCartItemCommandHandler updateCartItem,
            IRemoveCartItemCommandHandler removeCartItem,
            IGetCartQueryHandler getCart)
    {
        _getCart = getCart;
        _addCartItem = addCartItem;
        _updateCartItem = updateCartItem;
        _removeCart = removeCartItem;
    }

    private readonly IAddCartItemCommandHandler _addCartItem;
    public IAddCartItemCommandHandler AddCartItem
        => _addCartItem;

    private readonly IUpdateCartItemCommandHandler _updateCartItem;
    public IUpdateCartItemCommandHandler UpdateCartItem
    => _updateCartItem;

    private readonly IRemoveCartItemCommandHandler _removeCart;
    public IRemoveCartItemCommandHandler RemoveCartItem
        => _removeCart;

    private readonly IGetCartQueryHandler _getCart;
    public IGetCartQueryHandler GetCart
        => _getCart;
}