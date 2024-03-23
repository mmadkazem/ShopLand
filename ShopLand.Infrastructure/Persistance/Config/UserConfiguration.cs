namespace ShopLand.Infrastructure.Persistance.Config;


internal sealed class UserConfiguration
    : IEntityTypeConfiguration<User>, IEntityTypeConfiguration<UserInRole>,
        IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(pl => pl.Id);

        var fullNameConverter = new ValueConverter<FullName, string>(l => l.ToString(),
            l => FullName.Create(l));

        var emailConverter = new ValueConverter<Email, string>(e => e.Value,
            e => new Email(e));

        var passwordConverter = new ValueConverter<Password, string>(p => p.Value,
            p => new Password(p));

        builder
            .Property(u => u.Id)
            .HasConversion(id => id.Value, id => new UserId(id));

        builder
            .Property(u => u.FullName)
            .HasConversion(fullNameConverter)
            .HasColumnName(nameof(FullName));

        builder
            .Property(u => u.Email)
            .HasConversion(emailConverter)
            .HasColumnName(nameof(Email));

        builder
            .Property(typeof(Password), "_password")
            .HasConversion(passwordConverter)
            .HasColumnName(nameof(Password));

        builder.HasMany(u => u.UsedInRoles);
        builder.HasMany(u => u.UserTokens);
    }

    public void Configure(EntityTypeBuilder<UserInRole> builder)
    {
        builder.Property<int>("Id");

        builder.Property(ur => ur.Role);

        builder
            .Property(ur => ur.UserId)
            .HasConversion(uid => uid.Value, uid => new UserId(uid))
            .HasColumnName(nameof(UserId));
    }

    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.Property<int>("Id");

        builder.Property(t => t.AccessTokenHash);
        builder.Property(t => t.AccessTokenExpiresDateTime);
        builder.Property(t => t.RefreshTokenIdHash);
        builder.Property(t => t.RefreshTokenIdSerial);
        builder.Property(t => t.RefreshTokenExpiresDateTime);

        builder
            .Property(ur => ur.UserId)
            .HasConversion(uid => uid.Value, uid => new UserId(uid))
            .HasColumnName(nameof(UserId));
    }
}