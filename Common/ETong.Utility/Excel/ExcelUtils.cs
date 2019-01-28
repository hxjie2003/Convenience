using System;
using System.Data;
using System.Data.OleDb;

namespace ETong.Utility.Excel
{
    public class ExcelUtils
    {
        /// <summary>
        /// 转换excel为DataSet，工作表名必须传递
        /// </summary>
        /// <param name="filePath">Excel文件路径</param>
        /// <param name="where">查询条件</param>
        /// <param name="sheetName">工作表名</param>
        /// <returns></returns>
        public static DataSet GetDataSetFromExcel(string filePath, string where, string sheetName)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
            using (OleDbConnection OleConn = new OleDbConnection(strConn))
            {
                DataSet ds = new DataSet();
                try
                {
                    OleConn.Open();
                    string strSql = "SELECT * FROM [" + sheetName + "$] t1 ";
                    if (where.Length > 0)
                    {
                        strSql += where;
                    }
                    OleDbCommand cmd = new OleDbCommand(strSql, OleConn);
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(cmd))
                    {
                        OleDaExcel.Fill(ds, "DataSet");
                    }
                }
                catch (Exception ex)
                {
                    ds = null;
                    ETong.Utility.Log.Logger.Write(ETong.Common.Enum.Log.Log_Type.Error, "读取xls文件异常:" + ex.ToString());
                }
                return ds;
            }
        }
    }
}
