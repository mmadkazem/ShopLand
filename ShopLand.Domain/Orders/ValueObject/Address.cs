namespace ShopLand.Domain.Orders.ValueObject;

public record Address
    (string Street, string City, string State, string PostalCode)
{
    public static Address Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new AddressInvalidException();
        }

        var splitFullName = value.Split(',');

        splitFullName.Last().ToUpper();

        return new
        (
            splitFullName[0].ToUpper(),
            splitFullName[1].ToUpper(),
            splitFullName[2].ToUpper(),
            splitFullName[3].ToUpper()
        );
    }

    public override string ToString()
        => $"{Street},{City},{State},{PostalCode}";
}