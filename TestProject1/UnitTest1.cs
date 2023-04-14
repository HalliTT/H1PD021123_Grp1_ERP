using Xunit;
using App;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void TestCompany()
    {
        Company company = new Company() {id = 1, name = "testName",road = "testRoad", houseNumber = "testHouseNumber", city = "testCity", country = "testCountry", currency = Currency.EUR, cvr = "0330330",email = "test@testemail.com"};
        Assert.NotNull(company);
        Assert.Equal("testName", company.name);
        Assert.Equal("testRoad", company.road);
        Assert.Equal("testHouseNumber",company.houseNumber);
        Assert.Equal("testCity", company.city);
        Assert.Equal("testCountry", company.country);
        Assert.Equal(Currency.EUR, company.currency);       
        Assert.Equal("0330330", company.cvr);
        Assert.Equal("test@testemail.com", company.email);

    }
    [Fact]
    public void Test1()
    {
        CompanyList c = new CompanyList();
        Assert.NotNull(c.listCompany);
    }
}