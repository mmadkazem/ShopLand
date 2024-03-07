using ShopLand.Application.Common;

namespace ShopLand.Application.Account.Queries.GetAllRole.Handler;

public interface IGetAllRoleQueryHandler
{
    Task<List<GetAllRoleQueryResponse>> HandelAsync(PageNumberRequest request);
}
public class GetAllRoleQueryHandler(IUnitOfWork uow)
    : IGetAllRoleQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<List<GetAllRoleQueryResponse>> HandelAsync(PageNumberRequest request)
    {
        var roles = await _uow.Roles.GetAll(request.Page);

        return roles.Select(r => r.AsResponse()).ToList();
    }
}