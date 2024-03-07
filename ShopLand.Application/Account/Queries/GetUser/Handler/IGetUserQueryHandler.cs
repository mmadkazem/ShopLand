namespace ShopLand.Application.Account.Queries.GetUser.Handler;

public interface IGetCurrentUserQueryHandler
{
    Task<GetUserQueryResponse> HandelAsync(GetUserQueryRequest request);
}

public class GetUserQueryHandler : IGetCurrentUserQueryHandler
{
    private readonly IUnitOfWork _uow;
    public GetUserQueryHandler(IUnitOfWork uow)
        => _uow = uow;
    public async Task<GetUserQueryResponse> HandelAsync(GetUserQueryRequest request)
    {
        var user = await _uow.Users.FindAsync(request.UserId);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        return user.AsResponse();
    }
}