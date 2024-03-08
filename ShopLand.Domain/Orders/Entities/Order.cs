namespace ShopLand.Domain.Orders.Entities;

public class Order : BaseEntity<OrderId>, IAggregateRoot
{
    public Guid UserId { get; private set; }
    public Guid RequestPayId { get; private set; }
    public Address Address { get; private set; }
    public OrderState OrderState { get; private set; }

    public LinkedList<OrderDetail> OrderDetails = new();
    public Order(OrderId id, Guid userId, Guid requestPayId, Address address)
        : base(id)
    {
        UserId = userId;
        RequestPayId = requestPayId;
        Address = address;
        OrderState = OrderState.Processing;
    }

    public void UpdateOrderState(OrderState orderState)
    {
        if (OrderState == orderState)
        {
            throw new OrderStateAlreadyExistException();
        }
        OrderState = orderState;
    }

    public void AddOrderDetail(Guid productId, uint count, uint price)
    {
        var alreadyExists = OrderDetails.Any(c => c.ProductId == productId);

        if (alreadyExists)
        {
            throw new OrderDetailAlreadyExistsException();
        }
        var orderDetail = new OrderDetail(productId, Id, count, price);

        OrderDetails.AddLast(orderDetail);
    }

}