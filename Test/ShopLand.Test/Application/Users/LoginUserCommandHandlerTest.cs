namespace ShopLand.Test.Application.Users;

public class LoginUserQueryHandlerTest
{
    async Task Act(LoginUserQueryRequest request)
        => await _loginUser.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_UserNotFoundException_When_There_Is_No_User_Found_With_This_Information()
    {
        // ARRANGE
        var request = new LoginUserQueryRequest("TestEmail@test.com", "@@Test11@@");
        _uow.Users.FindAsyncByEmail(request.Email).Returns(default(User));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotFoundException>();
    }

    [Fact]
    public async Task HandelAsync_Throw_UserNotLoginException_When_There_Is_could_Not_Login_The_Information_Is_Incorrect()
    {
        // ARRANGE
        var user = new User(Guid.NewGuid(), FullName.Create("Test,Test"), "Test@test.com", new Password("@@Test11@@"));
        var request = new LoginUserQueryRequest("TestEmail@test.com", "@@Test11@@");
        _uow.Users.FindAsyncByEmail(request.Email).Returns(user);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotLoginException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_UserLogin_On_Success()
    {
        // ARRANGE
        var user = new User(Guid.NewGuid(), FullName.Create("Test,Test"), "TestEmail@test.com", new Password("@@Test11@@", "@@Test11@@"));
        var request = new LoginUserQueryRequest("TestEmail@test.com", "@@Test11@@");
        _uow.Users.FindAsyncByEmail(request.Email).Returns(user);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();

    }

    [Fact]
    public async Task HandleAsync_Calls_TokenFactory_CreateJwtTokensAsync_On_Success()
    {
        // ARRANGE
        var user = new User(Guid.NewGuid(), FullName.Create("Test,Test"), "TestEmail@test.com", new Password("@@Test11@@", "@@Test11@@"));
        var request = new LoginUserQueryRequest("TestEmail@test.com", "@@Test11@@");
        _uow.Users.FindAsyncByEmail(request.Email).Returns(user);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _tokenFactory.Received(1).CreateJwtTokensAsync(Arg.Any<User>());

    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly ITokenFactoryService _tokenFactory;
    private readonly ILoginUserQueryHandler _loginUser;
    public LoginUserQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _tokenFactory = Substitute.For<ITokenFactoryService>();
        _loginUser = new LoginUserQueryHandler(_uow, _tokenFactory);
    }

    #endregion
}