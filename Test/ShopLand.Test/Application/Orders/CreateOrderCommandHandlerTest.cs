namespace ShopLand.Test.Application.Orders;


public class CreateOrderCommandHandlerTest
{
    async Task Act(CreateOrderCommandRequest request)
        => await _createOrder.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_UserNotFoundException_When_There_Is_No_User_Found_With_This_Information()
    {
        // ARRANGE
        var request = new CreateOrderCommandRequest(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid().ToString(), 1, "TestStreet", "TestCity", "TestState", "TestPostalCode");
        _uow.Users.Any(request.UserId).Returns(false);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotFoundException>();
    }

    [Fact]
    public async Task HandelAsync_RequestPayNotFoundException_When_There_Is_No_RequestPay_Found_With_This_Information()
    {
        // ARRANGE
        var request = new CreateOrderCommandRequest(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid().ToString(), 1, "TestStreet", "TestCity", "TestState", "TestPostalCode");
        _uow.Users.Any(request.UserId).Returns(true);
        _uow.RequestPays.FindAsync(request.RequestPayId).Returns(default(RequestPay));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<RequestPayNotFoundException>();
    }

    [Fact]
    public async Task HandelAsync_Throw_CartNotFoundExceptions_When_There_Is_No_Cart_Found_With_This_Information()
    {
        // ARRANGE
        var request = new CreateOrderCommandRequest(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid().ToString(), 1, "TestStreet", "TestCity", "TestState", "TestPostalCode");
        _uow.Users.Any(request.UserId).Returns(true);
        _uow.RequestPays.FindAsync(request.RequestPayId).Returns(new RequestPay());
        _orderFactory.Create(request.UserId, request.RequestPayId, request.Street, request.City, request.State, request.PostalCode).Returns(new Order());
        _uow.Carts.FindAsync(request.CartId).Returns(default(Cart));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CartNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_UnitOfWork_OrderRepository_Add_On_Success()
    {
        // ARRANGE
        var request = new CreateOrderCommandRequest(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid().ToString(), 1, "TestStreet", "TestCity", "TestState", "TestPostalCode");
        _uow.Users.Any(request.UserId).Returns(true);
        _uow.RequestPays.FindAsync(request.RequestPayId).Returns(new RequestPay());
        _orderFactory.Create(request.UserId, request.RequestPayId, request.Street, request.City, request.State, request.PostalCode).Returns(new Order());
        _uow.Carts.FindAsync(request.CartId).Returns(cart);
        _uow.Products.FindAsync(product.Id).Returns(product);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _uow.Orders.Received(1).Add(Arg.Any<Order>());
        await _uow.Received(1).SaveAsync();
    }

    [Fact]
    public async Task HandleAsync_Calls_Create_Order_Event_On_Success()
    {
        // ARRANGE
        var request = new CreateOrderCommandRequest(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid().ToString(), 1, "TestStreet", "TestCity", "TestState", "TestPostalCode");
        _uow.Users.Any(request.UserId).Returns(true);
        _uow.RequestPays.FindAsync(request.RequestPayId).Returns(new RequestPay());
        _orderFactory.Create(request.UserId, request.RequestPayId, request.Street, request.City, request.State, request.PostalCode).Returns(new Order());
        _uow.Carts.FindAsync(request.CartId).Returns(cart);
        _uow.Products.FindAsync(product.Id).Returns(product);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _createdOrder.Received(1).HandelAsync(Arg.Any<Guid>());
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IOrderFactory _orderFactory;
    private readonly ICreatedOrderEventHandler _createdOrder;
    Cart cart;
    Product product;

    private readonly ICreateOrderCommandHandler _createOrder;
    public CreateOrderCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _orderFactory = Substitute.For<IOrderFactory>();
        _createdOrder = Substitute.For<ICreatedOrderEventHandler>();
        _createOrder = new CreateOrderCommandHandler(_uow, _orderFactory, _createdOrder);
        cart = new Cart(Guid.NewGuid(), Guid.NewGuid());
        product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 5, "TestDescription", 10_000);
        cart.AddCartItem(product.Id, 5, 10);

    }

    #endregion
}