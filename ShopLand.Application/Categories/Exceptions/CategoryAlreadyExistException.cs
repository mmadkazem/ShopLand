namespace ShopLand.Application.Categories.Exceptions;


public sealed class CategoryAlreadyExistException()
    : ShopLandBadRequestBaseExceptions("this category already exist.");