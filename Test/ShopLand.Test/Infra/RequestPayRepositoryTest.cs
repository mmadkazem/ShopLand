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
}