namespace ShopLand.Infrastructure.Persistance.Context;

public sealed class DataBaseContext(DbContextOptions<DataBaseContext> options)
    : DbContext(options)
{
    // Account
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserInRole> UserInRoles { get; set; }

    // Product
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    // Cart
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddConfig();
        modelBuilder.AddSeedData();
    }
}