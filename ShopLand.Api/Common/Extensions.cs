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

    public static List<string> Roles(this ClaimsPrincipal user)
    {
        if (user.Identity.IsAuthenticated)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;
            return claimsIdentity.Claims.Where(x => x.Type == ClaimTypes.Role)
                                            .Select(x => x.Value)
                                            .ToList();
        }
        else
            return null;
    }

    public static string FullName(this ClaimsPrincipal user)
    {
        return user.Identity.Name;
    }
}