using ShopLand.Application.Products.Queries.GetProduct.Handler;
using ShopLand.Application.Products.Queries.GetProduct.Request;

namespace ShopLand.Test.Application.Products;

public class GetProductQueryHandlerTest
{
    async Task Act(GetProductQueryRequest request)
        => await _getUser.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_ProductNotFoundException_When_There_Is_No_Product_Found_With_This_Information()
    {
        // ARRANGE
        var request = new GetProductQueryRequest(Guid.NewGuid());
        _uow.Products.FindAsync(request.ProductId).Returns(default(Product));

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Get_Product_Information_On_Success()
    {
        // ARRANGE
        var request = new GetProductQueryRequest(Guid.NewGuid());
        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 5, "TestDescription", 10_000);
        product.AddCategory([Guid.NewGuid(), Guid.NewGuid()]);
        _uow.Products.FindAsync(request.ProductId).Returns(product);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }


    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IGetProductQueryHandler _getUser;
    public GetProductQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _getUser = new GetProductQueryHandler(_uow);
    }

    #endregion
}