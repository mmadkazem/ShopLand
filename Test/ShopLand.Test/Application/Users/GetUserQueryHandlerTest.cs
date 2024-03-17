using ShopLand.Application.Account.Queries.GetUser.Handler;
using ShopLand.Application.Account.Queries.GetUser.Request;

namespace ShopLand.Test.Application.Users;

public class GetUserQueryHandlerTest
{
    async Task Act(GetUserQueryRequest request)
        => await _getUser.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_UserNotFoundException_When_There_Is_No_User_Found_With_This_Information()
    {
        // ARRANGE
        var request = new GetUserQueryRequest(Guid.NewGuid());
        _uow.Users.FindAsync(request.UserId).Returns(default(User));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Get_User_Information_On_Success()
    {
        // ARRANGE
        var request = new GetUserQueryRequest(Guid.NewGuid());
        var user = new User(Guid.NewGuid(), FullName.Create("Test,Test"), "TestEmail@test.com", new Password("@@Test11@@", "@@Test11@@"));
        user.AddRole([Guid.NewGuid(), Guid.NewGuid()]);
        _uow.Users.FindAsync(request.UserId).Returns(user);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }
    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IGetUserQueryHandler _getUser;
    public GetUserQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _getUser = new GetUserQueryHandler(_uow);
    }

    #endregion
}