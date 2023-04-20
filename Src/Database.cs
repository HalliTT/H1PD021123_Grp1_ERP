using K4os.Compression.LZ4.Encoders;
using Microsoft.Data.SqlClient;
using SqlException = System.Data.SqlClient.SqlException;

namespace App
{
    public partial class Database
    {
        public Database()
        {
            SqlConnectionStringBuilder sqlBuilder = new();
            sqlBuilder.DataSource = "192.168.1.70";
            sqlBuilder.InitialCatalog = "H1PD021123_Gruppe1";
            sqlBuilder.TrustServerCertificate = true;
            sqlBuilder.IntegratedSecurity = false;
            sqlBuilder.UserID = "H1PD021123_Gruppe1";
            sqlBuilder.Password = "H1PD021123_Gruppe1";
            sqlBuilder.TrustServerCertificate = true;
            sqlBuilder.IntegratedSecurity = false;

            _connection = new SqlConnection(sqlBuilder.ToString());

            bool retry = true;

            while (retry)
            {
                try
                {
                    _connection = new SqlConnection(sqlBuilder.ToString());
                    connection.Open();
                    retry = false;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("An error occurred while connecting to the database:");
                    Console.WriteLine(ex.Message);

                    Console.WriteLine("Do you want to retry the connection? (Y/N)");
                    string input = Console.ReadLine()?.ToUpperInvariant();
                    switch (input)
                    {
                        case "Y":
                            retry = true;
                            Console.Clear();
                            break;
                        case "N":
                            retry = false;
                            Console.WriteLine("Quitting...");
                            Thread.Sleep(3000);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Output. Try again.");
                            retry = true;
                            Console.Clear();
                            break;
                    }
                }
            }
        }

        // Destructor
        ~Database()
        {
            //_connection.Close(); 
        }

        protected bool _status;
        public bool status
        {
            get { return _status; }
        }

        protected SqlConnection _connection = null!;
        public SqlConnection connection
        {
            get { return _connection; }
        }
    }
}