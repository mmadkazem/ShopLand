namespace ShopLand.Application.Account.Commands.ChangePassword.Request;

public record ChangePasswordCommandRequest
(
    string Email,
    string Password,
    string NewPassword,
    string ConfirmNewPassword
);
