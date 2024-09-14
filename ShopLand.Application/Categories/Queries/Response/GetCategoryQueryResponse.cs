namespace ShopLand.Application.Categories.Queries.Response;

public record GetCategoryQueryResponse(Guid Id, string Name) : IResponse;

public static class Extensions
{
    public static GetCategoryQueryResponse AsResponse(this Category category)
        => new(category.Id, category.CategoryName);
}