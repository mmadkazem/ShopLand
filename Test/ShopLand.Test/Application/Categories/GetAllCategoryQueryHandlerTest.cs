using ShopLand.Application.Categories.Queries.GetAllCategory.Handler;

namespace ShopLand.Test.Application.Categories;


public class GetAllCategoryQueryHandlerTest
{
    async Task Act(PageNumberRequest request)
        => await _getAllCategory.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_CategoryNotFoundException_When_There_Is_No_Category_Found_With_This_Information()
    {
        // ARRANGE
        var request = new PageNumberRequest(1);
        _uow.Categories.GetAll(request).Returns([]);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CategoryNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Get_All_Category_Information_On_Success()
    {
        // ARRANGE
        var request = new PageNumberRequest(1);
        var category = new Category(Guid.NewGuid(), "TestName");
        _uow.Categories.GetAll(request).Returns([category]);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IGetAllCategoryQueryHandler _getAllCategory;
    public GetAllCategoryQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _getAllCategory = new GetAllCategoryQueryHandler(_uow);
    }

    #endregion
}