namespace ShopLand.Test.Domain.Entities;

public class UserTests
{
    [Fact]
    public void AddUserRole_Throws_UserInRoleAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
    {
        //ARRANGE
        var User = GetUser();
        var roleId = Guid.NewGuid();
        User.AddRole(roleId);

        //ACT
        var exception = Record.Exception(() => User.AddRole(roleId));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserInRoleAlreadyExistsException>();

    }

    [Fact]
    public void RemoveRole_Throws_UserInRoleOneRoleException_When_There_It_Has_A_Role_Cannot_Be_Deleted()
    {
        //ARRANGE
        var User = GetUser();
        var roleId = Guid.NewGuid();
        User.AddRole(roleId);

        //ACT
        var exception = Record.Exception(() => User.RemoveRole(roleId));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserInRoleOneRoleException>();

    }

    [Fact]
    public void GetRole_Throws_UserInRoleNotFoundException_When_There_Role_Not_Found()
    {
        //ARRANGE
        var User = GetUser();
        User.AddRole(Guid.NewGuid());

        //ACT
        var exception = Record.Exception(() => User.GetRole(Guid.NewGuid()));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserInRoleNotFoundException>();

    }
    #region ARRANGE

    private User GetUser()
    {
        var user = _factory.Create("TestFistName", "TestLastName", "@@Test1@@", "@@Test1@@", "TestEmail@test.com");
        return user;
    }

    private readonly IUserFactories _factory;

    public UserTests()
    {
        _factory = new UserFactories();
    }

    #endregion

}