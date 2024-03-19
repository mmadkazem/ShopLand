namespace ShopLand.Application.Common;


public interface IDbInitializerService
{
    void Initialize();
    void SeedData();
}