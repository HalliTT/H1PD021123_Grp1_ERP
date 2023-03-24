using Microsoft.Data.SqlClient;
using TECHCOOL;

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
            this.connectionStr = sqlBuilder.ToString();
        }


        protected string _connectionStr;
        public string connectionStr
        {
            set { _connectionStr = value; }
            get { return _connectionStr; }
        }
    }
}