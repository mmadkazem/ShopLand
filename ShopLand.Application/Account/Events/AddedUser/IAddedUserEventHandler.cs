namespace ShopLand.Application.Account.Events.AddedUser;

public interface IAddedUserEventHandler
{
    Task HandelAsync(Guid userId, CancellationToken token = default);
}
