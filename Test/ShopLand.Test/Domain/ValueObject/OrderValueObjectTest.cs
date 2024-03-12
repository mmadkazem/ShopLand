namespace ShopLand.Test.Domain.ValueObject;


public class OrderValueObjectTest
{

    [Fact]
    public void OrderId_Throw_ProductIdEmptyException_When_There_Is_Order_ID_Cannot_Be_Empty()
    {
        // ACT and ASSERT
        Assert.Throws<OrderIdEmptyException>(() => new OrderId(Guid.Empty));
    }

    [Fact]
    public void Address_Throw_AddressInvalidException_When_There_Is_Address_Not_Valid()
    {
        // ACT and ASSERT
        Assert.Throws<AddressInvalidException>(() => Address.Create(null));
        Assert.Throws<AddressInvalidException>(() => Address.Create("  "));
    }
}