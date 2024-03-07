namespace ShopLand.Share.Abstract.Domain;

public abstract class BaseEntity<TId>
    where TId : class, ID
{
    public TId Id { get; private set; }

    protected BaseEntity(TId id)
    {
        Id = id;
    }
}