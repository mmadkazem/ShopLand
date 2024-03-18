namespace ShopLand.Test.Application.Categories;


public class CreateCategoryCommandHandlerTest
{
    async Task Act(CreateCategoryCommandRequest request)
        => await _createCategory.HandelAsync(request);

    [Fact]
    public async Task HandleAsync_Calls_UnitOfWork_CategoryRepository_Add_On_Success()
    {
        // ARRANGE
        var request = new CreateCategoryCommandRequest("TestName");
        var product = new Product();
        _categoryFactory.Create(request.Name).Returns(new Category(Guid.NewGuid(), "TestName"));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _uow.Categories.Received(1).Add(Arg.Any<Category>());
        await _uow.Received(1).SaveAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly ICategoryFactory _categoryFactory;

    private readonly ICreateCategoryCommandHandler _createCategory;
    public CreateCategoryCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _categoryFactory = Substitute.For<ICategoryFactory>();
        _createCategory = new CreateCategoryCommandHandler(_uow, _categoryFactory);
    }

    #endregion
}