namespace ShopLand.Domain.Carts.ValueObject;

public record Count
{
    public uint Value { get; private set; }


    public Count(uint value)
    {
        if (value == 0)
        {
            throw new CountZeroValueException();
        }
        Value = value;
    }

    public void Add(uint productInventory)
    {
        if (Value + 1 > productInventory)
        {
            throw new CountMoreInventoryException();
        }
        Value++;
    }

    public void Low()
    {
        if (Value - 1 == 0)
        {
            throw new CountLessZeroException();
        }
        Value--;
    }
    public void IsValid(uint productInventory)
    {
        if (Value > productInventory)
        {
            throw new CountMoreInventoryException();
        }
    }

    public static implicit operator uint(Count count)
        => count.Value;

    public static implicit operator Count(uint value)
        => new(value);
}