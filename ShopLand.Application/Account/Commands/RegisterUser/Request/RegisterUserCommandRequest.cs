namespace ShopLand.Application.Account.Commands.RegisterUser.Request;

public record RegisterUserCommandRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ConfirmPassword
);
