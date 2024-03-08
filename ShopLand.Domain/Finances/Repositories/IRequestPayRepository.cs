namespace ShopLand.Domain.Finances.Repositories;

public interface IRequestPayRepository
{
    void Add(RequestPay requestPay);
    Task<RequestPay> FindAsync(RequestPayId Id);
    Task<IEnumerable<RequestPay>> FindAsyncByUserId(Guid userId);
}