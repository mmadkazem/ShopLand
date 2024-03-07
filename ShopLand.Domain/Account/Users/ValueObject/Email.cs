namespace ShopLand.Domain.Account.Users.ValueObject;

public record Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (!isValidEmail(value))
        {
            throw new InvalidEmailException();
        }

        Value = value.Trim();
    }

    private bool isValidEmail(string value)
        => Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

    public static implicit operator string(Email email)
        => email.Value;

    public static implicit operator Email(string email)
        => new(email);
}