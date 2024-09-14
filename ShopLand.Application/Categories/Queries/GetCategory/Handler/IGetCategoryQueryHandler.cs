namespace ShopLand.Application.Categories.Queries.GetCategory.Handler;

public interface IGetCategoryQueryHandler
{
    Task<GetCategoryQueryResponse> HandelAsync(GetCategoryQueryRequest request, CancellationToken token = default);
}