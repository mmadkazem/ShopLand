namespace ShopLand.Test.Application.Orders;

public class UpdateOrderStateCommandHandlerTest
{
    async Task Act(UpdateOrderStateCommandRequest request)
        => await _updateOrderState.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_OrderNotFoundException_When_There_Is_No_Order_Found_With_This_Information()
    {
        // ARRANGE
        var request = new UpdateOrderStateCommandRequest(Guid.NewGuid(), OrderState.Delivered);
        _uow.Orders.FindAsync(request.OrderId).Returns(default(Order));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<OrderNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Update_OrderState_On_Success()
    {
        // ARRANGE
        var request = new UpdateOrderStateCommandRequest(Guid.NewGuid(), OrderState.Delivered);
        var cart = new Order(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            new Address("TestStreet", "TestCity", "TestState", "TestPostalCode"));
        _uow.Orders.FindAsync(request.OrderId).Returns(cart);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IUpdateOrderStateCommandHandler _updateOrderState;
    public UpdateOrderStateCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _updateOrderState = new UpdateOrderStateCommandHandler(_uow);
    }

    #endregion
}