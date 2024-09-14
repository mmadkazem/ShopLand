namespace ShopLand.Application.Account.Queries.GetAllRole.Handler;

public sealed class GetAllRoleQueryHandler(IUnitOfWork uow)
    : IGetAllRoleQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default)
    {
        var responses = await _uow.Roles.GetAll(request.Page, token);
        if (!responses.Any())
        {
            throw new RoleNotFoundException();
        }

        return responses;
    }
}