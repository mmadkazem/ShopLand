namespace ShopLand.Application.Categories.Queries.GetCategory.Handler;

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