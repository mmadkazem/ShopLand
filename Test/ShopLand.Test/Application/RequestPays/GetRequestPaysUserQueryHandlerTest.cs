namespace ShopLand.Test.Application.RequestPays;


public class GetRequestPaysUserQueryHandlerTest
{
    async Task Act(GetRequestPaysUserQueryRequest request)
        => await _getRequestPayUser.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_RequestPayNotFoundException_When_There_Is_No_RequestPay_Found_With_This_Information()
    {
        // ARRANGE
        var request = new GetRequestPaysUserQueryRequest(Guid.NewGuid());
        _uow.RequestPays.FindAsyncByUserId(request.UserId).Returns(new List<RequestPay>());

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
        var request = new GetRequestPaysUserQueryRequest(Guid.NewGuid());
        List<RequestPay> requestPays = [new RequestPay(request.UserId, Guid.NewGuid(), 10_000)];
        _uow.RequestPays.FindAsyncByUserId(request.UserId).Returns(requestPays);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IGetRequestPaysUserQueryHandler _getRequestPayUser;
    public GetRequestPaysUserQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _getRequestPayUser = new GetRequestPaysUserQueryHandler(_uow);
    }

    #endregion
}