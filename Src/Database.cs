using Microsoft.Data.SqlClient;
using TECHCOOL;

namespace App
{
    public partial class Database
    {
        public Database()
        {
            SQLet.ConnectSqlServer("H1PD021123_Gruppe1", "docker.data.techcollege.dk", "H1PD021123_Gruppe1", "H1PD021123_Gruppe1");
            Console.WriteLine("Successfully connected to db");
            
        }
    }
}