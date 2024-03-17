namespace ShopLand.Test.Application.Roles;


public class RemoveRoleCommandHandlerTest
{
    async Task Act(RemoveRoleCommandRequest request)
        => await _removeRole.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_RoleNotFoundException_When_There_Is_No_Role_Found_With_This_Information()
    {
        // ARRANGE
        var request = new RemoveRoleCommandRequest(Guid.NewGuid());
        _uow.Roles.FindAsync(request.RoleId).Returns(default(Role));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<RoleNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_RoleRepository_Remove_Role_On_Success()
    {
        // ARRANGE
        var request = new RemoveRoleCommandRequest(Guid.NewGuid());
        _uow.Roles.FindAsync(request.RoleId).Returns(new Role());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _uow.Roles.Received(1).Remove(Arg.Any<Role>());
        await _uow.Received(1).SaveAsync();
    }

    [Fact]
    public async Task HandleAsync_Calls_Removed_Role_Event_On_Success()
    {
        // ARRANGE
        var request = new RemoveRoleCommandRequest(Guid.NewGuid());
        _uow.Roles.FindAsync(request.RoleId).Returns(new Role());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _removedRole.Received(1).HandelAsync(Arg.Any<Guid>());
    }


    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IRemoveRoleCommandHandler _removeRole;
    private readonly IRemovedRoleEventHandler _removedRole;
    public RemoveRoleCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _removedRole = Substitute.For<IRemovedRoleEventHandler>();
        _removeRole = new RemoveRoleCommandHandler(_uow, _removedRole);
    }

    #endregion
}