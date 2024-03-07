namespace ShopLand.Application.Account.Queries.LoginUser.Handler;

public class LoginUserQueryHandler : ILoginUserQueryHandler
{
    private readonly IUnitOfWork _uow;
    private readonly ITokenFactoryService _tokenFactory;

    public LoginUserQueryHandler(IUnitOfWork uow, ITokenFactoryService tokenFactory)
    {
        _uow = uow;
        _tokenFactory = tokenFactory;
    }
    public async Task<JwtTokensDataResponse> HandelAsync(LoginUserQueryRequest request)
    {
        var user = await _uow.Users.FindAsyncByEmail(request.Email);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        var result = user.UserLogin(request.Email, request.Password);
        if (!result)
        {
            throw new UserNotLoginException();
        }

        return await _tokenFactory.CreateJwtTokensAsync(user);
    }
}

