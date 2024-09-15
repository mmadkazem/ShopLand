namespace ShopLand.Test.Application.RequestPays;


public class CreateRequestPayCommandHandlerTest
{
    async Task Act(CreateRequestPayCommandRequest request)
        => await _createRequestPay.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_CartNotFoundException_When_There_Is_No_Cart_Found_With_This_Information()
    {
        // ARRANGE
        var request = new CreateRequestPayCommandRequest(Guid.NewGuid());
        _uow.Carts.FindAsyncByUserId(request.UserId).Returns(default(Cart));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CartNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_RequestPay_Factory_On_Success()
    {
        // ARRANGE
        var request = new CreateRequestPayCommandRequest(Guid.NewGuid());
        _uow.Carts.FindAsyncByUserId(request.UserId).Returns(new Cart());
        _requestPayFactory.Create(request.UserId, 10_000).Returns(new RequestPay());

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
        var request = new CreateRequestPayCommandRequest(Guid.NewGuid());
        _uow.Carts.FindAsyncByUserId(request.UserId).Returns(new Cart());
        _requestPayFactory.Create(request.UserId, 10_000).Returns(new RequestPay());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _uow.RequestPays.Received(1).Add(Arg.Any<RequestPay>());
        await _uow.Received(1).SaveChangeAsync();
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