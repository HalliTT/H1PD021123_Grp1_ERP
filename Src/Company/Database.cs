using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace App
{
    public partial class Database
    {
        public List<Company> GetCompany(int CompanyId = 0)
        {
            string queryString = "";
            if (CompanyId > 0)
            {
                queryString = $"SELECT * FROM dbo.Company WHERE (Id LIKE '{CompanyId}')";
            }
            else
            {
                queryString = "SELECT * FROM dbo.Companies";
            }


            SqlCommand command = new SqlCommand(queryString, connection);

            command.ExecuteNonQuery();

            List<Company> company = new List<Company> { };

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Trying to parse string to enum<currency>
                    App.Currency currency;
                    Enum.TryParse<App.Currency>(Convert.ToString(reader[7]), out currency);

                    company.Add(new Company(
                        Convert.ToInt32(reader[0]),
                        Convert.ToString(reader[1]),
                        Convert.ToString(reader[2]),
                        Convert.ToString(reader[3]),
                        Convert.ToString(reader[4]),
                        Convert.ToString(reader[5]),
                        Convert.ToString(reader[6]),
                        currency, //currency
                        Convert.ToString(reader[8]),
                        Convert.ToString(reader[9])
                    ));
                }
            }

            return company;
        }

        // add
        public void InsertCompany(Company company)
        {
            string queryString =
                $"INSERT INTO dbo.Companies VALUES ('{company.name}', '{company.road}', '{company.houseNumber}', '{company.zipCode}', '{company.city}', '{company.country}', '{company.currency.ToString()}', '{company.cvr}', '{company.email}')";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        // update
        public void UpdateCompany(Company company)
        {
            string queryString =
                $"UPDATE dbo.Companies SET Name='{company.name}', Road='{company.road}', HouseNumber='{company.houseNumber}', ZipCode='{company.zipCode}', Country='{company.country}', Currency='{company.currency.ToString()}', Cvr='{company.cvr}', Email='{company.email}' WHERE Id={company.id}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }

        // delete
        public void DeleteCompany(Company company)
        {
            string queryString = $"DELETE FROM dbo.Companies WHERE Id={company.id}";

            SqlCommand command = new SqlCommand(queryString, this.connection);

            command.ExecuteNonQuery();
        }
    }
}
