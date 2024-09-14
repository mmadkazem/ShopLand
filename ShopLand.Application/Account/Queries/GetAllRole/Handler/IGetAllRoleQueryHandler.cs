namespace ShopLand.Application.Account.Queries.GetAllRole.Handler;

public interface IGetAllRoleQueryHandler
{
    Task<IEnumerable<IResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default);
}
