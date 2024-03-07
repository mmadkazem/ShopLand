namespace ShopLand.Domain.Account.Roles.ValueObject;

public record RoleId : ID
{
    public Guid Value { get; }

    public RoleId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new RoleIdEmptyException();
        }
        Value = value;
    }

    public static implicit operator Guid(RoleId id)
          => id.Value;

    public static implicit operator RoleId(Guid id)
        => new(id);
}