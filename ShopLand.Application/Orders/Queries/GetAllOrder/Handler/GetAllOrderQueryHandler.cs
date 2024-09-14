namespace ShopLand.Application.Orders.Queries.GetAllOrder.Handler;

public class GetAllOrderQueryHandler(IUnitOfWork uow)
    : IGetAllOrderQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default)
    {
        var responses = await _uow.Orders.GetAll(request, token);
        if (!responses.Any())
        {
            throw new OrderNotFoundException();
        }

        return responses;
    }
}