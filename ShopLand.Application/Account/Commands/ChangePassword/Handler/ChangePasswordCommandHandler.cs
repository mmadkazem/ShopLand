namespace ShopLand.Application.Account.Commands.ChangePassword.Handler;

public class ChangePasswordCommandHandler(IUnitOfWork uow) : IChangePasswordCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(ChangePasswordCommandRequest request, CancellationToken token = default)
    {
        if (request.Password == request.NewPassword)
        {
            throw new EqualNewPasswordAndOldPasswordException();
        }

        var user = await _uow.Users.FindAsyncByEmail(request.Email, token)
            ?? throw new UserNotFoundException();

        user.UserLogin(request.Email, request.Password);

        user.ChangePassword(request.NewPassword, request.ConfirmNewPassword);
        await _uow.SaveAsync(token);
    }
}