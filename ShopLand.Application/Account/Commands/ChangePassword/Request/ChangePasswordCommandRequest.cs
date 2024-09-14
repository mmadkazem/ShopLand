namespace ShopLand.Application.Account.Commands.ChangePassword.Request;

public readonly record struct ChangePasswordCommandRequest
(
    string Email,
    string Password,
    string NewPassword,
    string ConfirmNewPassword
);
