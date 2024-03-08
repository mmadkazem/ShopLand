namespace ShopLand.Domain.Finances.Factories;

public interface IRequestPayFactory
{
    RequestPay Create(Guid userId, uint amount);
}

public class RequestPayFactory : IRequestPayFactory
{
    public RequestPay Create(Guid userId, uint amount)
        => new(Guid.NewGuid(), userId, amount);
}