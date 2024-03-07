namespace ShopLand.Application.Users.Facade;

public interface IAccountFacade
{
    IRegisterUserCommandHandler RegisterUser { get; }
    ILoginUserQueryHandler LoginUser { get; }
    IAddUserRoleCommandHandler AddUserRole { get; }
    IGetCurrentUserQueryHandler GetCurrentUser { get; }
    IChangePasswordCommandHandler ChangePassword { get; }
    ICreateRoleCommandHandler CreateRole { get; }
    IRemoveRoleCommandHandler RemoveRole { get; }
    IRemoveUserRoleCommandHandler RemoveUserRole { get; }
    IGetAllRoleQueryHandler GetAllRole { get; }
}

public class AccountFacade : IAccountFacade
{
    public AccountFacade(IRegisterUserCommandHandler registerUser,
            ILoginUserQueryHandler loginUser,
            IAddUserRoleCommandHandler addUserRole,
            IGetCurrentUserQueryHandler getCurrentUser,
            IChangePasswordCommandHandler changePassword,
            ICreateRoleCommandHandler createRole,
            IRemoveRoleCommandHandler removeRole,
            IRemoveUserRoleCommandHandler removeUserRole,
            IGetAllRoleQueryHandler getAllRole)
    {
        _registerUser = registerUser;
        _loginUser = loginUser;
        _addUserRole = addUserRole;
        _getCurrentUser = getCurrentUser;
        _changePassword = changePassword;
        _createRole = createRole;
        _removeRole = removeRole;
        _removeUserRole = removeUserRole;
        _getAllRole = getAllRole;
    }
    private readonly IRegisterUserCommandHandler _registerUser;
    public IRegisterUserCommandHandler RegisterUser
        => _registerUser;


    private readonly ILoginUserQueryHandler _loginUser;
    public ILoginUserQueryHandler LoginUser
        => _loginUser;

    private readonly IAddUserRoleCommandHandler _addUserRole;
    public IAddUserRoleCommandHandler AddUserRole
        => _addUserRole;


    private readonly IGetCurrentUserQueryHandler _getCurrentUser;
    public IGetCurrentUserQueryHandler GetCurrentUser
        => _getCurrentUser;

    private readonly IChangePasswordCommandHandler _changePassword;
    public IChangePasswordCommandHandler ChangePassword
        => _changePassword;


    private readonly ICreateRoleCommandHandler _createRole;
    public ICreateRoleCommandHandler CreateRole
        => _createRole;


    private readonly IRemoveRoleCommandHandler _removeRole;
    public IRemoveRoleCommandHandler RemoveRole
        => _removeRole;

    private readonly IRemoveUserRoleCommandHandler _removeUserRole;
    public IRemoveUserRoleCommandHandler RemoveUserRole
        => _removeUserRole;


    private readonly IGetAllRoleQueryHandler _getAllRole;
    public IGetAllRoleQueryHandler GetAllRole
        => _getAllRole;

}