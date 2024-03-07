namespace ShopLand.Application.Account.Events.RemovedUser;

public interface IRemovedUserEventHandler
{
    Task HandelAsync(Guid userId);
}
