using Xunit;
using App;

namespace Test
{
    public class PersonTest
    {
        [Fact]
        public void TestPerson()
        {
            Person person = new Person("Tom", "Jensen", "12345678", "tom@jensen.dk", new Address("Denmark", "9000", "Aalborg", "Aalborgvej", "71"), Role.Customer);
            Assert.NotNull(person);
            Assert.Equal("Tim ", person.firstName);
            Assert.Equal("Jensen", person.lastName);
        }
    }
}