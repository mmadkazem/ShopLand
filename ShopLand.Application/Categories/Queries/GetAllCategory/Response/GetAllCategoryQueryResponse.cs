namespace ShopLand.Application.Categories.Queries.GetAllCategory.Response;

public record GetAllCategoryQueryResponse
(
    Guid Id,
    string Name
);

public static class Extensions
{
    public static GetAllCategoryQueryResponse AsResponses(this Category category)
        => new(category.Id, category.CategoryName);
}