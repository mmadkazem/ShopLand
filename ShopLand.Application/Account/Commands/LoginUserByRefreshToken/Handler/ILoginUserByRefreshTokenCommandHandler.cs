namespace ShopLand.Application.Account.Commands.LoginUserByRefreshToken.Handler;

public interface ILoginUserByRefreshTokenCommandHandler
{
    Task<JwtTokensDataResponse> HandelAsync
        (LoginUserByRefreshTokenCommandRequest request);
}

public sealed class LoginUserByRefreshTokenCommandHandler
    : ILoginUserByRefreshTokenCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly ITokenFactoryService _tokenFactory;

    public LoginUserByRefreshTokenCommandHandler(IUnitOfWork uow,
        ITokenFactoryService tokenFactory)
    {
        _uow = uow;
        _tokenFactory = tokenFactory;
    }

    public async Task<JwtTokensDataResponse> HandelAsync(LoginUserByRefreshTokenCommandRequest request)
    {
        var user = await _uow.Users.FindAsync(request.UserId);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        user.UserLoginByRefreshToken(request.RefreshTokenSerial);

        var jwt = await _tokenFactory.CreateJwtTokensAsync(user);

        user.AddToken(new UserToken
        (
            jwt.AccessToken,
            jwt.AccessTokenExpireTime,
            jwt.RefreshToken,
            jwt.RefreshTokenSerial,
            jwt.RefreshTokenExpireTime,
            user.Id
        ));

        return new(jwt.AccessToken, jwt.RefreshToken);
    }
}