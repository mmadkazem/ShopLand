using ShopLand.Domain.Finances.Entities;

namespace ShopLand.Infrastructure.Persistance.Config;

public class RequestPayConfiguration : IEntityTypeConfiguration<RequestPay>
{
    public void Configure(EntityTypeBuilder<RequestPay> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasConversion(p => p.Value, p => new(p));
    }
}