namespace ShopLand.Application.Account.ExternalServices.Jwt;

public interface ITokenFactoryService
{
    Task<JwtTokensData> CreateJwtTokensAsync(User user);
}