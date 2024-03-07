namespace ShopLand.Application.Categories.Queries.GetAllCategory.Handler;

public class GetAllCategoryQueryHandler(IUnitOfWork uow) : IGetAllCategoryQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<GetAllCategoryQueryResponse>> HandelAsync
        (PageNumberRequest request)
    {
        var categories = await _uow.Categories.GetAll(request.Page);
        if (categories is null)
        {
            throw new CategoryNotFoundException();
        }

        return categories.Select(s => s.AsResponses()).ToList();
    }
}