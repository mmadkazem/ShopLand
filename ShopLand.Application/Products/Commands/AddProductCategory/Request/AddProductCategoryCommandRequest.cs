namespace ShopLand.Application.Products.Commands.AddProductCategory.Request;


public readonly record struct AddProductCategoryCommandRequest(Guid ProductId, Guid CategoryId);