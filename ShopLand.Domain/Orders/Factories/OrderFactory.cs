namespace ShopLand.Domain.Orders.Factories;

public class OrderFactory : IOrderFactory
{
    public Order Create(Guid userId, Guid requestPayId,
        string street, string city, string state, string postalCode)
    {
        var address = new Address(street, city, state, postalCode);
        return new(Guid.NewGuid(), userId, requestPayId, address);
    }
}