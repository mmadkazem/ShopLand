namespace ShopLand.Application.Orders.Queries.GetOrderByUserId.Handler;

public sealed class GetOrderByUserIdQueryHandler(IUnitOfWork uow)
    : IGetOrderByUserIdQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> HandelAsync(GetOrderByUserIdQueryRequest request, CancellationToken token = default)
    {
        var responses = await _uow.Orders.GetByUserId(request.UserId, token);
        if (!responses.Any())
        {
            throw new OrderNotFoundException();
        }

        return responses;
    }
}