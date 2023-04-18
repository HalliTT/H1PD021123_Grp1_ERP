using Microsoft.Data.SqlClient;

namespace App
{
    public partial class Database
    {
        public Database()
        {
            SqlConnectionStringBuilder sqlBuilder = new();
            sqlBuilder.DataSource = "docker.data.techcollege.dk";
            sqlBuilder.InitialCatalog = "H1PD021123_Gruppe1";
            sqlBuilder.TrustServerCertificate = true;
            sqlBuilder.IntegratedSecurity = false;
            sqlBuilder.UserID = "H1PD021123_Gruppe1";
            sqlBuilder.Password = "H1PD021123_Gruppe1";
            sqlBuilder.TrustServerCertificate = true;
            sqlBuilder.IntegratedSecurity = false;

            _connection = new SqlConnection(sqlBuilder.ToString());
            _connection.Open();

        }

        // Destructor
        ~Database() 
        { 
            _connection.Close(); 
        }

        protected SqlConnection _connection = null!;
        public SqlConnection connection
        {
            get { return _connection; }
        }
    }
}