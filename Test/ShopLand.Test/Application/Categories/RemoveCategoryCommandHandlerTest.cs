namespace ShopLand.Test.Application.Categories;


public class RemoveCategoryCommandHandlerTest
{
    async Task Act(RemoveCategoryCommandRequest request)
        => await _removeCategory.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_CategoryNotFoundException_When_There_Is_No_Category_Found_With_This_Information()
    {
        // ARRANGE
        var request = new RemoveCategoryCommandRequest(Guid.NewGuid());
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
        var request = new RemoveCategoryCommandRequest(Guid.NewGuid());
        _uow.Categories.FindAsync(request.Id).Returns(new Category());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _uow.Categories.Received(1).Remove(Arg.Any<Category>());
        await _uow.Received(1).SaveAsync();
    }

    [Fact]
    public async Task HandleAsync_Calls_Removed_Product_Event_On_Success()
    {
        // ARRANGE
        var request = new RemoveCategoryCommandRequest(Guid.NewGuid());
        _uow.Categories.FindAsync(request.Id).Returns(new Category());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _removedCategory.Received(1).HandelAsync(Arg.Any<Guid>());
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IRemovedCategoryEventHandler _removedCategory;
    private readonly IRemoveCategoryCommandHandler _removeCategory;
    public RemoveCategoryCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _removedCategory = Substitute.For<IRemovedCategoryEventHandler>();
        _removeCategory = new RemoveCategoryCommandHandler(_uow, _removedCategory);
    }

    #endregion
}