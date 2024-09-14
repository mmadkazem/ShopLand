using ShopLand.Application.Products.Commands.UpdateProduct.Handler;
using ShopLand.Application.Products.Commands.UpdateProduct.Request;

namespace ShopLand.Test.Application.Products;

public class UpdateProductCommandHandlerTest
{
    async Task Act(UpdateProductCommandRequest request)
        => await _updateProduct.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_ProductNotFoundException_When_There_Is_No_Product_Found_With_This_Information()
    {
        // ARRANGE
        var request = new UpdateProductCommandRequest(Guid.NewGuid(), "TestName", "TestBrand", "TestDescription", 10, 10_000);
        _uow.Products.FindAsync(request.ProductId).Returns(default(Product));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Update_Product_On_Success()
    {
        // ARRANGE
        var request = new UpdateProductCommandRequest(Guid.NewGuid(), "TestName", "TestBrand", "TestDescription", 10, 10_000);
        _uow.Products.FindAsync(request.ProductId).Returns(new Product());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _uow.Received(1).SaveChangeAsync();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IUpdateProductCommandHandler _updateProduct;
    public UpdateProductCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _updateProduct = new UpdateProductCommandHandler(_uow);
    }

    #endregion
}