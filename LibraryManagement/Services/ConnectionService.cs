using LibraryManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagement.Services
{
    internal class ConnectionService
    {
        private readonly SqlConnection sqlConnection;
        public ConnectionService() {
            sqlConnection = new SqlConnection(Constants.ConnectionString);
        }
    }
}
