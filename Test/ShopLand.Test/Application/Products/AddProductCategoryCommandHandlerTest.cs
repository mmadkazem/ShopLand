using ShopLand.Application.Categories.Exceptions;

namespace ShopLand.Test.Application.Products;

public class AddProductCategoryCommandHandlerTest
{
    async Task Act(AddProductCategoryCommandRequest request)
        => await _addProductCategory.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_ProductNotFoundException_When_There_Is_No_Product_Found_With_This_Information()
    {
        // ARRANGE
        var request = new AddProductCategoryCommandRequest(Guid.NewGuid(), Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(default(Product));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductNotFoundException>();
    }

    [Fact]
    public async Task HandelAsync_CategoryNotFoundException_When_There_Is_No_Category_Found_With_This_Information()
    {
        // ARRANGE
        var request = new AddProductCategoryCommandRequest(Guid.NewGuid(), Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(new Product());
        _uow.Categories.Any(request.CategoryId).Returns(false);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CategoryNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_AddProductCategory_On_Success()
    {
        // ARRANGE
        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 5, "TestDescription", 10_000);
        var request = new AddProductCategoryCommandRequest(Guid.NewGuid(), Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(product);
        _uow.Categories.Any(request.CategoryId).Returns(true);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveChangeAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IAddProductCategoryCommandHandler _addProductCategory;
    public AddProductCategoryCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _addProductCategory = new AddProductCategoryCommandHandler(_uow);
    }

    #endregion
}