using ShopLand.Application.Categories.Queries.GetCategory.Request;
using ShopLand.Application.Categories.Queries.GetCategory.Response;

namespace ShopLand.Application.Categories.Queries.GetCategory.Handler;

public interface IGetCategoryQueryHandler
{
    Task<GetCategoryQueryResponse> HandelAsync(GetCategoryQueryRequest request);
}

public class GetCategoryQueryHandler(IUnitOfWork uow) : IGetCategoryQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<GetCategoryQueryResponse> HandelAsync(GetCategoryQueryRequest request)
    {
        var category = await _uow.Categories.FindAsync(request.Id);
        if (category is null)
        {
            throw new CategoryNotFoundException();
        }

        return category.AsResponse();
    }
}