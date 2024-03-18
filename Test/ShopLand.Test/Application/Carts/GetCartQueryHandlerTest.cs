using ShopLand.Application.Carts.Queries.GetCart.Handler;
using ShopLand.Application.Carts.Queries.GetCart.Request;

namespace ShopLand.Test.Application.Carts;

public class GetCartQueryHandlerTest
{
    async Task Act(GetCartQueryRequest request)
        => await _getCart.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_CartNotFoundExceptions_When_There_Is_No_Cart_Found_With_This_Information()
    {
        // ARRANGE
        var request = new GetCartQueryRequest(Guid.NewGuid());
        _uow.Carts.FindAsyncByUserId(request.userId).Returns(default(Cart));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CartNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Get_Product_Information_On_Success()
    {
        // ARRANGE
        var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());
        var request = new GetCartQueryRequest(cart.UserId);
        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 5, "TestDescription", 10_000);
        cart.AddCartItem(product.Id, 5, 10);
        product.AddCategory(Guid.NewGuid());
        _uow.Carts.FindAsyncByUserId(request.userId).Returns(cart);
        _uow.Products.FindAsync(product.Id).Returns(product);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IGetCartQueryHandler _getCart;
    public GetCartQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _getCart = new GetCartQueryHandler(_uow);
    }

    #endregion
}