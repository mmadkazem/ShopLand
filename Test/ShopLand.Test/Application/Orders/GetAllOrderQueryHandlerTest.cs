namespace ShopLand.Test.Application.Orders;


public class GetAllOrderQueryHandlerTest
{
    async Task Act(PageNumberRequest request)
        => await _getOrder.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_OrderNotFoundException_When_There_Is_No_Order_Found_With_This_Information()
    {
        // ARRANGE
        var request = new PageNumberRequest(1);
        _uow.Orders.GetAll(request).Returns([]);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<OrderNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Get_All_Order_Information_On_Success()
    {
        // ARRANGE
        var request = new PageNumberRequest(1);
        var order = new Order(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            new Address("TestStreet", "TestCity", "TestState", "TestPostalCode"));
        _uow.Orders.GetAll(request).Returns([order]);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IGetAllOrderQueryHandler _getOrder;
    public GetAllOrderQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _getOrder = new GetAllOrderQueryHandler(_uow);
    }

    #endregion
}