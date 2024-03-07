namespace ShopLand.Application.Categories.Queries.GetAllCategory.Handler;

public interface IGetAllCategoryQueryHandler
{
    Task<IEnumerable<GetAllCategoryQueryResponse>> HandelAsync(PageNumberRequest request);
}
