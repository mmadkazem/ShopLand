namespace ShopLand.Test.Application.Orders;


public class GetOrderByUserIdQueryHandlerTest
{
    async Task Act(GetOrderByUserIdQueryRequest request)
        => await _getOrderByUserId.HandelAsync(request);
    [Fact]
    public async Task HandelAsync_Throw_OrderNotFoundException_When_There_Is_No_Order_Found_With_This_Information()
    {
        // ARRANGE
        var request = new GetOrderByUserIdQueryRequest(Guid.NewGuid());
        _uow.Orders.FindAsyncByUserId(request.UserId).Returns([]);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<OrderNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Get_Order_By_UserId_Information_On_Success()
    {
        // ARRANGE
        var request = new GetOrderByUserIdQueryRequest(Guid.NewGuid());
        var order = new Order(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            new Address("TestStreet", "TestCity", "TestState", "TestPostalCode"));
        _uow.Orders.FindAsyncByUserId(request.UserId).Returns([order]);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IGetOrderByUserIdQueryHandler _getOrderByUserId;
    public GetOrderByUserIdQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _getOrderByUserId = new GetOrderByUserIdQueryHandler(_uow);
    }

    #endregion

}