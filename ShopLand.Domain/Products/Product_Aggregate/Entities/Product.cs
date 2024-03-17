namespace ShopLand.Domain.Products.Product_Aggregate.Entities;

public class Product : BaseEntity<ProductId>, IAggregateRoot
{
    public ProductName ProductName { get; private set; }
    public Brand Brand { get; private set; }
    public Inventory Inventory { get; private set; }
    public ProductDescription Description { get; private set; }
    public ProductPrice Price { get; private set; }

    public readonly LinkedList<ProductCategory> ProductCategories = new();
    public Product
        (ProductId id, Brand brand, ProductName productName,
         Inventory inventory, ProductDescription description,
         ProductPrice price)
        : base(id)
    {
        Brand = brand;
        Inventory = inventory;
        Description = description;
        Price = price;
        ProductName = productName;
    }

    // For Test
    public Product() : base(Guid.NewGuid()) { }

    public void AddCategory(Guid category)
    {
        var alreadyExists = ProductCategories.Any(r => r.Category == category);

        if (alreadyExists)
        {
            throw new ProductCategoryAlreadyExistsException();
        }

        ProductCategories.AddLast(new ProductCategory(Id, category));
    }

    public void AddCategory(IEnumerable<Guid> categories)
    {
        foreach (var category in categories)
        {
            AddCategory(category);
        }
    }
    public void RemoveCategory(Guid id)
    {
        if (ProductCategories.Count == 1)
        {
            throw new ProductCategoryOneRoleException();
        }
        var category = GetCategory(id);
        ProductCategories.Remove(category);
    }
    public void RemovedCategory(Guid id)
    {
        if (ProductCategories.Count == 1)
        {
            throw new ProductCategoryOneRoleException();
        }
        var category = GetCategory(id);
        ProductCategories.Remove(category);
    }

    public void UpdateCategory(Guid oldCategory, Guid newCategory)
    {
        var isExists = ProductCategories.Any(r => r.Category == oldCategory);
        if (!isExists)
        {
            throw new ProductCategoryNotFoundException();
        }
        RemoveCategory(oldCategory);
        AddCategory(newCategory);

    }

    public ProductCategory GetCategory(Guid id)
    {
        var category = ProductCategories
            .FirstOrDefault(pc => pc.Category == id);

        if (category is null)
        {
            throw new ProductCategoryNotFoundException();
        }

        return category;
    }

    public void Update(Brand brand, Inventory inventory, ProductName name,
        ProductDescription description, ProductPrice price)
    {
        ProductName = name;
        Brand = brand;
        Inventory = inventory;
        Description = description;
        Price = price;
    }
}