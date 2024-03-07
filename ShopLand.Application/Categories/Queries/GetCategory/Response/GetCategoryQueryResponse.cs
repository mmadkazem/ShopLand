namespace ShopLand.Application.Categories.Queries.GetCategory.Response;

public record GetCategoryQueryResponse(Guid Id, string Name);

public static class Extensions
{
    public static GetCategoryQueryResponse AsResponse(this Category category)
        => new(category.Id, category.CategoryName);
}