using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public class SqlServerDataModel : IDataModel
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["CmsCoreDB"].ConnectionString;

        public DataTable GetDataSource(string tableName, int categoryId, int pageIndex, int pageSize)
        {
            var selectCommand = string.Format(
                "SELECT TOP {0} * FROM {1} WHERE (ID NOT IN (SELECT TOP {2} ID FROM {3} where CATID={4} ORDER BY ID)) AND CATID={5} ORDER BY ID",
                pageSize,
                tableName,
                pageIndex * pageSize,
                tableName,
                categoryId,
                categoryId);

            return Query(selectCommand, _connectionString);
        }

        public int GetTotalCount(string tableName, int categoryId)
        {
            var selectCommand = string.Format("SELECT count(id) FROM {0} WHERE CATID={1}", tableName, categoryId);

            return Convert.ToInt32(Query(selectCommand, _connectionString).Rows[0][0]);
        }

        private static DataTable Query(string selectCommand, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sqlDataAdapter = new SqlDataAdapter(selectCommand, connection);

                var dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                sqlDataAdapter.Dispose();

                connection.Close();

                return dt;
            }
        }
    }
}