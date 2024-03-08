namespace ShopLand.Infrastructure.Persistance.UnitOfWorks;

public sealed class UnitOfWork(DataBaseContext context) : IUnitOfWork
{
    private readonly DataBaseContext _context = context;

    public IUserRepository Users
        => new UserRepository(_context);

    public IRoleRepository Roles
        => new RoleRepository(_context);

    public IProductRepository Products
        => new ProductRepository(_context);

    public ICategoryRepository Categories
        => new CategoryRepository(_context);

    public ICartRepository Carts
        => new CartRepository(_context);

    public IRequestPayRepository RequestPays
        => new RequestPayRepository(_context);

    public IOrderRepository Orders
        => new OrderRepository(_context);

    public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
}