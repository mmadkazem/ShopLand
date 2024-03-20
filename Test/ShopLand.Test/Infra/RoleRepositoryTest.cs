namespace ShopLand.Test.Infra;

public class RoleRepositoryTest
{
    [Fact]
    public void Should_Add_Role_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAddRoleTest", b => b.EnableNullChecks(false))
                .Options;

        var role = new Role(Guid.NewGuid(), "TestName");

        using var context = new DataBaseContext(dbOptions);
        var roleRepository = new RoleRepository(context);

        //ACT
        roleRepository.Add(role);
        context.SaveChanges();

        //ASSERT
        var userResult = context.Roles.Where(u => u.Id == role.Id).FirstOrDefault();

        Assert.Equal(role.Id, userResult?.Id);
        Assert.Equal(role.Name, userResult?.Name);
    }

    [Fact]
    public async void Should_FideAsync_Role_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFideAsyncTest", b => b.EnableNullChecks(false))
                .Options;

        var role = new Role(Guid.NewGuid(), "TestName");

        using var context = new DataBaseContext(dbOptions);
        var roleRepository = new RoleRepository(context);
        roleRepository.Add(role);
        context.SaveChanges();

        //ACT
        var userResult = await roleRepository.FindAsync(role.Id);

        //ASSERT

        Assert.Equal(role.Id, userResult.Id);
        Assert.Equal(role.Name, userResult.Name);
    }

    [Fact]
    public async void Should_FideAsync_By_Name_User_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldFideAsyncByNameTest", b => b.EnableNullChecks(false))
                .Options;

        var role = new Role(Guid.NewGuid(), "TestName");

        using var context = new DataBaseContext(dbOptions);
        var roleRepository = new RoleRepository(context);
        roleRepository.Add(role);
        context.SaveChanges();

        //ACT
        var userResult = await roleRepository.FindAsyncByName(role.Name);

        //ASSERT

        Assert.Equal(role.Id, userResult.Id);
        Assert.Equal(role.Name, userResult.Name);
    }

    [Fact]
    public async void Should_GetAll_Role_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldGetAllTest", b => b.EnableNullChecks(false))
                .Options;

        var role1 = new Role(Guid.NewGuid(), "TestName1");
        var role2 = new Role(Guid.NewGuid(), "TestName2");

        using var context = new DataBaseContext(dbOptions);
        var roleRepository = new RoleRepository(context);
        roleRepository.Add(role1);
        roleRepository.Add(role2);
        context.SaveChanges();

        //ACT
        var roles = await roleRepository.GetAll(1);

        //ASSERT

        Assert.Equal(2, roles.Count());
        Assert.Contains(roles, q => q.Id == role1.Id);
        Assert.Contains(roles, q => q.Id == role2.Id);
        Assert.DoesNotContain(roles, q => q.Id == new RoleId(Guid.NewGuid()));
    }

    [Fact]
    public async void Should_Any_Role_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAnyTest", b => b.EnableNullChecks(false))
                .Options;

        var role = new Role(Guid.NewGuid(), "TestName");

        using var context = new DataBaseContext(dbOptions);
        var roleRepository = new RoleRepository(context);
        roleRepository.Add(role);
        context.SaveChanges();

        //ACT
        var result1 = await roleRepository.Any(role.Id);
        var result2 = await roleRepository.Any(Guid.NewGuid());

        //ASSERT

        Assert.True(result1);
        Assert.False(result2);
    }

    [Fact]
    public async void Should_Any_Role_By_Name_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAnyByNameTest", b => b.EnableNullChecks(false))
                .Options;

        var role = new Role(Guid.NewGuid(), "TestName");

        using var context = new DataBaseContext(dbOptions);
        var roleRepository = new RoleRepository(context);
        roleRepository.Add(role);
        context.SaveChanges();

        //ACT
        var result1 = await roleRepository.Any(role.Name);
        var result2 = await roleRepository.Any("TestName2");

        //ASSERT

        Assert.True(result1);
        Assert.False(result2);
    }

    [Fact]
    public async void Should_Remove_Role_In_DataBase()
    {
        //ARRANGE
        var dbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("ShouldAnyTest", b => b.EnableNullChecks(false))
                .Options;

        var role = new Role(Guid.NewGuid(), "TestName");

        using var context = new DataBaseContext(dbOptions);
        var roleRepository = new RoleRepository(context);
        roleRepository.Add(role);
        context.SaveChanges();

        //ACT
        roleRepository.Remove(role);
        context.SaveChanges();

        //ASSERT
        var result = await roleRepository.Any(role.Id);
        Assert.False(result);
    }
}