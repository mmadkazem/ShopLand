namespace ShopLand.Application.Account.Commands.RegisterUser.Handler;

public class RegisterUserCommandHandler(IUserFactories userFactories,
        IUnitOfWork uow,
        IAddedUserEventHandler addedUser)
    : IRegisterUserCommandHandler
{
    private readonly IUserFactories _userFactories = userFactories;
    private readonly IUnitOfWork _uow = uow;
    private readonly IAddedUserEventHandler _addedUser = addedUser;

    public async Task HandelAsync(RegisterUserCommandRequest request, CancellationToken token = default)
    {
        var (firstName, lastName, email, password, confirmPassword) = request;

        var user = _userFactories
            .Create(firstName, lastName, password, confirmPassword, email);

        var role = await _uow.Roles.FindAsyncByName(nameof(CustomRoles.Customer), token);
        user.AddRole(role.Id);

        _uow.Users.Add(user);
        await _uow.SaveAsync(token);
        await _addedUser.HandelAsync(user.Id, token);
    }
}