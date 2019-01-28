using System.Data;
using System.Data.OracleClient;

namespace ETong.DAO
{
    /// <summary>
    /// 
    /// </summary>
    public class OracleDataAccessHelper
    {
        private readonly string Connstr = string.Empty;

        public OracleDataAccessHelper()
        {
            //实例化时,从Config中取得连接字符串
            Connstr = "Data Source=KF02ETM;User Id=USER_TEST;Password=tESt2345;Integrated Security=no";
        }

        /// <summary>
        ///     执行Sql返回DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strSql)
        {
            try
            {
                using (var conn = new OracleConnection(Connstr))
                {
                    conn.Open();
                    var cmd = new OracleCommand(strSql, conn);
                    var oda = new OracleDataAdapter(cmd);
                    var ds = new DataSet();
                    oda.Fill(ds);

                    conn.Close();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        return ds.Tables[0];
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     返回第一行的第一列
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public object ExecScalar(string strSql)
        {
            try
            {
                using (var conn = new OracleConnection(Connstr))
                {
                    conn.Open();
                    var cmd = new OracleCommand(strSql, conn);
                    var obj = cmd.ExecuteOracleScalar();
                    conn.Close();
                    return obj;
                }
            }
            catch
            {
                return null;
            }
        }

        public void ExecNone(string strSql)
        {
            try
            {
                using (var conn = new OracleConnection(Connstr))
                {
                    conn.Open();
                    var cmd = new OracleCommand(strSql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch
            {
            }
        }
    }
}