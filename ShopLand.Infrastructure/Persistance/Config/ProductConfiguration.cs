namespace ShopLand.Infrastructure.Persistance.Config;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>,
    IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        var productNameConverter = new ValueConverter<ProductName, string>(p => p.Value,
            p => new ProductName(p));

        var brandConverter = new ValueConverter<Brand, string>(b => b.Value,
            b => new Brand(b));

        var descriptionConverter = new ValueConverter<ProductDescription, string>(d => d.Value,
            d => new ProductDescription(d));

        var inventoryConverter = new ValueConverter<Inventory, uint>(i => i.Value,
            i => new Inventory(i));

        var priceConverter = new ValueConverter<ProductPrice, uint>(p => p.Value,
            p => new ProductPrice(p));

        builder
            .Property(u => u.Id)
            .HasConversion(id => id.Value, id => new ProductId(id));

        builder
            .Property(p => p.ProductName)
            .HasConversion(productNameConverter)
            .HasColumnName(nameof(ProductName));

        builder
            .Property(p => p.Brand)
            .HasConversion(brandConverter)
            .HasColumnName(nameof(Brand));

        builder
            .Property(p => p.Description)
            .HasConversion(descriptionConverter)
            .HasColumnName("Description");

        builder
            .Property(p => p.Inventory)
            .HasConversion(inventoryConverter)
            .HasColumnName(nameof(Inventory));

        builder
            .Property(p => p.Price)
            .HasConversion(priceConverter)
            .HasColumnName("Price");

        builder.HasMany(p => p.ProductCategories);

    }

    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.Property<int>("Id");

        builder
            .Property(pc => pc.Category)
            .HasColumnName("Category");

        builder
            .Property(ur => ur.ProductId)
            .HasConversion(pid => pid.Value, uid => new ProductId(uid))
            .HasColumnName(nameof(ProductId));
    }
}