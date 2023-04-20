using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace App
{
    public partial class Database
    {
        public string GetTimeStamp(int customerId = 0)
        {
            var order = GetOrder(customerId: customerId);
            return order[0].creationTimestamp;
        }

        //Get one customer same as ID
        public List<Person> GetPerson(int customerId = 0)
        {
            string queryString = "";
            if (customerId > 0)
            {
                queryString = $"SELECT * FROM dbo.Persons WHERE Id IS '{customerId}'";
            }
            else
            {
                queryString = $"SELECT * FROM dbo.Persons";
            }

            SqlCommand command = new SqlCommand(queryString, connection);

            command.ExecuteNonQuery();

            List<Person> person = new List<Person> { };

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Trying to parse string to enum<Role>
                    Role role;
                    Enum.TryParse<Role>(Convert.ToString(reader[6]), out role);

                    var obj = new Person(
                        Convert.ToInt32(reader[0]),
                        Convert.ToString(reader[1]),
                        Convert.ToString(reader[2]),
                        Convert.ToString(reader[3]),
                        Convert.ToString(reader[4]),
                        JsonConvert.DeserializeObject<Address>(Convert.ToString(reader[5])), //Address personAddress
                        role,
                        Convert.ToString(reader[7]));

                    person.Add(obj);                    
                }
            }
            return person;
        }

        //Add Customer
        public void InsertPerson(Person person)
        {
            string queryString = $"INSERT INTO dbo.Persons VALUES ('{person.firstName}', '{person.lastName}', '{person.phone}', '{person.email}', '{JsonConvert.SerializeObject(person.address)}', '{person.role.ToString()}', '{person.creationTimeStamp}')";

            SqlCommand command = new SqlCommand(queryString, _connection);

            command.ExecuteNonQuery();
        }

        //Update Customer
        public void UpdatePerson(Person person)
        {
            var address = new Address(person.addressCountry, person.addressZipCode, person.addressCity, person.addressRoadName, person.addressDoorNumber);

            string queryString = $"UPDATE dbo.Persons SET FirstName='{person.firstName}', LastName='{person.lastName}', PhoneNumber='{person.phone}', Mail='{person.email}', Address='{JsonConvert.SerializeObject(address)}' WHERE Id={person.id}";

            SqlCommand command = new SqlCommand(queryString, _connection);

            command.ExecuteNonQuery();
        }

        //Delete Customer
        public void DeletePerson(Person person)
        {
            string queryString = $"DELETE FROM dbo.Persons WHERE Id={person.id}";

            SqlCommand command = new SqlCommand(queryString, _connection);

            command.ExecuteNonQuery();
        }
    }
}