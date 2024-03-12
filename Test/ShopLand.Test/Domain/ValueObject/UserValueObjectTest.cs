namespace ShopLand.Test.Domain.ValueObject;

public class UserValueObjectTest
{
    [Fact]
    public void UserId_Throw_UserIdEmptyException_When_There_Is_User_ID_Cannot_Be_Empty()
    {
        // ACT and ASSERT
        Assert.Throws<UserIdEmptyException>(() => new UserId(Guid.Empty));
    }


    [Fact]
    public void Email_Throw_InvalidEmailException_When_There_Is_Email_Not_Valid()
    {
        // ACT and ASSERT
        Assert.Throws<InvalidEmailException>(() => new Email("invalid argument"));
    }

    [Fact]
    public void FullName_Throw_FullNameNullOrWhiteSpaceException_When_There_Is_FullName_Cannot_Be_Empty_Or_Null()
    {
        // ACT and ASSERT
        Assert.Throws<FullNameNullOrWhiteSpaceException>(() => FullName.Create(null));
        Assert.Throws<FullNameNullOrWhiteSpaceException>(() => FullName.Create("  "));
    }

    [Fact]
    public void Password_Throw_InvalidUserPasswordException_When_There_Is_Password_Should_Not_Be_Empty()
    {
        // ACT and ASSERT
        var message = Assert
            .Throws<InvalidUserPasswordException>(() => new Password("", "")).Message;
        Assert.Equal("Password should not be empty.", message);
    }

    [Fact]
    public void Password_Throw_InvalidUserPasswordException_When_There_Is_Password_Not_Equals_In_ConfirmPassword()
    {
        // ACT and ASSERT
        var message = Assert.Throws<InvalidUserPasswordException>(() => new Password("@@Test1@@", "@@Test2@@")).Message;
        Assert.Equal("This password not equals in confirm password.", message);
    }

    [Fact]
    public void Password_Throw_InvalidUserPasswordException_When_There_Is_Password_Should_Contain_At_Least_One_Lower_Case_Letter()
    {
        // ACT and ASSERT
        var message = Assert.Throws<InvalidUserPasswordException>(() => new Password("@@TEST1@@", "@@TEST1@@")).Message;
        Assert.Equal("Password should contain at least one lower case letter. & ", message);
    }

    [Fact]
    public void Password_Throw_InvalidUserPasswordException_When_There_Is_Password_Should_Contain_At_Least_One_Upper_Case_Letter()
    {
        // ACT and ASSERT
        var message = Assert.Throws<InvalidUserPasswordException>(() => new Password("@@test1@@", "@@test1@@")).Message;
        Assert.Equal("Password should contain at least one upper case letter. & ", message);
    }

    [Fact]
    public void Password_Throw_InvalidUserPasswordException_When_There_Is_Password_Should_Not_Be_Lesser_Than_8_Or_Greater_Than_15_Characters()
    {
        // ACT and ASSERT
        var message1 = Assert.Throws<InvalidUserPasswordException>(() => new Password("@Test1@", "@Test1@")).Message;
        Assert.Equal("Password should not be lesser than 8 or greater than 15 characters. & ", message1);
    }

    [Fact]
    public void Password_Throw_InvalidUserPasswordException_When_There_Is_Password_Should_Contain_At_Least_One_Numeric_Value()
    {
        // ACT and ASSERT
        var message = Assert.Throws<InvalidUserPasswordException>(() => new Password("@@Test@@", "@@Test@@")).Message;
        Assert.Equal("Password should contain at least one numeric value. & ", message);
    }

    [Fact]
    public void Password_Throw_InvalidUserPasswordException_When_There_Is_Password_Should_Contain_At_Least_One_Special_Case_Character()
    {
        // ACT and ASSERT
        var message = Assert.Throws<InvalidUserPasswordException>(() => new Password("TestTest11", "TestTest11")).Message;
        Assert.Equal("Password should contain at least one special case character. & ", message);
    }
}