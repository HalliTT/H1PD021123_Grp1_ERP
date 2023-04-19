using Xunit;
using App;

namespace Test
{
    public class ProductTest
    {
        [Fact]
        public void TestProduct()
        {
            var person = new Product("Kaffe", "Hele bønner", 80, 130, "Kenya", 20, Unit.pieces);

            Assert.NotNull(person);
            Assert.Equal("Kaffe", person.name);
            Assert.Equal(130, person.purchasePrice);
        }
    }
}