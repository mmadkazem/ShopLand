using OrderDetail = ShopLand.Domain.Orders.ValueObject.OrderDetail;

namespace ShopLand.Infrastructure.Persistance.Context;

public sealed class DataBaseContext(DbContextOptions<DataBaseContext> options)
    : DbContext(options)
{
    // Account
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserInRole> UserInRoles { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }

    // Product
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    // Cart
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    // Request Pay
    public DbSet<RequestPay> requestPays { get; set; }

    // Order
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddConfig();
    }
}