namespace ShopLand.Application.Products.Facade;

public interface IProductFacade
{
    ICreateProductCommandHandler CreateProduct { get; }
    IGetAllProductQueryHandler GetAllProduct { get; }
    IGetProductQueryHandler GetProduct { get; }
    IRemoveProductCommandHandler RemoveProduct { get; }
    IUpdateProductCommandHandler UpdateProduct { get; }
    IAddProductCategoryCommandHandler AddCategory { get; }
    IUpdateProductCategoryCommandHandler UpdateCategory { get; }
    IRemoveProductCategoryCommandHandler RemoveCategory { get; }
}

public class ProductFacade : IProductFacade
{

    public ProductFacade(ICreateProductCommandHandler createProduct,
        IGetAllProductQueryHandler getAllProduct,
        IGetProductQueryHandler getProduct,
        IRemoveProductCommandHandler removeProduct,
        IUpdateProductCommandHandler updateProduct,
        IAddProductCategoryCommandHandler addCategory,
        IUpdateProductCategoryCommandHandler updateCategory,
        IRemoveProductCategoryCommandHandler removeCategory)
    {
        _createProduct = createProduct;
        _getAllProduct = getAllProduct;
        _getProduct = getProduct;
        _addCategory = addCategory;
        _removeProduct = removeProduct;
        _updateProduct = updateProduct;
        _updateCategory = updateCategory;
        _removeCategory = removeCategory;
    }

    private readonly ICreateProductCommandHandler _createProduct;
    public ICreateProductCommandHandler CreateProduct
        => _createProduct;

    private readonly IGetAllProductQueryHandler _getAllProduct;
    public IGetAllProductQueryHandler GetAllProduct
        => _getAllProduct;


    private readonly IGetProductQueryHandler _getProduct;
    public IGetProductQueryHandler GetProduct
        => _getProduct;


    private readonly IRemoveProductCommandHandler _removeProduct;
    public IRemoveProductCommandHandler RemoveProduct
        => _removeProduct;


    private readonly IAddProductCategoryCommandHandler _addCategory;
    public IAddProductCategoryCommandHandler AddCategory
        => _addCategory;


    private readonly IUpdateProductCommandHandler _updateProduct;
    public IUpdateProductCommandHandler UpdateProduct
        => _updateProduct;

    private readonly IUpdateProductCategoryCommandHandler _updateCategory;
    public IUpdateProductCategoryCommandHandler UpdateCategory
        => _updateCategory;

    private readonly IRemoveProductCategoryCommandHandler _removeCategory;
    public IRemoveProductCategoryCommandHandler RemoveCategory
        => _removeCategory;
}