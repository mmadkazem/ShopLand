namespace ShopLand.Application.Common;

public record PageNumberRequest(int Page)
{
    public static implicit operator PageNumberRequest(int Page)
        => new(Page);

    public static implicit operator int(PageNumberRequest request)
    => request.Page;
};