namespace ShopLand.Application.Products.Commands.CreateProduct.Handler;

public class CreateProductCommandHandler : ICreateProductCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IProductFactory _productFactory;

    public CreateProductCommandHandler(IUnitOfWork uow,
        IProductFactory productFactory)
    {
        _uow = uow;
        _productFactory = productFactory;
    }
    public async Task<Guid> HandelAsync(CreateProductCommandRequest request, CancellationToken token = default)
    {
        var (name, brand, description, inventory, price, categories) = request;

        var product = _productFactory
            .Create(brand, name, description, price, inventory);

        foreach (var item in request.Categories)
        {
            var isExists = await _uow.Categories.Any(item, token);
            if (!isExists)
            {
                throw new CategoryNotFoundException();
            }
        }

        product.AddCategory(categories);
        _uow.Products.Add(product);
        await _uow.SaveAsync(token);

        return product.Id;
    }
}