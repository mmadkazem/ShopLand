namespace ShopLand.Application.Categories.Commands.UpdateCategory.Request;

public readonly record struct UpdateCategoryCommandRequest(Guid Id, string Name);