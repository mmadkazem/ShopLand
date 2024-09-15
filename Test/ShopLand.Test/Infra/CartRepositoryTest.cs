namespace ShopLand.Test.Infra;


public class CartRepositoryTest
{
    [Fact]
    public void Should_Add_Cart_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAddCartTest", b => b.EnableNullChecks(false))
                .Options;

        var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());

        using var context = new DataBaseContext(dbOptions);
        var cartRepository = new  CartRepository(context);

        //ACT
        cartRepository.Add(cart);
        context.SaveChanges();

        //ASSERT
        var result = context.Carts.Where(u => u.Id == cart.Id).FirstOrDefault();

        Assert.Equal(cart.Id.ToString(), Guid.NewGuid().ToString());
        Assert.Equal(cart.UserId, result?.UserId);
    }

    [Fact]
    public async void Should_FideAsync_Cart_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFideAsyncTest", b => b.EnableNullChecks(false))
                .Options;

        var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());

        using var context = new DataBaseContext(dbOptions);
        var cartRepository = new  CartRepository(context);
        cartRepository.Add(cart);
        context.SaveChanges();

        //ACT
        var result = await cartRepository.FindAsync(cart.Id);

        //ASSERT

        Assert.Equal(cart.Id, result?.Id);
        Assert.Equal(cart.UserId, result?.UserId);
    }

    [Fact]
    public async void Should_FideAsync_By_UserId_Cart_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFindAsyncByUserIdTest", b => b.EnableNullChecks(false))
                .Options;

        var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());

        using var context = new DataBaseContext(dbOptions);
        var cartRepository = new  CartRepository(context);
        cartRepository.Add(cart);
        context.SaveChanges();

        //ACT
        var result = await cartRepository.FindAsyncByUserId(cart.UserId);

        //ASSERT

        Assert.Equal(cart.Id, result?.Id);
        Assert.Equal(cart.UserId, result?.UserId);
    }

    [Fact]
    public async void Should_FindAsync_CartItem_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFindAsyncCartItemTest", b => b.EnableNullChecks(false))
                .Options;

        var cart1 = new Cart();
        var cart2 = new Cart();
        var cart3 = new Cart();
        var productId = Guid.NewGuid();
        cart1.AddCartItem(productId, 5, 10, 10_000);
        cart2.AddCartItem(productId, 5, 10, 10_000);
        cart3.AddCartItem(productId, 5, 10, 10_000);

        using var context = new DataBaseContext(dbOptions);
        var cartRepository = new CartRepository(context);
        cartRepository.Add(cart1);
        cartRepository.Add(cart2);
        cartRepository.Add(cart3);
        context.SaveChanges();

        //ACT
        var userRoles = await cartRepository.FindAsyncCartItem(productId);

        //ASSERT

        Assert.Equal(3, userRoles.Count());
        Assert.Contains(userRoles, c => c.CartId == cart1.Id);
        Assert.Contains(userRoles, c => c.CartId == cart2.Id);
        Assert.Contains(userRoles, c => c.CartId == cart2.Id);
        Assert.Contains(userRoles, c => c.ProductId == productId);
        Assert.DoesNotContain(userRoles, c => c.CartId == new CartId(Guid.NewGuid()));
        Assert.DoesNotContain(userRoles, c => c.ProductId == Guid.NewGuid());
    }

    [Fact]
    public async void Should_Remove_Cart_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldRemoveCartTest", b => b.EnableNullChecks(false))
                .Options;

        var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());

        using var context = new DataBaseContext(dbOptions);
        var cartRepository = new  CartRepository(context);
        cartRepository.Add(cart);
        context.SaveChanges();

        //ACT
        cartRepository.Remove(cart);
        context.SaveChanges();

        //ASSERT
        var result = await cartRepository.FindAsync(cart.Id);
        Assert.Null(result);
    }
}