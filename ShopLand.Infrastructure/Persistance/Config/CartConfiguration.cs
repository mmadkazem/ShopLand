namespace ShopLand.Infrastructure.Persistance.Config;

internal sealed class CartConfiguration : IEntityTypeConfiguration<Cart>,
    IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder
            .Property(c => c.Id)
            .HasConversion(c => c.Value, c => new CartId(c))
            .HasColumnName(nameof(CartId));

        builder.HasMany(c => c.CartItems);
    }

    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.Property<int>("Id");

        var countConverter = new ValueConverter<Count,uint>
            (c => c.Value, c => new(c));
        builder
            .Property(c => c.Count)
            .HasConversion(countConverter);

        builder
            .Property(c => c.CartId)
            .HasConversion(c => c.Value, c => new CartId(c))
            .HasColumnName(nameof(CartId));
    }
}