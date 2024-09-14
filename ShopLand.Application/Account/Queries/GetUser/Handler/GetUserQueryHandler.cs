namespace ShopLand.Application.Account.Queries.GetUser.Handler;

public class GetUserQueryHandler(IUnitOfWork uow) : IGetUserQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> HandelAsync(GetUserQueryRequest request, CancellationToken token = default)
    {
        var response = await _uow.Users.GetById(request.UserId, token)
            ?? throw new UserNotFoundException();

        return response;
    }
}