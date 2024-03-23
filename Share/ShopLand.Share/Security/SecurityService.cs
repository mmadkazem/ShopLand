namespace ShopLand.Share.Security;

public static class SecurityService
{
    public static string GetSha256Hash(string input)
    {
        using var hashAlgorithm = SHA256.Create();
        var byteValue = Encoding.UTF8.GetBytes(input);
        var byteHash = hashAlgorithm.ComputeHash(byteValue);
        return Convert.ToBase64String(byteHash);
    }

    public static string CreateCryptographicallySecureGuid()
    {
        var _rand = RandomNumberGenerator.Create();
        var bytes = new byte[16];
        _rand.GetBytes(bytes);
        return new Guid(bytes).ToString().Replace("-", "");
    }

}