namespace ShopLand.Test.Application.Users;

public class ChangePasswordCommandHandlerTest
{
    async Task Act(ChangePasswordCommandRequest request)
        => await _changePassword.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_EqualNewPasswordAndOldPasswordException_When_There_Is_The_New_Password_And_The_OldPassword_Are_The_Same()
    {
        // ARRANGE
        var request = new ChangePasswordCommandRequest("TestEmail@test.com", "@@Test11@@", "@@Test11@@", "@@Test11@@");

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<EqualNewPasswordAndOldPasswordException>();
    }

    [Fact]
    public async Task HandelAsync_Throw_UserNotFoundException_When_There_Is_No_User_Found_With_This_Information()
    {
        // ARRANGE
        var request = new ChangePasswordCommandRequest("TestEmail@test.com", "@@Test11@@", "@@Test12@@", "@@Test12@@");
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
        var user = new User(Guid.NewGuid(), FullName.Create("Test,Test"), "TestEmail@test.com", new Password("@@Test13@@", "@@Test13@@"));
        var request = new ChangePasswordCommandRequest("TestEmail@test.com", "@@Test11@@", "@@Test12@@", "@@Test12@@");
        _uow.Users.FindAsyncByEmail(request.Email).Returns(user);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotLoginException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_ChangePassword_On_Success()
    {
        // ARRANGE
        var user = new User(Guid.NewGuid(), FullName.Create("Test,Test"), "TestEmail@test.com", new Password("@@Test11@@", "@@Test11@@"));
        var request = new ChangePasswordCommandRequest("TestEmail@test.com", "@@Test11@@", "@@Test12@@", "@@Test12@@");
        _uow.Users.FindAsyncByEmail(request.Email).Returns(user);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IChangePasswordCommandHandler _changePassword;
    public ChangePasswordCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _changePassword = new ChangePasswordCommandHandler(_uow);
    }

    #endregion
}