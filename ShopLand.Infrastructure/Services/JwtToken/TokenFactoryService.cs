namespace ShopLand.Infrastructure.Services.JwtToken;

public class TokenFactoryService(IUserRepository userRepository,
                                IOptions<AppOptions> options,
                                IRoleRepository roleRepository)
    : ITokenFactoryService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IRoleRepository _roleRepository = roleRepository;
    private readonly BearerTokensOption _bearerTokenOptions = options.Value.BearerTokensOption;
    private readonly RefreshTokenOption _refreshTokenOption = options.Value.RefreshTokenOption;

    public async Task<JwtTokensData> CreateJwtTokensAsync(User user)
    {
        var (accessToken, accessTokenExpireTime) = await createAccessTokenAsync(user);
        var (refreshTokenValue, refreshTokenSerial, refreshTokenExpireTime) = createRefreshToken(user);
        return new JwtTokensData(accessToken, accessTokenExpireTime,
                refreshTokenValue, refreshTokenSerial, refreshTokenExpireTime);
    }

    private (string RefreshTokenValue, string RefreshTokenSerial, DateTimeOffset RefreshTokenExpireTime) createRefreshToken(User user)
    {
        var refreshTokenSerial = SecurityService.CreateCryptographicallySecureGuid();

        var claims = new List<Claim>
        {
            // Unique Id for all Jwt tokes
            new(JwtRegisteredClaimNames.Jti, SecurityService.CreateCryptographicallySecureGuid(), ClaimValueTypes.String, _refreshTokenOption.Issuer),
            // Issuer
            new(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String, _refreshTokenOption.Issuer),
            new(JwtRegisteredClaimNames.Iss, _refreshTokenOption.Issuer, ClaimValueTypes.String, _refreshTokenOption.Issuer),
            // Issued at
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _refreshTokenOption.Issuer),
            // for invalidation
            new(ClaimTypes.SerialNumber, refreshTokenSerial, ClaimValueTypes.String, _refreshTokenOption.Issuer)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_refreshTokenOption.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var ExpireTime = now.AddMinutes(_refreshTokenOption.RefreshTokenExpirationMinutes);


        var token = new JwtSecurityToken(
            issuer: _refreshTokenOption.Issuer,
            audience: _refreshTokenOption.Audience,
            claims: claims,
            notBefore: now,
            expires: ExpireTime,
            signingCredentials: creds);
        var refreshTokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return (refreshTokenValue, refreshTokenSerial, ExpireTime);
    }
    private async Task<(string AccessTokenValue, DateTimeOffset AccessTokenExpireTime)> createAccessTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            // Issuer
            new(JwtRegisteredClaimNames.Iss, _bearerTokenOptions.Issuer, ClaimValueTypes.String, _bearerTokenOptions.Issuer),
            // Issued at
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _bearerTokenOptions.Issuer),
            new(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String, _bearerTokenOptions.Issuer),
            new(ClaimTypes.Email, user.Email.Value, ClaimValueTypes.String, _bearerTokenOptions.Issuer),
            new(ClaimTypes.Name, user.FullName.ToString(), ClaimValueTypes.String, _bearerTokenOptions.Issuer),
            // custom data
            new(ClaimTypes.UserData, user.Id.ToString(), ClaimValueTypes.String, _bearerTokenOptions.Issuer)
        };

        // add roles
        var users = await _userRepository.FindAsync(user.Id);
        foreach (var userRole in users.UsedInRoles)
        {
            var role = await _roleRepository.FindAsync(userRole.Role);
            claims.Add(new Claim(ClaimTypes.Role, role.Name, ClaimValueTypes.String, _bearerTokenOptions.Issuer));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_bearerTokenOptions.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken
        (
            issuer: _bearerTokenOptions.Issuer,
            audience: _bearerTokenOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(_bearerTokenOptions.AccessTokenExpirationMinutes),
            signingCredentials: creds
        );

        return (new JwtSecurityTokenHandler().WriteToken(token).ToString(), DateTime.Now.AddMinutes(_bearerTokenOptions.AccessTokenExpirationMinutes));
    }
}
