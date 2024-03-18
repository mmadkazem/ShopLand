namespace ShopLand.Test.Application.RequestPays;


public class CreateRequestPayCommandHandlerTest
{
    async Task Act(CreateRequestPayCommandRequest request)
        => await _createRequestPay.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_UserNotFoundException_When_There_Is_No_User_Found_With_This_Information()
    {
        // ARRANGE
        var request = new CreateRequestPayCommandRequest(Guid.NewGuid(), 10_000);
        _uow.Users.Any(request.UserId).Returns(false);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_RequestPay_Factory_On_Success()
    {
        // ARRANGE
        var request = new CreateRequestPayCommandRequest(Guid.NewGuid(), 10_000);
        _uow.Users.Any(request.UserId).Returns(true);
        _requestPayFactory.Create(request.UserId, request.Amount).Returns(new RequestPay());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _requestPayFactory.Received(1).Create(Arg.Any<Guid>(), Arg.Any<uint>());
    }

    [Fact]
    public async Task HandleAsync_Calls_UnitOfWork_RequestPayRepository_Add_On_Success()
    {
        // ARRANGE
        var request = new CreateRequestPayCommandRequest(Guid.NewGuid(), 10_000);
        _uow.Users.Any(request.UserId).Returns(true);
        _requestPayFactory.Create(request.UserId, request.Amount).Returns(new RequestPay());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _uow.RequestPays.Received(1).Add(Arg.Any<RequestPay>());
        await _uow.Received(1).SaveAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IRequestPayFactory _requestPayFactory;

    private readonly ICreateRequestPayCommandHandler _createRequestPay;
    public CreateRequestPayCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _requestPayFactory = Substitute.For<IRequestPayFactory>();
        _createRequestPay = new CreateRequestPayCommandHandler(_uow, _requestPayFactory);
    }

    #endregion
}