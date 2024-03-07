namespace ShopLand.Application.Account.Commands.ChangePassword.Handler;

public class ChangePasswordCommandHandler : IChangePasswordCommandHandler
{
    private readonly IUnitOfWork _uow;

    public ChangePasswordCommandHandler(IUnitOfWork uow)
        => _uow = uow;

    public async Task HandelAsync(ChangePasswordCommandRequest request)
    {
        if (request.Password == request.NewPassword)
        {
            throw new EqualNewPasswordAndOldPasswordException();
        }

        var user = await _uow.Users.FindAsyncByEmail(request.Email);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        if (!user.UserLogin(request.Email, request.Password))
        {
            throw new UserNotLoginException();
        }

        user.ChangePassword(request.NewPassword, request.ConfirmNewPassword);
        await _uow.SaveAsync();
    }
}