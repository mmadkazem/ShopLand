namespace ShopLand.Application.Account.Commands.LoginUserByRefreshToken.Handler;

public interface ILoginUserByRefreshTokenCommandHandler
{
    Task<JwtTokensDataResponse> HandelAsync(LoginUserByRefreshTokenCommandRequest request, CancellationToken token = default);
}
