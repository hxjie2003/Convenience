using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.ETM.Sdk
{
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;

    public static class DataHelper
    {
        /// <summary>
        /// EF SQL 语句返回 dataTable
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable SqlQueryForDataTatable(this Database db,
                 string sql,
                 SqlParameter[] parameters)
        {
            Oracle.ManagedDataAccess.Client.OracleConnection conn = new Oracle.ManagedDataAccess.Client.OracleConnection(db.Connection.ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(sql, conn);

            if (parameters.Length > 0)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }

            Oracle.ManagedDataAccess.Client.OracleDataAdapter adapter = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
