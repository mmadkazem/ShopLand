namespace ShopLand.Domain.Account.Roles.ValueObject;

public record RoleName
{
    public string Value { get; }

    public RoleName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new RoleNameNullOrWhiteSpaceException();
        }
        Value = value.Trim();
    }

    public static implicit operator string(RoleName name)
        => name.Value;

    public static implicit operator RoleName(string name)
        => new(name);
}