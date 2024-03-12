namespace ShopLand.Domain.Products.Product_Aggregate.ValueObject;

public record Inventory
{
    public uint Value { get; }
    public Inventory(uint value)
    {
        if (0 >= value || value > 100)
        {
            throw new InventoryInValidException();
        }
        Value = value;
    }

    public static implicit operator uint(Inventory inventory)
        => inventory.Value;

    public static implicit operator Inventory(uint inventory)
        => new(inventory);
}