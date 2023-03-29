using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace App
{
    public partial class Database
    {
        public string GetTimeStamp(Guid customerID)
        {
            var order = GetOrder(customerId: customerID.ToString());
            return order[0].creationTimestamp;
        }

        //Get one customer same as ID
        public List<Person> GetPerson(uint customerID)
        {
            string queryString = $"SELECT * FROM dbo.Persons WHERE (Id = {customerID})";

            SqlCommand command = new SqlCommand(queryString, connection);

            command.ExecuteNonQuery();

            List<Person> person = new List<Person> { };

            using (SqlDataReader reader = command.ExecuteReader())
            {
                App.Role role;
                Enum.TryParse<App.Role>(Convert.ToString(reader[6]), out role);

                Guid id;
                Guid.TryParse(Convert.ToString(reader[0]), out id);


                while (reader.Read())
                {
                    person.Add(new Person(
                        id,
                        Convert.ToString(reader[1]),
                        Convert.ToString(reader[2]),
                        Convert.ToString(reader[3]),
                        Convert.ToString(reader[4]),
                        JsonConvert.DeserializeObject<Adress>(Convert.ToString(reader[5])), //Adress personAdress
                        role,
                        Convert.ToString(reader[7]) //Sales timeStamp
                        ));
                }
            }
            return person;
        }

        //Get alle customers
        public List<Person> GetPersons()
        {
            string queryString = "SELECT * FROM dbo.Persons";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();

            List<Person> person = new List<Person> { };

            using (SqlDataReader reader = command.ExecuteReader())
            {

                App.Role role;
                Enum.TryParse<App.Role>(Convert.ToString(reader[6]), out role);

                Guid id;
                Guid.TryParse(Convert.ToString(reader[0]), out id);

                while (reader.Read())
                {
                    person.Add(new Person(
                        id,
                        Convert.ToString(reader[1]),
                        Convert.ToString(reader[2]),
                        Convert.ToString(reader[3]),
                        Convert.ToString(reader[4]),
                        JsonConvert.DeserializeObject<Adress>(Convert.ToString(reader[5])), //Adress personAdress
                        role,
                        Convert.ToString(reader[7]) //Sales timeStamp
                        ));
                }
            }
            return person;
        }


        //Add Customer
        public void InsertPerson(Person person)
        {
            string queryString = $"INSERT INTO dbo.Persons VALUES ('{person.id.ToString()}', '{person.firstName}', '{person.lastName}', '{person.phone}', '{person.mail}', '{JsonConvert.SerializeObject(person.address)}', '{person.role.ToString()}', '{person.creationTimeStamp}')";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        //Update Customer
        public void UpdatePerson(Person person)
        {
            string queryString = $"UPDATE dbo.Persons SET (FirstName='{person.firstName}', LastName='{person.lastName}', PhoneNumber='{person.phone}', Mail='{person.mail}', Addres='{JsonConvert.SerializeObject(person.address)}', WHERE Id={person.id}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        //Delete Customer
        public void DeletePerson(Person person)
        {
            string queryString = $"DELETE FROM dbo.Persons WHERE Id={person.id}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }
    }
}