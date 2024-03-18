namespace ShopLand.Test.Application.Categories;


public class UpdateCategoryCommandHandlerTest
{
    async Task Act(UpdateCategoryCommandRequest request)
        => await _updateCategory.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_CategoryNotFoundException_When_There_Is_No_Category_Found_With_This_Information()
    {
        // ARRANGE
        var request = new UpdateCategoryCommandRequest(Guid.NewGuid(), "TestName");
        _uow.Categories.FindAsync(request.Id).Returns(default(Category));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CategoryNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_CategoryRepository_Remove_Category_On_Success()
    {
        // ARRANGE
        var request = new UpdateCategoryCommandRequest(Guid.NewGuid(), "TestName");
        _uow.Categories.FindAsync(request.Id).Returns(new Category(request.Id, request.Name));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IUpdateCategoryCommandHandler _updateCategory;
    public UpdateCategoryCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _updateCategory = new UpdateCategoryCommandHandler(_uow);
    }

    #endregion
}