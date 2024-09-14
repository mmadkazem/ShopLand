namespace ShopLand.Test.Application.Users;

public class AddUserRoleCommandHandlerTest
{
    async Task Act(AddUserRoleCommandRequest request)
        => await _addUserRole.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_UserNotFoundException_When_There_Is_No_User_Found_With_This_Information()
    {
        // ARRANGE
        var request = new AddUserRoleCommandRequest(Guid.NewGuid(), "Test");
        _uow.Users.FindAsync(request.Id).Returns(default(User));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotFoundException>();
    }

    [Fact]
    public async Task HandelAsync_RoleNotFoundException_When_There_Is_No_Role_Found_With_This_Information()
    {
        // ARRANGE
        var request = new AddUserRoleCommandRequest(Guid.NewGuid(), "Test");
        _uow.Users.FindAsync(request.Id).Returns(new User());
        _uow.Roles.FindAsyncByName(request.RoleName).Returns(default(Role));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<RoleNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_AddUserRole_On_Success()
    {
        // ARRANGE
        var request = new AddUserRoleCommandRequest(Guid.NewGuid(), "Test");
        _uow.Users.FindAsync(request.Id).Returns(new User());
        _uow.Roles.FindAsyncByName(request.RoleName).Returns(new Role());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveChangeAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IAddUserRoleCommandHandler _addUserRole;
    public AddUserRoleCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _addUserRole = new AddUserRoleCommandHandler(_uow);
    }

    #endregion
}