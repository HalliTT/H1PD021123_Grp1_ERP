using Xunit;
using App;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void TestCompany()
    {
        Company company = new Company() {id = 1};
        Assert.NotNull(company);
    }
    [Fact]
    public void Test1()
    {
    }
}