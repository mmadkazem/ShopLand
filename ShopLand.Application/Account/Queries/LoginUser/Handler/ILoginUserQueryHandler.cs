using ShopLand.Application.Account.Queries.LoginUser.Response;

namespace ShopLand.Application.Account.Queries.LoginUser.Handler;

public interface ILoginUserQueryHandler
{
    Task<JwtTokensDataResponse> HandelAsync(LoginUserQueryRequest request);
}
