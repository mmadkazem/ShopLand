namespace ShopLand.Application.Account.Commands.RegisterUser.Handler;

public class RegisterUserCommandHandler : IRegisterUserCommandHandler
{
    private readonly IUserFactories _userFactories;
    private readonly IUnitOfWork _uow;

    public RegisterUserCommandHandler
        (IUserFactories userFactories,
         IUnitOfWork uow)
    {
        _userFactories = userFactories;
        _uow = uow;
    }

    public async Task HandelAsync(RegisterUserCommandRequest request)
    {
        var (firstName, lastName, email, password, confirmPassword) = request;

        var user = _userFactories
            .Create(firstName, lastName, password, confirmPassword, email);

        var role = await _uow.Roles.FindAsyncByName(nameof(CustomRoles.Customer));
        user.AddRole(role.Id);

        _uow.Users.Add(user);
        await _uow.SaveAsync();
    }
}