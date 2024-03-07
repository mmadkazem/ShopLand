namespace ShopLand.Infrastructure.Persistance.Config;

internal sealed class RoleConfiguration
    : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .Property(r => r.Id)
            .HasConversion(rid => rid.Value, rid => new RoleId(rid));

        var RoleNameConverter = new ValueConverter<RoleName, string>
        (
            rn => rn.Value,
            rn => new RoleName(rn)
        );

        builder
            .Property(r => r.Name)
            .HasConversion(RoleNameConverter);

    }
}