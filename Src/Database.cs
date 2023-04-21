using System.Reflection.Emit;
using K4os.Compression.LZ4.Encoders;
using Microsoft.Data.SqlClient;
using SqlException = System.Data.SqlClient.SqlException;

namespace App
{
    public partial class Database
    {
        //TODO: Make proberty for SQL connection string
        static Database()
        {

        public string ConnectionString
        {
            get { return ConnectionString; }

            set
            {
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                sqlBuilder.DataSource = "";
                sqlBuilder.IntegratedSecurity = false;
                sqlBuilder.DataSource = "192.168.1.70";
                sqlBuilder.InitialCatalog = "H1PD021123_Gruppe1";
                sqlBuilder.TrustServerCertificate = true;
                sqlBuilder.IntegratedSecurity = false;
                sqlBuilder.UserID = "H1PD021123_Gruppe1";
                sqlBuilder.Password = "H1PD021123_Gruppe1";
                sqlBuilder.IntegratedSecurity = false;
                ConnectionString = sqlBuilder.ConnectionString;
            }
        }

        public void TestConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            while (connection == null || connection.State == System.Data.ConnectionState.Closed)
            {
                using (connection)
                {
                    try
                    {
                        Console.WriteLine("Connection is closed. Retrying...");
                        connection.Open();
                        Thread.Sleep(600);
                        Console.WriteLine("Connection established successfully!");

                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            Thread.Sleep(60);
                            Console.WriteLine("Connection is open and available.");
                            Console.Clear();
                        }
                        break;
                    }
                    catch (SqlException exception)
                    {
                        Console.WriteLine("An error occurred while connecting to the database:");
                        Console.WriteLine(exception.Message);
                        Console.WriteLine("Do you want to retry the connection? (Y/N)");
                        string input = Console.ReadLine()?.ToUpperInvariant();
                        switch (input)
                        {
                            case "Y":
                                Console.Clear();
                                break;
                            case "N":
                                Console.WriteLine("Quitting...");
                                Thread.Sleep(3000);
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid Output. Try again.");
                                Console.Clear();
                                break;
                        }
                    }
                }
            }
        }
    }



// Destructor
        ~Database() 
        { 
            _connection.Close(); 
        }

        protected bool _status;
        public bool status
        {
            get { return _status; }
        }
        
        static protected SqlConnection _connection = null!;
        public SqlConnection connection
        {
            get { return _connection; }
        }
    }
}