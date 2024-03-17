namespace ShopLand.Test.Application.Products;

public class CreateProductCommandHandlerTest
{
    async Task Act(CreateProductCommandRequest request)
        => await _createProduct.HandelAsync(request);

    [Fact]
    public async Task HandelAsync_CategoryNotFoundException_When_There_Is_No_Category_Found_With_This_Information()
    {
        // ARRANGE
        var request = new CreateProductCommandRequest("TestName", "TestBrand", "TestDescription", 5, 10_000, [Guid.NewGuid()]);
        var product = new Product();
        _productFactory.Create(request.Brand, request.Name, request.Description, request.Price, request.Inventory).Returns(product);
        _uow.Products.Any(Guid.NewGuid()).Returns(false);
        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CategoryNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_UnitOfWork_ProductRepository_Add_On_Success()
    {
        // ARRANGE
        var request = new CreateProductCommandRequest("TestName", "TestBrand", "TestDescription", 5, 10_000, [Guid.NewGuid()]);
        var product = new Product();
        _productFactory.Create(request.Brand, request.Name, request.Description, request.Price, request.Inventory).Returns(product);
        _uow.Categories.Any(request.Categories.FirstOrDefault()).Returns(true);
        // ACT
        var exception = await Record.ExceptionAsync(() => Act(request));

        // ASSERT
        exception.ShouldBeNull();
        _uow.Products.Received(1).Add(Arg.Any<Product>());
        await _uow.Received(1).SaveAsync();
    }
    #region ARRANGE

    private readonly IUnitOfWork _uow;
    private readonly IProductFactory _productFactory;

    private readonly ICreateProductCommandHandler _createProduct;
    public CreateProductCommandHandlerTest()
    {
        _uow = Substitute.For<IUnitOfWork>();
        _productFactory = Substitute.For<IProductFactory>();
        _createProduct = new CreateProductCommandHandler(_uow, _productFactory);
    }

    #endregion
}