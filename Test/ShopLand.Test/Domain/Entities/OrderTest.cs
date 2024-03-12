namespace ShopLand.Test.Domain.Entities;

public class OrderTest
{

    [Fact]
    public void AddOrderDetail_Throw_OrderDetailAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
    {
        //ARRANGE
        var order = GetOrder();
        var productId = Guid.NewGuid();
        order.AddOrderDetail(productId, 5, 10_000);

        //ACT
        var exception = Record.Exception(() => order.AddOrderDetail(productId, 5, 10_000));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<OrderDetailAlreadyExistsException>();
    }

    [Fact]
    public void UpdateOrderState_Throw_OrderStateAlreadyExistException_When_There_Is_Already_Item_With_The_Same_Name()
    {
        //ARRANGE
        var order = GetOrder();
        order.UpdateOrderState(OrderState.Delivered);

        //ACT
        var exception = Record.Exception(() => order.UpdateOrderState(OrderState.Delivered));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<OrderStateAlreadyExistException>();
    }
    #region ARRANGE

    private Order GetOrder()
        => _factory.Create(Guid.NewGuid(), Guid.NewGuid(), "TestStreet", "TestCity", "TestState", "TestPostalCode");


    private readonly IOrderFactory _factory;

    public OrderTest()
    {
        _factory = new OrderFactory();
    }

    #endregion
}