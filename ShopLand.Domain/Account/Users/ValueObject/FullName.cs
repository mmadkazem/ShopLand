namespace ShopLand.Domain.Account.Users.ValueObject;

public record FullName(string FirstName, string LastName)
{

    public static FullName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new FullNameNullOrWhiteSpaceException();
        }

        var splitFullName = value.Split(',');
        return new FullName(splitFullName.First().ToUpper(), splitFullName.Last().ToUpper());
    }

    public override string ToString()
        => $"{FirstName},{LastName}";
}