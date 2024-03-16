namespace ShopLand.Test.Application.Roles;

public class CreateRoleCommandHandlerTest
{
    async Task Act(CreateRoleCommandRequest request)
        => await _createRole.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_RoleAlreadyExistsException_When_There_Is_Role_Already_Exists_Before()
    {
        // ARRANGE
        var request = new CreateRoleCommandRequest("Test");
        _uow.Roles.Any(request.RoleName).Returns(false);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<RoleAlreadyExistsException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Factory_Create_New_Role_On_Success()
    {
        // ARRANGE
        var request = new CreateRoleCommandRequest("Test");
        _uow.Roles.Any(request.RoleName).Returns(true);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _roleFactories.Received(1).Create(Arg.Any<string>());
    }

    [Fact]
    public async Task HandleAsync_Calls_RoleRepository_Add_New_Role_On_Success()
    {
        // ARRANGE
        var request = new CreateRoleCommandRequest("Test");
        _uow.Roles.Any(request.RoleName).Returns(true);
        _roleFactories.Create(request.RoleName).Returns(new Role());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _uow.Roles.Received(1).Add(Arg.Any<Role>());
        await _uow.Received(1).SaveAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IRoleFactories _roleFactories;
    private readonly ICreateRoleCommandHandler _createRole;
    public CreateRoleCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _roleFactories = Substitute.For<IRoleFactories>();
        _createRole = new CreateRoleCommandHandler(_uow, _roleFactories);
    }

    #endregion
}