namespace ShopLand.Test.Domain.Entities;


public class ProductTest
{
    [Fact]
    public void AddProductCategory_Throw_ProductCategoryAlreadyExistsException_When_There_Is_Category_Already_Exists_Before()
    {
        //ARRANGE
        var product = GetProduct();
        var category = Guid.NewGuid();
        product.AddCategory(category);

        //ACT
        var exception = Record.Exception(() => product.AddCategory(category));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductCategoryAlreadyExistsException>();
    }

    [Fact]
    public void RemoveProductCategory_Throws_ProductCategoryOneRoleException_When_There_It_Has_A_Category_Cannot_Be_Deleted()
    {
        //ARRANGE
        var product = GetProduct();
        var category = Guid.NewGuid();
        product.AddCategory(category);

        //ACT
        var exception = Record.Exception(() => product.RemoveCategory(category));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductCategoryOneRoleException>();

    }

    [Fact]
    public void UpdateProductCategory_Throw_ProductCategoryNotFoundException_When_There_Category_Not_Found()
    {
        //ARRANGE
        var product = GetProduct();
        var category = Guid.NewGuid();
        product.AddCategory(category);

        //ACT
        var exception = Record.Exception(() => product.UpdateCategory(Guid.NewGuid(), Guid.NewGuid()));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductCategoryNotFoundException>();
    }

    [Fact]
    public void GetRole_Throws_UserInRoleNotFoundException_When_There_Role_Not_Found()
    {
        //ARRANGE
        var product = GetProduct();
        var category = Guid.NewGuid();
        product.AddCategory(category);

        //ACT
        var exception = Record.Exception(() => product.GetCategory(Guid.NewGuid()));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ProductCategoryNotFoundException>();

    }

    #region ARRANGE

    private Product GetProduct()
        => _factory.Create("TestBrand", "TestName", "TestDescription", 10_000, 5);


    private readonly IProductFactory _factory;

    public ProductTest()
    {
        _factory = new ProductFactory();
    }

    #endregion
}