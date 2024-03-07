namespace ShopLand.Domain.Account.Users.Factories;

public interface IUserFactories
{
    User Create
    (
        string FirstName,
        string LastName,
        string Password,
        string ConfirmPassword,
        string Email
    );
}