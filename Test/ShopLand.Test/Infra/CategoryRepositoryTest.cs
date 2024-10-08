using ShopLand.Domain.Products.Category_Aggregate.ValueObject;

namespace ShopLand.Test.Infra;


public class CategoryRepositoryTest
{
    [Fact]
    public void Should_Add_Category_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAddCategoryTest", b => b.EnableNullChecks(false))
                .Options;

        var category = new Category(Guid.NewGuid(), "TestCategoryName");

        using var context = new DataBaseContext(dbOptions);
        var categoryRepository = new CategoryRepository(context);

        //ACT
        categoryRepository.Add(category);
        context.SaveChanges();

        //ASSERT
        var result = context.Categories.Where(p => p.Id == category.Id).FirstOrDefault();

        Assert.Equal(category.Id, result?.Id);
        Assert.Equal(category.CategoryName, result?.CategoryName);
    }

    [Fact]
    public async void Should_FideAsync_Category_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFideAsyncTest", b => b.EnableNullChecks(false))
                .Options;

        var category = new Category(Guid.NewGuid(), "TestCategoryName");

        using var context = new DataBaseContext(dbOptions);
        var categoryRepository = new CategoryRepository(context);
        categoryRepository.Add(category);
        context.SaveChanges();

        //ACT
        var result = await categoryRepository.FindAsync(category.Id);

        //ASSERT

        Assert.Equal(category.Id, result.Id);
        Assert.Equal(category.CategoryName, result.CategoryName);
    }


    [Fact]
    public async void Should_Any_Category_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAnyTest", b => b.EnableNullChecks(false))
                .Options;

        var category = new Category(Guid.NewGuid(), "TestCategoryName");

        using var context = new DataBaseContext(dbOptions);
        var categoryRepository = new CategoryRepository(context);
        categoryRepository.Add(category);
        context.SaveChanges();

        //ACT
        var result1 = await categoryRepository.Any(category.Id);
        var result2 = await categoryRepository.Any(Guid.NewGuid());

        //ASSERT

        Assert.True(result1);
        Assert.False(result2);
    }

    [Fact]
    public async void Should_Remove_Category_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldRemoveCategoryTest", b => b.EnableNullChecks(false))
                .Options;

        var category = new Category(Guid.NewGuid(), "TestCategoryName");

        using var context = new DataBaseContext(dbOptions);
        var categoryRepository = new CategoryRepository(context);
        categoryRepository.Add(category);
        context.SaveChanges();

        //ACT
        categoryRepository.Remove(category);
        context.SaveChanges();

        //ASSERT
        var result = await categoryRepository.Any(category.Id);
        Assert.False(result);
    }
}