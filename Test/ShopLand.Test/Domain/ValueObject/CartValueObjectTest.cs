namespace ShopLand.Test.Domain.ValueObject;

public class CartValueObjectTest
{

    [Fact]
    public void CartId_Throw_CartIdEmptyException_When_There_Is_Cart_ID_Cannot_Be_Empty()
    {
        // ACT and ASSERT
        Assert.Throws<CartIdEmptyException>(() => new CartId(Guid.Empty));
    }

    [Fact]
    public void Count_Throw_CountZeroValueException_When_There_Is_It_Should_Not_Be_Zero()
    {
        // ACT and ASSERT
        Assert.Throws<CountZeroValueException>(() => new Count(0));
    }

    [Fact]
    public void Count_Add_Throw_CountMoreInventoryException_When_There_Is_More_Than_Inventory_Count_Not_Valid()
    {
        // ARRANGE
        Count count = new(2);

        // ACT
        var exception = Record.Exception(() => count.Add(1));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CountMoreInventoryException>();
    }

    [Fact]
    public void Count_Low_Throw_CountLessZeroException_When_There_Is_Value_Is_Less_Than_Zero()
    {
        // ARRANGE
        Count count = new(1);

        // ACT
        var exception = Record.Exception(() => count.Low(2));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CountLessZeroException>();
    }

    [Fact]
    public void IsValid_Throw_CountLessZeroException_When_There_Is_More_Than_Inventory_Count_Not_Valid()
    {
        // ARRANGE
        Count count = new(2);

        // ACT
        var exception = Record.Exception(() => count.IsValid(1));

        // ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CountMoreInventoryException>();
    }
}