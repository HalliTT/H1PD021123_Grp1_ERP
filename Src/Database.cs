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

            this.connection = new SqlConnection(sqlBuilder.ToString());
            connection.Open();

        }

        // Destructor
        ~Database() 
        { 
            this.connection.Close(); 
        }

        protected SqlConnection _connection = null!;
        public SqlConnection connection
        {
            set { _connection = value; }
            get { return _connection; }
        }
    }
}