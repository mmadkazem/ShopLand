namespace ShopLand.Application.Account.Queries.LoginUser.Handler;

public interface ILoginUserQueryHandler
{
    Task<JwtTokensDataResponse> HandelAsync(LoginUserQueryRequest request, CancellationToken token = default);
}
