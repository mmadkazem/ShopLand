namespace ShopLand.Test.Application.Carts;

public class UpdateCartItemCommandHandlerTest
{
    async Task Act(UpdateCartItemCommandRequest request)
        => await _updateCartItem.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_CartNotFoundException_When_There_Is_No_Cart_Found_With_This_Information()
    {
        // ARRANGE
        var request = new UpdateCartItemCommandRequest(Guid.NewGuid(), CountType.Add, Guid.NewGuid());
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
        var request = new UpdateCartItemCommandRequest(Guid.NewGuid(), CountType.Add, Guid.NewGuid());
        _uow.Carts.FindAsyncByUserId(request.UserId).Returns(new Cart());
        _uow.Products.FindAsync(request.ProductId).Returns(default(Product));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Add_Count_On_Success()
    {
        // ARRANGE
        var cart = new Cart();
        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 10, "TestDescription", 10_000);
        var request = new UpdateCartItemCommandRequest(Guid.NewGuid(), CountType.Add, Guid.NewGuid());
        cart.AddCartItem(product.Id, 5, 10, product.Price);
        _uow.Carts.FindAsyncByUserId(request.UserId).Returns(cart);
        _uow.Products.FindAsync(request.ProductId).Returns(product);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveChangeAsync();
    }

    [Fact]
    public async Task HandleAsync_Calls_Low_Count_On_Success()
    {
        // ARRANGE
        var cart = new Cart();
        var product = new Product();
        var request = new UpdateCartItemCommandRequest(Guid.NewGuid(), CountType.Low, Guid.NewGuid());
        cart.AddCartItem(product.Id, 5, 10, 10_000);
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
    private readonly IUpdateCartItemCommandHandler _updateCartItem;
    public UpdateCartItemCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _updateCartItem = new UpdateCartItemCommandHandler(_uow);
    }

    #endregion
}