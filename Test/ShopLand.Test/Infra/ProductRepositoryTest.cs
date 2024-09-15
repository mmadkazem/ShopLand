namespace ShopLand.Test.Infra;


public class ProductRepositoryTest
{
    [Fact]
    public void Should_Add_Product_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAddProductTest", b => b.EnableNullChecks(false))
                .Options;

        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 5, "TestDescription", 10_000);

        using var context = new DataBaseContext(dbOptions);
        var productRepository = new ProductRepository(context);

        //ACT
        productRepository.Add(product);
        context.SaveChanges();

        //ASSERT
        var result = context.Products.Where(p => p.Id == product.Id).FirstOrDefault();

        Assert.Equal(product.Id, result?.Id);
        Assert.Equal(product.Brand, result?.Brand);
        Assert.Equal(product.ProductName, result?.ProductName);
        Assert.Equal(product.Description, result?.Description);
        Assert.Equal(product.Price, result?.Price);
        Assert.Equal(product.Inventory, result?.Inventory);
    }

    [Fact]
    public async void Should_FideAsync_Product_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFideAsyncTest", b => b.EnableNullChecks(false))
                .Options;

        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 5, "TestDescription", 10_000);

        using var context = new DataBaseContext(dbOptions);
        var productRepository = new ProductRepository(context);
        productRepository.Add(product);
        context.SaveChanges();

        //ACT
        var result = await productRepository.FindAsync(product.Id);

        //ASSERT

        Assert.Equal(product.Id, result?.Id);
        Assert.Equal(product.Brand, result?.Brand);
        Assert.Equal(product.ProductName, result?.ProductName);
        Assert.Equal(product.Description, result?.Description);
        Assert.Equal(product.Price, result?.Price);
        Assert.Equal(product.Inventory, result?.Inventory);
    }

    [Fact]
    public async void Should_FideAsync_By_ProductName_User_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFindAsyncByProductNameTest", b => b.EnableNullChecks(false))
                .Options;

        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 5, "TestDescription", 10_000);

        using var context = new DataBaseContext(dbOptions);
        var productRepository = new ProductRepository(context);
        productRepository.Add(product);
        context.SaveChanges();

        //ACT
        var result = await productRepository.FindAsyncByProductName(product.ProductName);

        //ASSERT

        Assert.Equal(product.Id, result?.Id);
        Assert.Equal(product.Brand, result?.Brand);
        Assert.Equal(product.ProductName, result?.ProductName);
        Assert.Equal(product.Description, result?.Description);
        Assert.Equal(product.Price, result?.Price);
        Assert.Equal(product.Inventory, result?.Inventory);
    }

    [Fact]
    public async void Should_Any_Product_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAnyTest", b => b.EnableNullChecks(false))
                .Options;

        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 5, "TestDescription", 10_000);

        using var context = new DataBaseContext(dbOptions);
        var productRepository = new ProductRepository(context);
        productRepository.Add(product);
        context.SaveChanges();

        //ACT
        var result1 = await productRepository.Any(product.Id);
        var result2 = await productRepository.Any(Guid.NewGuid());

        //ASSERT

        Assert.True(result1);
        Assert.False(result2);
    }

    [Fact]
    public async void Should_Remove_ProductCategory_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldRemoveProductCategoryTest", b => b.EnableNullChecks(false))
                .Options;

        var product1 = new Product();
        var product2 = new Product();
        var category = Guid.NewGuid();
        product1.AddCategory(category);
        product2.AddCategory(category);

        using var context = new DataBaseContext(dbOptions);
        var productRepository = new ProductRepository(context);
        productRepository.Add(product1);
        productRepository.Add(product2);
        context.SaveChanges();

        //ACT
        await productRepository.RemoveProductCategories(category);

        //ASSERT
        var result1 = await productRepository.FindAsync(product1.Id);
        var result2 = await productRepository.FindAsync(product2.Id);
        var productCategories1 = result1.ProductCategories;
        var productCategories2 = result1.ProductCategories;

        Assert.Contains(productCategories1, p => p.Category == category);
        Assert.Contains(productCategories2, p => p.Category == category);
    }

    [Fact]
    public async void Should_Remove_Product_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldRemoveProductTest", b => b.EnableNullChecks(false))
                .Options;

        var product = new Product(Guid.NewGuid(), "TestBrand", "TestName", 5, "TestDescription", 10_000);

        using var context = new DataBaseContext(dbOptions);
        var productRepository = new ProductRepository(context);
        productRepository.Add(product);
        context.SaveChanges();

        //ACT
        productRepository.Remove(product);
        context.SaveChanges();

        //ASSERT
        var result = await productRepository.Any(product.Id);
        Assert.False(result);
    }
}