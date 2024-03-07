namespace ShopLand.Share.Hashing;

public static class Hash
{
    public static string GetSha256Hash(string input)
    {
        using var hashAlgorithm = SHA256.Create();
        var byteValue = Encoding.UTF8.GetBytes(input);
        var byteHash = hashAlgorithm.ComputeHash(byteValue);
        return Convert.ToBase64String(byteHash);
    }
}