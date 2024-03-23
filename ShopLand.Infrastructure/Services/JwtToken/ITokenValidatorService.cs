using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ShopLand.Infrastructure.Services.JwtToken;


public interface ITokenValidatorService
{
    Task ValidateAsync(TokenValidatedContext context);
}

public class TokenValidatorService(IUnitOfWork uow) : ITokenValidatorService
{
    private readonly IUnitOfWork _uow = uow;

    public async Task ValidateAsync(TokenValidatedContext context)
    {
        var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
        if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
        {
            context.Fail("This is not our issued token. It has no claims.");
            return;
        }

        var userIdString = claimsIdentity.FindFirst(ClaimTypes.UserData).Value
        .Replace(" ", "").Replace("Value", "").Replace("=", "").Replace("UserId", "");
        if (!Guid.TryParse(userIdString, out Guid userId))
        {
            context.Fail("This is not our issued token. It has no user-id.");
            return;
        }

        var user = await _uow.Users.FindAsync(userId);
        if (user == null)
        {
            // user has changed his/her password/roles/stat/IsActive
            context.Fail("This token is expired. Please login again.");
        }

        var accessToken = context.SecurityToken as JsonWebToken;
        if (accessToken == null || string.IsNullOrWhiteSpace(accessToken.EncodedToken))
        {
            context.Fail("This token is not in our database.");
            return;
        }
    }
}