namespace ShopLand.Domain.Orders.Factories;

public interface IOrderFactory
{
    Order Create(Guid userId, Guid requestPayId,
        string street, string city, string state, string postalCode);
}