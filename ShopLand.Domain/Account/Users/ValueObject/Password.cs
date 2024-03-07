namespace ShopLand.Domain.Account.Users.ValueObject;

public record Password
{
    public string Value { get; }
    private string _errorMessage;


    public Password(string value, string confirm)
    {
        if (!ValidatePassword(value, confirm, out _errorMessage))
        {
            throw new InvalidUserPasswordException(_errorMessage);
        }

        Value = Hash.GetSha256Hash(value.Trim());
    }
    public Password(string value)
    {
        Value = value;
    }
    private bool ValidatePassword(string password, string confirm, out string ErrorMessage)
    {
        ErrorMessage = string.Empty;
        var flag = true;

        if (string.IsNullOrWhiteSpace(password))
        {
            ErrorMessage = "Password should not be empty.";
            return false;
        }
        if (password != confirm)
        {
            ErrorMessage = "This password not equals in confirm password.";
            return false;
        }
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMiniMaxChars = new Regex(@".{8,15}");
        var hasLowerChar = new Regex(@"[a-z]+");
        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

        if (!hasLowerChar.IsMatch(password))
        {
            ErrorMessage += "Password should contain at least one lower case letter. & ";
            flag = false;
        }
        if (!hasUpperChar.IsMatch(password))
        {
            ErrorMessage += "Password should contain at least one upper case letter. & ";
            flag = false;
        }
        if (!hasMiniMaxChars.IsMatch(password))
        {
            ErrorMessage += "Password should not be lesser than 8 or greater than 15 characters. & ";
            flag = false;
        }
        if (!hasNumber.IsMatch(password))
        {
            ErrorMessage += "Password should contain at least one numeric value. & ";
            flag = false;
        }
        if (!hasSymbols.IsMatch(password))
        {
            ErrorMessage += "Password should contain at least one special case character. & ";
            flag = false;
        }

        return flag;
    }

    public static implicit operator string(Password name)
        => name.Value;
    public static implicit operator Password(string name)
        => new(name);
}