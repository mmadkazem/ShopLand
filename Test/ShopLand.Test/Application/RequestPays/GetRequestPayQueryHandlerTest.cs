namespace ShopLand.Test.Application.RequestPays;


public class GetRequestPayQueryHandlerTest
{
    async Task Act(GetRequestPayQueryRequest request)
        => await _getRequestPay.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_RequestPayNotFoundException_When_There_Is_No_RequestPay_Found_With_This_Information()
    {
        // ARRANGE
        var request = new GetRequestPayQueryRequest(Guid.NewGuid());
        _uow.RequestPays.FindAsync(request.RequestPayId).Returns(default(RequestPay));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<RequestPayNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Get_Product_Information_On_Success()
    {
        // ARRANGE
        var request = new GetRequestPayQueryRequest(Guid.NewGuid());
        var requestPay = new RequestPay(request.RequestPayId, Guid.NewGuid(), 10_000);
        _uow.RequestPays.FindAsync(request.RequestPayId).Returns(requestPay);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IGetRequestPayQueryHandler _getRequestPay;
    public GetRequestPayQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _getRequestPay = new GetRequestPayQueryHandler(_uow);
    }

    #endregion
}