namespace ShopLand.Domain.Account.Users.Factories;

public class UserFactories : IUserFactories
{
    public User Create(string FirstName, string LastName, string Password, string ConfirmPassword, string Email)
    {
        var id = new UserId(Guid.NewGuid());
        var fullName = new FullName(FirstName, LastName);
        var email = new Email(Email);
        var password = new Password(Password, ConfirmPassword);

        return new User(id, fullName, email, password);
    }
}