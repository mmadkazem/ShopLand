namespace ShopLand.Test.Application.Carts;

public class AddCartItemCommandHandlerTest
{
    async Task Act(AddCartItemCommandRequest request)
        => await _addCartItem.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_CartNotFoundException_When_There_Is_No_Cart_Found_With_This_Information()
    {
        // ARRANGE
        var request = new AddCartItemCommandRequest(10, Guid.NewGuid(), Guid.NewGuid());
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
        var request = new AddCartItemCommandRequest(10, Guid.NewGuid(), Guid.NewGuid());
        _uow.Carts.FindAsyncByUserId(request.UserId).Returns(new Cart());
        _uow.Products.FindAsync(request.ProductId).Returns(default(Product));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_AddCartItem_On_Success()
    {
        // ARRANGE
        var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());
        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 10, "TestDescription", 10_000);
        var request = new AddCartItemCommandRequest(5, Guid.NewGuid(), cart.Id);
        _uow.Carts.FindAsyncByUserId(request.UserId).Returns(cart);
        _uow.Products.FindAsync(request.ProductId).Returns(product);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveChangeAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly ICartFactory _cartFactory;
    private readonly IAddCartItemCommandHandler _addCartItem;
    public AddCartItemCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _cartFactory = Substitute.For<ICartFactory>();
        _addCartItem = new AddCartItemCommandHandler(_uow, _cartFactory);
    }

    #endregion
}