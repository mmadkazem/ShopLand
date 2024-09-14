namespace ShopLand.Domain.Finances.Repositories;

public interface IRequestPayRepository
{
    void Add(RequestPay requestPay);
    Task<RequestPay> FindAsync(RequestPayId Id, CancellationToken token = default);
    Task<IEnumerable<IResponse>> GetByUserId(Guid userId, CancellationToken token = default);
    Task<IResponse> Get(RequestPayId id, CancellationToken token);
}