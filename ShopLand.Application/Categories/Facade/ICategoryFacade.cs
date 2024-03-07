using ShopLand.Application.Categories.Queries.GetAllCategory.Handler;
using ShopLand.Application.Categories.Queries.GetCategory.Handler;

namespace ShopLand.Application.Categories.Facade;


public interface ICategoryFacade
{
    ICreateCategoryCommandHandler CreateCategory { get; }
    IUpdateCategoryCommandHandler UpdateCategory { get; }
    IRemoveCategoryCommandHandler RemoveCategory { get; }
    IGetAllCategoryQueryHandler GetAllCategory { get; }
    IGetCategoryQueryHandler GetCategory { get; }
}

public class CategoryFacade : ICategoryFacade
{

    public CategoryFacade(ICreateCategoryCommandHandler createCategory,
        IUpdateCategoryCommandHandler updateCategory,
        IRemoveCategoryCommandHandler removeCategory,
        IGetAllCategoryQueryHandler getAllCategory,
        IGetCategoryQueryHandler getCategory)
    {
        _createCategory = createCategory;
        _updateCategory = updateCategory;
        _removeCategory = removeCategory;
        _getAllCategory = getAllCategory;
        _getCategory = getCategory;
    }

    private readonly ICreateCategoryCommandHandler _createCategory;
    public ICreateCategoryCommandHandler CreateCategory
        => _createCategory;

    private readonly IUpdateCategoryCommandHandler _updateCategory;
    public IUpdateCategoryCommandHandler UpdateCategory
        => _updateCategory;

    private readonly IRemoveCategoryCommandHandler _removeCategory;
    public IRemoveCategoryCommandHandler RemoveCategory
        => _removeCategory;

    private readonly IGetAllCategoryQueryHandler _getAllCategory;
    public IGetAllCategoryQueryHandler GetAllCategory
        => _getAllCategory;

    private readonly IGetCategoryQueryHandler _getCategory;
    public IGetCategoryQueryHandler GetCategory
        => _getCategory;
}