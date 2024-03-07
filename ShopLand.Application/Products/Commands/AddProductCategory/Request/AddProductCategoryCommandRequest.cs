namespace ShopLand.Application.Products.Commands.AddProductCategory.Request;


public record AddProductCategoryCommandRequest(Guid ProductId, Guid Category);