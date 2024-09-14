namespace ShopLand.Domain.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IProductRepository Products { get; }
    ICategoryRepository Categories { get; }
    ICartRepository Carts { get; }
    IRequestPayRepository RequestPays { get; }
    IOrderRepository Orders { get; }
    Task<int> SaveChangeAsync(CancellationToken token = default);
}