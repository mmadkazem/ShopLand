namespace ShopLand.Infrastructure.Persistance.Context;

public static class DbContextExtensions
{
    public static void AddConfig(this ModelBuilder modelBuilder)
    {
        var userConfiguration = new UserConfiguration();
        var roleConfiguration = new RoleConfiguration();
        var productConfiguration = new ProductConfiguration();
        var categoryConfiguration = new CategoryConfiguration();
        var cartConfiguration = new CartConfiguration();

        modelBuilder.ApplyConfiguration<Product>(productConfiguration);
        modelBuilder.ApplyConfiguration<ProductCategory>(productConfiguration);
        modelBuilder.ApplyConfiguration<User>(userConfiguration);
        modelBuilder.ApplyConfiguration<UserInRole>(userConfiguration);
        modelBuilder.ApplyConfiguration<Cart>(cartConfiguration);
        modelBuilder.ApplyConfiguration<CartItem>(cartConfiguration);
        modelBuilder.ApplyConfiguration(roleConfiguration);
        modelBuilder.ApplyConfiguration(categoryConfiguration);
    }

    public static void AddSeedData(this ModelBuilder modelBuilder)
    {
        var roleAdmin = new RoleFactories().Create("Admin");
        var roleCustomer = new RoleFactories().Create("Customer");

        modelBuilder.Entity<Role>()
        .HasData(roleAdmin);
        modelBuilder.Entity<Role>()
        .HasData(roleCustomer);
    }
}