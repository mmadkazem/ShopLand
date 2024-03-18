namespace ShopLand.Test.Application.Categories;


public class GetCategoryQueryHandlerTest
{
    async Task Act(GetCategoryQueryRequest request)
        => await _getCategory.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_CategoryNotFoundException_When_There_Is_No_Category_Found_With_This_Information()
    {
        // ARRANGE
        var request = new GetCategoryQueryRequest(Guid.NewGuid());
        _uow.Categories.FindAsync(request.Id).Returns(default(Category));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CategoryNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Get_Category_Information_On_Success()
    {
        // ARRANGE
        var request = new GetCategoryQueryRequest(Guid.NewGuid());
        var category = new Category(Guid.NewGuid(), "TestName");
        _uow.Categories.FindAsync(request.Id).Returns(category);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IGetCategoryQueryHandler _getCategory;
    public GetCategoryQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _getCategory = new GetCategoryQueryHandler(_uow);
    }

    #endregion
}