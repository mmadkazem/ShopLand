namespace ShopLand.Domain.Account.Users.ValueObject;

public record UserId : ID
{
    public Guid Value { get; }

    public UserId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new UserIdEmptyException();
        }
        Value = value;
    }

    public static implicit operator Guid(UserId id)
        => id.Value;

    public static implicit operator UserId(Guid id)
        => new(id);
}