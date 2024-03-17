using ShopLand.Application.Carts.Commands.RemoveCartItem.Handler;
using ShopLand.Application.Carts.Commands.RemoveCartItem.Request;

namespace ShopLand.Test.Application.Carts;

public class RemoveCartItemCommandHandlerTest
{
    async Task Act(RemoveCartItemCommandRequest request)
        => await _removeCartItem.HandleAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_CartNotFoundException_When_There_Is_No_Cart_Found_With_This_Information()
    {
        // ARRANGE
        var request = new RemoveCartItemCommandRequest(Guid.NewGuid());
        _uow.Carts.FindAsyncByUserId(request.UserId).Returns(default(Cart));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CartNotFoundException>();
    }

    [Fact]
    public async Task HandelAsync_Throw_ProductNotFoundException_When_There_Is_No_Product_Found_With_This_Information()
    {
        // ARRANGE
        var request = new RemoveCartItemCommandRequest(Guid.NewGuid());
        _uow.Carts.FindAsyncByUserId(request.UserId).Returns(new Cart());
        _uow.Products.Any(request.ProductId).Returns(false);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_RemoveCartItem_On_Success()
    {
        // ARRANGE
        var cart = new Cart();
        var request = new RemoveCartItemCommandRequest(Guid.NewGuid());
        cart.AddCartItem(Guid.NewGuid(), 5, 10);
        cart.AddCartItem(request.ProductId, 5, 10);
        _uow.Carts.FindAsyncByUserId(request.UserId).Returns(cart);
        _uow.Products.Any(request.ProductId).Returns(true);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IRemoveCartItemCommandHandler _removeCartItem;
    public RemoveCartItemCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _removeCartItem = new RemoveCartItemCommandHandler(_uow);
    }

    #endregion
}