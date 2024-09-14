namespace ShopLand.Application.RequestPays.Queries.GetRequestPaysUser.Handler;

public sealed class GetRequestPaysUserQueryHandler(IUnitOfWork uow)
    : IGetRequestPaysUserQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> HandelAsync(GetRequestPaysUserQueryRequest request, CancellationToken token = default)
    {
        var responses = await _uow.RequestPays.GetByUserId(request.UserId, token);
        if (!responses.Any())
        {
            throw new RequestPayNotFoundException();
        }

        return responses;
    }
}