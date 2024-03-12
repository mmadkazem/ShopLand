namespace ShopLand.Test.Domain.ValueObject;

public class ProductValueObjectTest
{
    [Fact]
    public void ProductId_Throw_ProductIdEmptyException_When_There_Is_Product_ID_Cannot_Be_Empty()
    {
        // ACT and ASSERT
        Assert.Throws<ProductIdEmptyException>(() => new ProductId(Guid.Empty));
    }

    [Fact]
    public void Brand_Throw_BrandInvalidException_When_There_Is_Brand_Not_Valid()
    {
        // ACT and ASSERT
        Assert.Throws<BrandInvalidException>(() => new Brand(""));
        Assert.Throws<BrandInvalidException>(() => new Brand("Test"));
        Assert.Throws<BrandInvalidException>(() => new Brand("TestTestTestTestTestTest"));
    }

    [Fact]
    public void Inventory_Throw_InventoryInValidException_When_There_Is_Inventory_Not_Valid()
    {
        // ACT and ASSERT
        Assert.Throws<InventoryInValidException>(() => new Inventory(0));
        Assert.Throws<InventoryInValidException>(() => new Inventory(101));
    }

    [Fact]
    public void ProductDescription_Throw_ProductDescriptionInvalidException_When_There_Is_ProductDescription_Not_Valid()
    {
        // ACT and ASSERT
        Assert.Throws<ProductDescriptionInvalidException>(() => new ProductDescription(""));
        Assert.Throws<ProductDescriptionInvalidException>(() => new ProductDescription("Test"));
    }

    [Fact]
    public void ProductName_Throw_ProductNameInvalidException_When_Is_ProductName_Not_Valid()
    {
        // ACT and ASSERT
        Assert.Throws<ProductNameInvalidException>(() => new ProductName(""));
        Assert.Throws<ProductNameInvalidException>(() => new ProductName("Test"));
        Assert.Throws<ProductNameInvalidException>(() => new ProductName("TestTestTestTestTestTestTestTestTestTestTestTestTest"));
    }

    [Fact]
    public void ProductName_Throw_ProductNameInvalidException_When_Is_ProductPrice_Not_Valid()
    {
        // ACT and ASSERT
        Assert.Throws<ProductPriceInvalidException>(() => new ProductPrice(1_000));
    }
}

