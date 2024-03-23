namespace ShopLand.Infrastructure.Services.JwtToken;

public class TokenFactoryService : ITokenFactoryService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IConfiguration _configuration;

    public TokenFactoryService(IUserRepository userRepository,
            IConfiguration configuration,
            IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _roleRepository = roleRepository;
    }

    public async Task<JwtTokensData> CreateJwtTokensAsync(User user)
    {
        var (accessToken, accessTokenExpireTime) = await createAccessTokenAsync(user);
        var (refreshTokenValue, refreshTokenSerial, refreshTokenExpireTime) = createRefreshToken();
        return new JwtTokensData(accessToken, accessTokenExpireTime,
                refreshTokenValue, refreshTokenSerial, refreshTokenExpireTime);
    }

    private (string RefreshTokenValue, string RefreshTokenSerial, DateTimeOffset RefreshTokenExpireTime) createRefreshToken()
    {
        var refreshTokenSerial = SecurityService.CreateCryptographicallySecureGuid();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["BearerTokens:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var Issuer = _configuration["BearerTokens:Issuer"];
        var ExpireTime = now.AddMinutes(int.Parse(_configuration["BearerTokens:RefreshTokenExpirationMinutes"]));

        var claims = new List<Claim>
        {
            // Unique Id for all Jwt tokes
            new Claim(JwtRegisteredClaimNames.Jti, SecurityService.CreateCryptographicallySecureGuid(), ClaimValueTypes.String, Issuer),
            // Issuer
            new Claim(JwtRegisteredClaimNames.Iss, Issuer, ClaimValueTypes.String, Issuer),
            // Issued at
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, Issuer),
            // for invalidation
            new Claim(ClaimTypes.SerialNumber, refreshTokenSerial, ClaimValueTypes.String, Issuer)
        };

        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: _configuration["BearerTokens:Audience"],
            claims: claims,
            notBefore: now,
            expires: ExpireTime,
            signingCredentials: creds);
        var refreshTokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return (refreshTokenValue, refreshTokenSerial, ExpireTime);
    }
    private async Task<(string AccessTokenValue, DateTimeOffset AccessTokenExpireTime)> createAccessTokenAsync(User user)
    {
        var _issuer = _configuration["BearerTokens:Issuer"];
        var _audience = _configuration["BearerTokens:Audience"];
        var _accessTokenExpirationMinutes = int.Parse(_configuration["BearerTokens:AccessTokenExpirationMinutes"]);
        var claims = new List<Claim>
        {
            // Issuer
            new Claim(JwtRegisteredClaimNames.Iss, _issuer, ClaimValueTypes.String, _issuer),
            // Issued at
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _issuer),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String, _issuer),
            new Claim(ClaimTypes.Email, user.Email.Value, ClaimValueTypes.String, _issuer),
            new Claim(ClaimTypes.Name, user.FullName.ToString(), ClaimValueTypes.String, _issuer),
            // custom data
            new Claim(ClaimTypes.UserData, user.Id.ToString(), ClaimValueTypes.String, _issuer)
        };

        // add roles
        var users = await _userRepository.FindAsync(user.Id);
        foreach (var userRole in users.UsedInRoles)
        {
            var role = await _roleRepository.FindAsync(userRole.Role);
            claims.Add(new Claim(ClaimTypes.Role, role.Name, ClaimValueTypes.String, _issuer));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["BearerTokens:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_accessTokenExpirationMinutes),
            signingCredentials: creds);
        return (new JwtSecurityTokenHandler().WriteToken(token).ToString(), now.AddMinutes(_accessTokenExpirationMinutes));
    }
}
