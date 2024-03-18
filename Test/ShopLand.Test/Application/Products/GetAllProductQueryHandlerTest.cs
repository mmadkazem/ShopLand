namespace ShopLand.Test.Application.Products;


public class GetAllProductQueryHandlerTest
{
    async Task Act(PageNumberRequest request)
        => await _getAllProduct.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_Throw_ProductNotFoundException_When_There_Is_No_Product_Found_With_This_Information()
    {
        // ARRANGE
        var request = new PageNumberRequest(1);
        _uow.Products.GetAll(request).Returns([]);

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
        var request = new PageNumberRequest(1);
        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 5, "TestDescription", 10_000);
        _uow.Products.GetAll(request).Returns([product]);

        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
    }

    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IGetAllProductQueryHandler _getAllProduct;
    public GetAllProductQueryHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _getAllProduct = new GetAllProductQueryHandler(_uow);
    }

    #endregion
}