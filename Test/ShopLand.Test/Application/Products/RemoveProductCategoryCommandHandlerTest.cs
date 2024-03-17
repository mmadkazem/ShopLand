namespace ShopLand.Test.Application.Products;


public class RemoveProductCategoryCommandHandlerTest
{
    async Task Act(RemoveProductCategoryCommandRequest request)
        => await _removeProductCategory.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_ProductNotFoundException_When_There_Is_No_Product_Found_With_This_Information()
    {
        // ARRANGE
        var request = new RemoveProductCategoryCommandRequest(Guid.NewGuid(), Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(default(Product));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_RemoveProductCategory_On_Success()
    {
        // ARRANGE
        var request = new RemoveProductCategoryCommandRequest(Guid.NewGuid(), Guid.NewGuid());
        var product = new Product();
        product.AddCategory(request.CategoryId);
        product.AddCategory(Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(product);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IRemoveProductCategoryCommandHandler _removeProductCategory;
    public RemoveProductCategoryCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _removeProductCategory = new RemoveProductCategoryCommandHandler(_uow);
    }

    #endregion
}