namespace ShopLand.Application.Products.Commands.RemoveProductCategory.Request;

public record RemoveProductCategoryCommandRequest(Guid ProductId, Guid CategoryId);