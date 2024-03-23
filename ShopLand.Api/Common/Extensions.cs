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
                var res = sub.Replace(" ", "").Replace("Value", "").Replace("=", "").Replace("UserId", "");
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
}