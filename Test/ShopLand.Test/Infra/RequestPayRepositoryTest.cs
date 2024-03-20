namespace ShopLand.Test.Infra;

public class RequestPayRepositoryTest
{
    [Fact]
    public void Should_Add_RequestPay_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAddRequestPayTest", b => b.EnableNullChecks(false))
                .Options;

        var requestPay = new RequestPay(Guid.NewGuid(), Guid.NewGuid(), 10_000);

        using var context = new DataBaseContext(dbOptions);
        var requestPayRepository = new RequestPayRepository(context);

        //ACT
        requestPayRepository.Add(requestPay);
        context.SaveChanges();

        //ASSERT
        var result = context.requestPays.Where(p => p.Id == requestPay.Id).FirstOrDefault();

        Assert.Equal(requestPay.Id, result?.Id);
        Assert.Equal(requestPay.UserId, result?.UserId);
        Assert.Equal(requestPay.Amount, result?.Amount);
    }

    [Fact]
    public async void Should_FideAsync_RequestPay_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFideAsyncTest", b => b.EnableNullChecks(false))
                .Options;

        var requestPay = new RequestPay(Guid.NewGuid(), Guid.NewGuid(), 10_000);

        using var context = new DataBaseContext(dbOptions);
        var requestPayRepository = new RequestPayRepository(context);
        requestPayRepository.Add(requestPay);
        context.SaveChanges();

        //ACT
        var result = await requestPayRepository.FindAsync(requestPay.Id);

        //ASSERT

        Assert.Equal(requestPay.Id, result?.Id);
        Assert.Equal(requestPay.UserId, result?.UserId);
        Assert.Equal(requestPay.Amount, result?.Amount);
    }

    [Fact]
    public async void Should_FideAsync_RequestPay_By_UserId_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFideAsyncUserIdTest", b => b.EnableNullChecks(false))
                .Options;

        var userId = Guid.NewGuid();
        var requestPay1 = new RequestPay(Guid.NewGuid(), userId, 10_000);
        var requestPay2 = new RequestPay(Guid.NewGuid(), userId, 10_000);

        using var context = new DataBaseContext(dbOptions);
        var requestPayRepository = new RequestPayRepository(context);
        requestPayRepository.Add(requestPay1);
        requestPayRepository.Add(requestPay2);
        context.SaveChanges();

        //ACT
        var results = await requestPayRepository.FindAsyncByUserId(userId);

        //ASSERT

        Assert.Equal(2, results.Count());
        Assert.Contains(results, r => r.Id == requestPay1.Id);
        Assert.Contains(results, r => r.Id == requestPay2.Id);
        Assert.Contains(results, r => r.UserId == userId);
        Assert.DoesNotContain(results, r => r.UserId == Guid.NewGuid());
        Assert.DoesNotContain(results, r => r.Id == new RequestPayId(Guid.NewGuid()));
    }

}