using ShopLand.Application.Products.Commands.UpdateProductCategory.Handler;
using ShopLand.Application.Products.Commands.UpdateProductCategory.Request;

namespace ShopLand.Test.Application.Products;

public class UpdateProductCategoryCommandHandlerTest
{
    async Task Act(UpdateProductCategoryCommandRequest request)
        => await _updateProductCategory.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_ProductNotFoundException_When_There_Is_No_Product_Found_With_This_Information()
    {
        // ARRANGE
        var request = new UpdateProductCategoryCommandRequest(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(default(Product));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductNotFoundException>();
    }

    [Fact]
    public async Task HandelAsync_Throw_CategoryNotFoundException_When_There_Is_No_Category_Found_With_This_Information()
    {
        // ARRANGE
        var request = new UpdateProductCategoryCommandRequest(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(new Product());
        _uow.Categories.Any(request.newCategory).Returns(false);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CategoryNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Update_ProductCategory_On_Success()
    {
        // ARRANGE
        var request = new UpdateProductCategoryCommandRequest(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        var product = new Product();
        product.AddCategory(request.oldCategory);
        product.AddCategory(Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(product);
        _uow.Categories.Any(request.newCategory).Returns(true);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IUpdateProductCategoryCommandHandler _updateProductCategory;
    public UpdateProductCategoryCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _updateProductCategory = new UpdateProductCategoryCommandHandler(_uow);
    }

    #endregion
}