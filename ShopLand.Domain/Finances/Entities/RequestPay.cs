namespace ShopLand.Domain.Finances.Entities;


public class RequestPay : BaseEntity<RequestPayId>
{
    public Guid UserId { get; private set; }
    public uint Amount { get; private set; }
    public bool IsPay { get; private set; } = default;
    public DateTime? PayDate { get; private set; }
    public string Authority { get; private set; }
    public long RefId { get; private set; } = 0;
    internal RequestPay(RequestPayId id, Guid userId, uint amount)
        : base(id)
    {
        UserId = userId;
        Amount = amount;
    }

    public RequestPay() : base(Guid.NewGuid()){}

    public void PayOff(string authority, long refId)
    {
        IsPay = true;
        PayDate = DateTime.Now;
        Authority = authority;
        RefId = refId;
    }
}