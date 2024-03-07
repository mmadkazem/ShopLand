namespace ShopLand.Application.Account.ExternalServices.Jwt;

public interface ITokenFactoryService
{
    Task<JwtTokensDataResponse> CreateJwtTokensAsync(User user);
}