namespace ShopLand.Api.Common;

public static class IdentityExtension
{
    public static Guid UserId(this ClaimsPrincipal user)
    {
        try
        {
            if (user.Identity.IsAuthenticated)
            {
                var sub = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var res = sub.ToUserId();
                return new Guid(res);
            }
            else
                return Guid.Empty;
        }
        catch (Exception)
        {
            return Guid.Empty;
        }
    }

    public static string ToUserId(this string str)
    {
        return str.Replace(" ", "").Replace("Value", "")
            .Replace("=", "").Replace("UserId", "");
    }

    public static string RefreshTokenSerial(this ClaimsPrincipal user)
    {
        if (user.Identity.IsAuthenticated)
        {
            return user.FindFirst(ClaimTypes.SerialNumber)?.Value;
        }
        return string.Empty;
    }
}