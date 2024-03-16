using ShopLand.Application.Account.Commands.RemoveUserRole.Handler;
using ShopLand.Application.Account.Commands.RemoveUserRole.Request;

namespace ShopLand.Test.Application.Users;

public class RemoveUserRoleCommandHandlerTest
{
    async Task Act(RemoveUserRoleCommandRequest request)
        => await _removeUserRole.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_UserNotFoundException_When_There_Is_No_User_Found_With_This_Information()
    {
        // ARRANGE
        var request = new RemoveUserRoleCommandRequest(Guid.NewGuid(), Guid.NewGuid());
        _uow.Users.FindAsync(request.UserId).Returns(default(User));

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
        var request = new RemoveUserRoleCommandRequest(Guid.NewGuid(), Guid.NewGuid());
        _uow.Users.FindAsync(request.UserId).Returns(new User());
        _uow.Roles.Any(request.RoleId).Returns(false);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<RoleNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_RemoveUserRole_On_Success()
    {
        // ARRANGE
        var request = new RemoveUserRoleCommandRequest(Guid.NewGuid(), Guid.NewGuid());
        var user = new User();
        user.AddRole(request.RoleId);
        user.AddRole(Guid.NewGuid());
        _uow.Users.FindAsync(request.UserId).Returns(user);
        _uow.Roles.Any(request.RoleId).Returns(true);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IRemoveUserRoleCommandHandler _removeUserRole;
    public RemoveUserRoleCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _removeUserRole = new RemoveUserRoleCommandHandler(_uow);
    }

    #endregion
}