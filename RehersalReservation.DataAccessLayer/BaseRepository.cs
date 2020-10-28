using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehersalReservation.DataAccessLayer
{
    public class BaseRepository : IConnection
    {
        private readonly string connectionString;
        public string ConnectionString
        {
            get { return connectionString; }
        }
        public BaseRepository()
        {
            this.connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Rehersal"].ConnectionString;
        }
        public async Task<object> ExecuteProcedure(string procedureName, IEnumerable<SqlParameter> parameters,
                                      int commandTimeout = 45)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            object result = null;
            try
            {
                var sqlCommand = new SqlCommand(procedureName);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = commandTimeout;
                sqlCommand.Connection = connection;
                connection.Open();

                if (parameters != null && parameters.Any())
                {
                    sqlCommand.Parameters.AddRange(parameters.ToArray());
                }

                result = await sqlCommand.ExecuteScalarAsync();
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    connection.Dispose();
                }
            }

            return result;
        }
    }    
}
