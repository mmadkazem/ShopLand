namespace ShopLand.Application.Categories.Queries.GetAllCategory.Handler;

public interface IGetAllCategoryQueryHandler
{
    Task<IEnumerable<IResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default);
}
