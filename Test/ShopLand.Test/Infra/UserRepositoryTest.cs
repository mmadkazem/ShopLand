namespace ShopLand.Test.Infra;


public class UserRepositoryTest
{

    [Fact]
    public void Should_Add_User_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAddUserTest", b => b.EnableNullChecks(false))
                .Options;

        var user = new User(Guid.NewGuid(), FullName.Create("TestFistName,TestLastName"), "Test@Test.com", "@@Test11@@");

        using var context = new DataBaseContext(dbOptions);
        var userRepository = new UserRepository(context);

        //ACT
        userRepository.Add(user);
        context.SaveChanges();

        //ASSERT
        var userResult = context.Users.Where(u => u.Id == user.Id).FirstOrDefault();

        Assert.Equal(user.Id, userResult?.Id);
        Assert.Equal(user.FullName.ToString(), userResult?.FullName.ToString());
        Assert.Equal(user.Email, userResult?.Email);
    }

    [Fact]
    public async void Should_FideAsync_User_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFideAsyncTest", b => b.EnableNullChecks(false))
                .Options;

        var user = new User(Guid.NewGuid(), FullName.Create("TestFistName,TestLastName"), "Test@Test.com", "@@Test11@@");

        using var context = new DataBaseContext(dbOptions);
        var userRepository = new UserRepository(context);
        userRepository.Add(user);
        context.SaveChanges();

        //ACT
        var userResult = await userRepository.FindAsync(user.Id);

        //ASSERT

        Assert.Equal(user.Id, userResult.Id);
        Assert.Equal(user.FullName.ToString(), userResult.FullName.ToString());
        Assert.Equal(user.Email, userResult.Email);
    }

    [Fact]
    public async void Should_FideAsync_By_Email_User_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFindAsyncByEmailTest", b => b.EnableNullChecks(false))
                .Options;

        var user = new User(Guid.NewGuid(), FullName.Create("TestFistName,TestLastName"), new Email("Test@Test.com"), "@@Test11@@");

        using var context = new DataBaseContext(dbOptions);
        var userRepository = new UserRepository(context);
        userRepository.Add(user);
        context.SaveChanges();

        //ACT
        var userResult = await userRepository.FindAsyncByEmail(user.Email);

        //ASSERT

        Assert.Equal(user.Id.Value, userResult.Id.Value);
        Assert.Equal(user.FullName.ToString(), userResult.FullName.ToString());
        Assert.Equal(user.Email, userResult.Email);
    }

    [Fact]
    public async void Should_GetAll_User_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldGetAllTest", b => b.EnableNullChecks(false))
                .Options;

        var user1 = new User(Guid.NewGuid(), FullName.Create("TestFistName1,TestLastName1"), "Test@Test.com", "@@Test11@@");
        var user2 = new User(Guid.NewGuid(), FullName.Create("TestFistName2,TestLastName2"), "Test@Test.com", "@@Test11@@");

        using var context = new DataBaseContext(dbOptions);
        var userRepository = new UserRepository(context);
        userRepository.Add(user1);
        userRepository.Add(user2);
        context.SaveChanges();

        //ACT
        var users = await userRepository.GetAll(5, 1);

        //ASSERT

        Assert.Equal(2, users.Count());
        Assert.Contains(users, q => q.Id == user1.Id);
        Assert.Contains(users, q => q.Id == user2.Id);
        Assert.DoesNotContain(users, q => q.Id == new UserId(Guid.NewGuid()));
    }

    [Fact]
    public async void Should_Any_User_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAnyTest", b => b.EnableNullChecks(false))
                .Options;

        var user = new User(Guid.NewGuid(), FullName.Create("TestFistName,TestLastName"), "Test@Test.com", "@@Test11@@");

        using var context = new DataBaseContext(dbOptions);
        var userRepository = new UserRepository(context);
        userRepository.Add(user);
        context.SaveChanges();

        //ACT
        var result1 = await userRepository.Any(user.Id);
        var result2 = await userRepository.Any(Guid.NewGuid());

        //ASSERT

        Assert.True(result1);
        Assert.False(result2);
    }

    [Fact]
    public async void Should_FindAsync_UserRole_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFindAsyncUserRoleTest", b => b.EnableNullChecks(false))
                .Options;

        var user1 = new User();
        var user2 = new User();
        var user3 = new User();
        var role = Guid.NewGuid();
        user1.AddRole(role);
        user2.AddRole(role);
        user3.AddRole(role);

        using var context = new DataBaseContext(dbOptions);
        var userRepository = new UserRepository(context);
        userRepository.Add(user1);
        userRepository.Add(user2);
        userRepository.Add(user3);
        context.SaveChanges();

        //ACT
        var userRoles = await userRepository.FindAsyncUserRole(role);

        //ASSERT

        Assert.Equal(3, userRoles.Count());
        Assert.Contains(userRoles, u => u.UserId == user1.Id);
        Assert.Contains(userRoles, u => u.Role == role);
        Assert.DoesNotContain(userRoles, u => u.UserId == new UserId(Guid.NewGuid()));
        Assert.DoesNotContain(userRoles, u => u.Role == Guid.NewGuid());
    }

    [Fact]
    public async void Should_Remove_User_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldRemoveUserTest", b => b.EnableNullChecks(false))
                .Options;

        var user = new User(Guid.NewGuid(), FullName.Create("TestFistName,TestLastName"), "Test@Test.com", "@@Test11@@");

        using var context = new DataBaseContext(dbOptions);
        var userRepository = new UserRepository(context);
        userRepository.Add(user);
        context.SaveChanges();

        //ACT
        userRepository.Remove(user);
        context.SaveChanges();

        //ASSERT
        var result = await userRepository.Any(user.Id);
        Assert.False(result);
    }

}