namespace ShopLand.Application.Categories.Queries.GetCategory.Handler;

public interface IGetCategoryQueryHandler
{
    Task<IResponse> HandelAsync(GetCategoryQueryRequest request, CancellationToken token = default);
}