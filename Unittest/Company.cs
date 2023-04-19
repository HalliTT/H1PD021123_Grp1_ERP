using Xunit;
using App;

namespace Test
{
    public class CompanyTest
    {
        [Fact]
        public void TestCompany()
        {
            Company company = new Company("Tom", "Aalborgvej", "50", "9000", "Aalborg", "Denmark", Currency.DKK, "42", "test@test.dk");
            Assert.NotNull(company);
            Assert.Equal("Tom", company.name);
            Assert.Equal("Aalborg", company.city);
            Assert.Equal(Currency.DKK, company.currency);
        }
    }
}