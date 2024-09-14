namespace ShopLand.Application.Account.Queries.GetUser.Handler;

public interface IGetUserQueryHandler
{
    Task<IResponse> HandelAsync(GetUserQueryRequest request, CancellationToken token = default);
}