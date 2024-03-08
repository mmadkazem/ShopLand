namespace ShopLand.Infrastructure.Persistance.Config;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>,
    IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .Property(o => o.Id)
            .HasConversion(oid => oid.Value, oid => new OrderId(oid));

        var addressConversion = new ValueConverter<Address, string>
                (a => a.ToString(), a => Address.Create(a));

        builder
            .Property(o => o.Address)
            .HasConversion(addressConversion);

        builder
            .Property(o => o.OrderState)
            .HasConversion
            (
                os => os.ToString(),
                os => (OrderState)Enum.Parse(typeof(OrderState), os)
            );

        builder.HasMany(o => o.OrderDetails);
    }

    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.Property<int>("Id");
        builder
            .Property(o => o.OrderId)
            .HasConversion(oid => oid.Value, oid => new OrderId(oid))
            .HasColumnName(nameof(OrderId));
    }
}