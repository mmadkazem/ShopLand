namespace ShopLand.Domain.Finances.Repositories;

public interface IRequestPayRepository
{
    void Add(RequestPay requestPay);
    Task<RequestPay> FindAsync(RequestPayId Id, CancellationToken token = default);
    Task<IEnumerable<RequestPay>> FindAsyncByUserId(Guid userId, CancellationToken token = default);
}