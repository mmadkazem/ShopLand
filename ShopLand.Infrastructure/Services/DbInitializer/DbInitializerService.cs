namespace ShopLand.Infrastructure.Services.DbInitializer;


public class DbInitializerService : IDbInitializerService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DbInitializerService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public void Initialize()
    {
        using (var serviceScope = _scopeFactory.CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<DataBaseContext>())
            {
                context.Database.Migrate();
            }
        }
    }

    public void SeedData()
    {
        using (var serviceScope = _scopeFactory.CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<DataBaseContext>())
            {
                // Add default roles
                var adminRole = new Role(Guid.NewGuid(), CustomRoles.Admin);
                var customerRole = new Role(Guid.NewGuid(), CustomRoles.Customer);
                if (!context.Roles.Any())
                {
                    context.Add(adminRole);
                    context.Add(customerRole);
                    context.SaveChanges();
                }

                // Add Admin user
                if (!context.Users.Any())
                {
                    var user = new User(Guid.NewGuid(), FullName.Create("Admin,Admin"),
                        "Admin@Admin.com", new Password("@@Admin11@@", "@@Admin11@@"));
                    user.AddRole(adminRole.Id);
                    user.AddRole(customerRole.Id);

                    context.Add(user);
                    context.SaveChanges();
                }
            }
        }
    }
}