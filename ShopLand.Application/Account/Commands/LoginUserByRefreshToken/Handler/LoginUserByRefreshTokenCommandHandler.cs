namespace ShopLand.Application.Account.Commands.LoginUserByRefreshToken.Handler;

public sealed class LoginUserByRefreshTokenCommandHandler(IUnitOfWork uow, ITokenFactoryService tokenFactory)
    : ILoginUserByRefreshTokenCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;

    public async Task<JwtTokensDataResponse> HandelAsync(LoginUserByRefreshTokenCommandRequest request, CancellationToken token = default)
    {
        var user = await _uow.Users.FindAsync(request.UserId, token)
            ?? throw new UserNotFoundException();

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