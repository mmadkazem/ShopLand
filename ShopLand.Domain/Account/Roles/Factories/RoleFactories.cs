namespace ShopLand.Domain.Account.Roles.Factories;

public class RoleFactories : IRoleFactories
{
    public Role Create(string Name)
    {
        RoleId id = new(Guid.NewGuid());
        RoleName name = new(Name);

        return new(id, name);
    }
}