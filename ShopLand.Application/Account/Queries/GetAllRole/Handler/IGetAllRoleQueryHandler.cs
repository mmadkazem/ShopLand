namespace ShopLand.Application.Account.Queries.GetAllRole.Handler;

public interface IGetAllRoleQueryHandler
{
    Task<List<GetAllRoleQueryResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default);
}
public class GetAllRoleQueryHandler(IUnitOfWork uow)
    : IGetAllRoleQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<List<GetAllRoleQueryResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default)
    {
        var roles = await _uow.Roles.GetAll(request.Page, token);

        return roles.Select(r => r.AsResponse()).ToList();
    }
}