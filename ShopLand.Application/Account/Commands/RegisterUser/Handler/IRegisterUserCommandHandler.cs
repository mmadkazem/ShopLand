namespace ShopLand.Application.Account.Commands.RegisterUser.Handler;

public interface IRegisterUserCommandHandler
{
    Task HandelAsync(RegisterUserCommandRequest request);
}