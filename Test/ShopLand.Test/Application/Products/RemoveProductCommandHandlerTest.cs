using ShopLand.Application.Products.Commands.RemoveProduct.Handler;
using ShopLand.Application.Products.Commands.RemoveProduct.Request;
using ShopLand.Application.Products.Events.ProductRemoved;

namespace ShopLand.Test.Application.Products;

public class RemoveProductCommandHandlerTest
{
    async Task Act(RemoveProductCommandRequest request)
        => await _removeProduct.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_ProductNotFoundException_When_There_Is_No_Product_Found_With_This_Information()
    {
        // ARRANGE
        var request = new RemoveProductCommandRequest(Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(default(Product));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_ProductRepository_Remove_Product_On_Success()
    {
        // ARRANGE
        var request = new RemoveProductCommandRequest(Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(new Product());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _uow.Products.Received(1).Remove(Arg.Any<Product>());
        await _uow.Received(1).SaveChangeAsync();
    }

    [Fact]
    public async Task HandleAsync_Calls_Removed_Product_Event_On_Success()
    {
        // ARRANGE
        var request = new RemoveProductCommandRequest(Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(new Product());

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        await _productRemoved.Received(1).HandelAsync(Arg.Any<Guid>());
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IRemoveProductCommandHandler _removeProduct;
    private readonly IProductRemovedEventHandler _productRemoved;
    public RemoveProductCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _productRemoved = Substitute.For<IProductRemovedEventHandler>();
        _removeProduct = new RemoveProductCommandHandler(_uow, _productRemoved);
    }

    #endregion
}