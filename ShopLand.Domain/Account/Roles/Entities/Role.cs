namespace ShopLand.Domain.Account.Roles.Entities;

public class Role : BaseEntity<RoleId>, IAggregateRoot
{
    public RoleName Name { get; }

    public Role(RoleId id, RoleName name)
        : base(id)
    {
        Name = name;
    }
}