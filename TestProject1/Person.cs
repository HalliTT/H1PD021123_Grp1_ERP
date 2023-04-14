using Xunit;
using App;

namespace Test
{
    public class PersonTest
    {
        [Fact]
        public void TestPerson()
        {
            Person person = new Person() { id = 1, firstName = "leeroy ", lastName = "jenkins", phone = "Warrior", mail = "Dead", role = Role.Customer, creationTimeStamp = "May 2005", };
            Assert.NotNull(person);
            Assert.Equal("leeroy ", person.firstName);
            Assert.Equal("jenkins", person.lastName);
            Assert.Equal("leeroy jenkins", person.fullName);
            Assert.Equal("Warrior", person.phone);
            Assert.Equal("Dead", person.mail);
            // Assert.Equal("testCountry", person.address);
            Assert.Equal(Role.Customer, person.role);
            Assert.Equal("May 2005", person.creationTimeStamp);
        }
    }
}