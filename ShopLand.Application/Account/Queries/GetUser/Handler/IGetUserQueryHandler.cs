namespace ShopLand.Application.Account.Queries.GetUser.Handler;

public interface IGetUserQueryHandler
{
    Task<GetUserQueryResponse> HandelAsync(GetUserQueryRequest request, CancellationToken token = default);
}

public class GetUserQueryHandler(IUnitOfWork uow) : IGetUserQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<GetUserQueryResponse> HandelAsync(GetUserQueryRequest request, CancellationToken token = default)
    {
        var user = await _uow.Users.FindAsync(request.UserId, token)
            ?? throw new UserNotFoundException();

        var response = user.AsResponse();

        foreach (var userRole in user.UsedInRoles)
        {
            var result = await _uow.Roles.FindAsync(userRole.Role, token);
            response.Roles?.Add(result.Name);
        }

        return response;
    }
}