using Xunit;
using App;

namespace Test
{
    public class ProductTest
    {
        [Fact]
        public void TestProduct()
        {
            var person = new Product() { name = "Kaffe" };

            Assert.NotNull(person);
            Assert.Equal("Kaffe", person.name);
        }
    }
}