namespace ShopLand.Share.Common;

public static class StringUtil
{
    public static bool IsValidLength(string value, short min, short max)
    {
        return value.Length > max && value.Length < min;
    }
}