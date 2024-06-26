namespace ShopLand.Application.Account.Queries.GetUser.Handler;

public interface IGetUserQueryHandler
{
    Task<GetUserQueryResponse> HandelAsync(GetUserQueryRequest request);
}

public class GetUserQueryHandler : IGetUserQueryHandler
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

        var response = user.AsResponse();

        foreach (var userRole in user.UsedInRoles)
        {
            var result = await _uow.Roles.FindAsync(userRole.Role);
            response.Roles?.Add(result.Name);
        }

        return response;
    }
}