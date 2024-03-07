namespace ShopLand.Application.Products.Commands.UpdateProductCategory.Request;

public record UpdateProductCategoryCommandRequest
(
    Guid ProductId,
    Guid oldCategory,
    Guid newCategory
);