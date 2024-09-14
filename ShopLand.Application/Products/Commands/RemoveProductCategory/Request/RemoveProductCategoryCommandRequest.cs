namespace ShopLand.Application.Products.Commands.RemoveProductCategory.Request;

public readonly  record struct RemoveProductCategoryCommandRequest(Guid ProductId, Guid CategoryId);