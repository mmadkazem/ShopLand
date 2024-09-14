namespace ShopLand.Application.Account.Commands.RegisterUser.Request;

public readonly record struct RegisterUserCommandRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ConfirmPassword
);
