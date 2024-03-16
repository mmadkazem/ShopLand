namespace ShopLand.Test.Application.Users;


public class RegisterUserCommandHandlerTest
{
    async Task Act(RegisterUserCommandRequest request)
        => await _registerUser.HandelAsync(request);

    [Fact]
    public async Task HandleAsync_Calls_UnitOfWork_RoleRepository_FindAsyncByName_On_Success()
    {
        // ARRANGE
        var request = new RegisterUserCommandRequest("TestFistName", "TestLastName", "TestEmail@test.com", "@@Test11@@", "@@Test11@@");

        _userFactories.Create(request.FirstName, request.LastName,
            request.Password, request.ConfirmPassword, request.Email).Returns(new User());
        _uow.Roles.FindAsyncByName(CustomRoles.Customer).Returns(new Role());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Roles.Received(1).FindAsyncByName(nameof(CustomRoles.Customer));
    }

    [Fact]
    public async Task HandleAsync_Calls_UnitOfWork_UserRepository_Add_On_Success()
    {
        // ARRANGE
        var request = new RegisterUserCommandRequest("TestFistName", "TestLastName", "TestEmail@test.com", "@@Test11@@", "@@Test11@@");

        _userFactories.Create(request.FirstName, request.LastName,
            request.Password, request.ConfirmPassword, request.Email).Returns(new User());
        _uow.Roles.FindAsyncByName(CustomRoles.Customer).Returns(new Role());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _uow.Users.Received(1).Add(Arg.Any<User>());
        await _uow.Received(1).SaveAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IUserFactories _userFactories;

    private readonly IRegisterUserCommandHandler _registerUser;
    public RegisterUserCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _userFactories = Substitute.For<IUserFactories>();
        _registerUser = new RegisterUserCommandHandler(_userFactories, _uow);
    }

    #endregion
}