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

    [Fact]
    public async void Should_FideAsync_Order_By_UserId_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFideAsyncTest", b => b.EnableNullChecks(false))
                .Options;

        var userId = Guid.NewGuid();
        var order1 = new Order(Guid.NewGuid(), userId, Guid.NewGuid(),
            new Address("TestStreet", "TestCity", "TestState", "TestPostalCode"));
        var order2 = new Order(Guid.NewGuid(), userId, Guid.NewGuid(),
            new Address("TestStreet", "TestCity", "TestState", "TestPostalCode"));
        using var context = new DataBaseContext(dbOptions);
        var orderRepository = new OrderRepository(context);
        orderRepository.Add(order1);
        orderRepository.Add(order2);
        context.SaveChanges();

        //ACT
        var results = await orderRepository.GetByUserId(userId);

        //ASSERT

        Assert.Equal(2, results.Count());
        Assert.Contains(results, r => r.Id == order1.Id);
        Assert.Contains(results, r => r.Id == order2.Id);
        Assert.Contains(results, r => r.RequestPayId == order1.RequestPayId);
        Assert.Contains(results, r => r.RequestPayId == order2.RequestPayId);
        Assert.Contains(results, r => r.UserId == userId);
        Assert.DoesNotContain(results, r => r.UserId == Guid.NewGuid());
        Assert.DoesNotContain(results, r => r.Id == new OrderId(Guid.NewGuid()));
    }

    [Fact]
    public async void Should_FideAsync_Order_GetAll_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldGetAllTest", b => b.EnableNullChecks(false))
                .Options;

        var userId = Guid.NewGuid();
        var order1 = new Order(Guid.NewGuid(), userId, Guid.NewGuid(),
            new Address("TestStreet", "TestCity", "TestState", "TestPostalCode"));
        var order2 = new Order(Guid.NewGuid(), userId, Guid.NewGuid(),
            new Address("TestStreet", "TestCity", "TestState", "TestPostalCode"));
        using var context = new DataBaseContext(dbOptions);
        var orderRepository = new OrderRepository(context);
        orderRepository.Add(order1);
        orderRepository.Add(order2);
        context.SaveChanges();

        //ACT
        var results = await orderRepository.GetByUserId(userId);

        //ASSERT

        Assert.Equal(2, results.Count());
        Assert.Contains(results, r => r.Id == order1.Id);
        Assert.Contains(results, r => r.Id == order2.Id);
        Assert.Contains(results, r => r.RequestPayId == order1.RequestPayId);
        Assert.Contains(results, r => r.RequestPayId == order2.RequestPayId);
        Assert.Contains(results, r => r.UserId == order1.UserId);
        Assert.Contains(results, r => r.UserId == order2.UserId);
        Assert.DoesNotContain(results, r => r.UserId == Guid.NewGuid());
        Assert.DoesNotContain(results, r => r.RequestPayId == Guid.NewGuid());
        Assert.DoesNotContain(results, r => r.Id == new OrderId(Guid.NewGuid()));
    }

}