namespace ShopLand.Infrastructure.Persistance.Config;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasConversion(cid => cid.Value, cid => new CategoryId(cid));

        var CategoryNameConverter = new ValueConverter<CategoryName, string>
        (
            cn => cn.Value,
            cn => new CategoryName(cn)
        );

        builder
            .Property(p => p.CategoryName)
            .HasConversion(CategoryNameConverter)
            .HasColumnName(nameof(CategoryName));
    }
}