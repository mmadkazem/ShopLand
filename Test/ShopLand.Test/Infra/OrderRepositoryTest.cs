namespace ShopLand.Test.Infra;

public class OrderRepositoryTest
{
    [Fact]
    public void Should_Add_Order_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAddOrderTest", b => b.EnableNullChecks(false))
                .Options;

        var order = new Order(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            new Address("TestStreet", "TestCity", "TestState", "TestPostalCode"));

        using var context = new DataBaseContext(dbOptions);
        var orderRepository = new OrderRepository(context);

        //ACT
        orderRepository.Add(order);
        context.SaveChanges();

        //ASSERT
        var result = context.Orders.Where(p => p.Id == order.Id).FirstOrDefault();

        Assert.Equal(order.Id, result?.Id);
        Assert.Equal(order.UserId, result?.UserId);
        Assert.Equal(order.RequestPayId, result?.RequestPayId);
        Assert.Equal(order.Address.ToString(), result?.Address.ToString());
    }

    [Fact]
    public async void Should_FideAsync_Order_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFideAsyncTest", b => b.EnableNullChecks(false))
                .Options;

        var order = new Order(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            new Address("TestStreet", "TestCity", "TestState", "TestPostalCode"));

        using var context = new DataBaseContext(dbOptions);
        var orderRepository = new OrderRepository(context);
        orderRepository.Add(order);
        context.SaveChanges();

        //ACT
        var result = await orderRepository.FindAsync(order.Id);

        //ASSERT

        Assert.Equal(order.Id, result?.Id);
        Assert.Equal(order.UserId, result?.UserId);
        Assert.Equal(order.RequestPayId, result?.RequestPayId);
        Assert.Equal(order.Address.ToString(), result?.Address.ToString());
    }

}