namespace ShopLand.Application.Account.Queries.LoginUser.Handler;

public class LoginUserQueryHandler(IUnitOfWork uow, ITokenFactoryService tokenFactory) : ILoginUserQueryHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;

    public async Task<JwtTokensDataResponse> HandelAsync(LoginUserQueryRequest request, CancellationToken token = default)
    {
        var user = await _uow.Users.FindAsyncByEmail(request.Email, token)
            ?? throw new UserNotFoundException();

        user.UserLogin(request.Email, request.Password);

        var jwt = await _tokenFactory.CreateJwtTokensAsync(user);

        user.RemoveToken();
        user.AddToken(UserToken.Create
        (
            jwt.AccessToken,
            jwt.AccessTokenExpireTime,
            jwt.RefreshToken,
            jwt.RefreshTokenSerial,
            jwt.RefreshTokenExpireTime,
            user.Id
        ));
        await _uow.SaveAsync(token);

        return new(jwt.AccessToken, jwt.RefreshToken);
    }
}

