using ShopLand.Application.Account.Commands.LoginUserByRefreshToken.Handler;
using ShopLand.Application.Account.Commands.UserLogout.Handler;

namespace ShopLand.Application.Users.Facade;

public interface IAccountFacade
{
    IRegisterUserCommandHandler RegisterUser { get; }
    ILoginUserQueryHandler LoginUser { get; }
    IAddUserRoleCommandHandler AddUserRole { get; }
    IGetUserQueryHandler GetUser { get; }
    IChangePasswordCommandHandler ChangePassword { get; }
    ICreateRoleCommandHandler CreateRole { get; }
    IRemoveRoleCommandHandler RemoveRole { get; }
    IRemoveUserRoleCommandHandler RemoveUserRole { get; }
    IGetAllRoleQueryHandler GetAllRole { get; }
    ILoginUserByRefreshTokenCommandHandler LoginUserByRefreshToken { get; }
    IUserLogoutCommandHandler UserLogout { get; }
}

public class AccountFacade : IAccountFacade
{
    public AccountFacade(IRegisterUserCommandHandler registerUser,
            ILoginUserQueryHandler loginUser,
            IAddUserRoleCommandHandler addUserRole,
            IGetUserQueryHandler getCurrentUser,
            IChangePasswordCommandHandler changePassword,
            ICreateRoleCommandHandler createRole,
            IRemoveRoleCommandHandler removeRole,
            IRemoveUserRoleCommandHandler removeUserRole,
            IGetAllRoleQueryHandler getAllRole,
            ILoginUserByRefreshTokenCommandHandler loginUserByRefreshToken,
            IUserLogoutCommandHandler userLogout)
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
        _loginUserByRefresh = loginUserByRefreshToken;
        _userLogout = userLogout;
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


    private readonly IGetUserQueryHandler _getCurrentUser;
    public IGetUserQueryHandler GetUser
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

    private readonly ILoginUserByRefreshTokenCommandHandler _loginUserByRefresh;
    public ILoginUserByRefreshTokenCommandHandler LoginUserByRefreshToken
        => _loginUserByRefresh;

    private readonly IUserLogoutCommandHandler _userLogout;
    public IUserLogoutCommandHandler UserLogout
        => _userLogout;
}