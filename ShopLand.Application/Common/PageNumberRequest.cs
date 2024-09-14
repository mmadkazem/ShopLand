namespace ShopLand.Application.Common;

public readonly record struct PageNumberRequest(int Page)
{
    public static implicit operator PageNumberRequest(int Page)
        => new(Page);

    public static implicit operator int(PageNumberRequest request)
        => request.Page;
};