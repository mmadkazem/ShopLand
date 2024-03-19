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
        var requestPayConfiguration = new RequestPayConfiguration();
        var orderConfiguration = new OrderConfiguration();

        modelBuilder.ApplyConfiguration<Product>(productConfiguration);
        modelBuilder.ApplyConfiguration<ProductCategory>(productConfiguration);
        modelBuilder.ApplyConfiguration<User>(userConfiguration);
        modelBuilder.ApplyConfiguration<UserInRole>(userConfiguration);
        modelBuilder.ApplyConfiguration<Cart>(cartConfiguration);
        modelBuilder.ApplyConfiguration<CartItem>(cartConfiguration);
        modelBuilder.ApplyConfiguration<Order>(orderConfiguration);
        modelBuilder.ApplyConfiguration<OrderDetail>(orderConfiguration);
        modelBuilder.ApplyConfiguration(requestPayConfiguration);
        modelBuilder.ApplyConfiguration(roleConfiguration);
        modelBuilder.ApplyConfiguration(categoryConfiguration);
    }
}