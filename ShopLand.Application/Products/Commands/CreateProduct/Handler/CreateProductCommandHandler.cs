namespace ShopLand.Application.Products.Commands.CreateProduct.Handler;

public sealed class CreateProductCommandHandler(IUnitOfWork uow, IProductFactory productFactory)
    : ICreateProductCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IProductFactory _productFactory = productFactory;

    public async Task<Guid> HandelAsync(CreateProductCommandRequest request, CancellationToken token = default)
    {
        var (name, brand, description, inventory, price, categories) = request;

        var product = _productFactory.Create(brand, name, description, price, inventory);

        foreach (var item in request.Categories)
        {
            if (!await _uow.Categories.Any(item, token))
            {
                throw new CategoryNotFoundException();
            }
        }

        product.AddCategory(categories);
        _uow.Products.Add(product);
        await _uow.SaveChangeAsync(token);

        return product.Id;
    }
}