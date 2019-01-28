using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ETong.Utility.Comunication
{
    /// <summary>
    /// TcpClient 工具类
    /// </summary>
    public class TcpClient
    {
        private string ip;
        private int port;
        private int tryTimes;
        private bool longConnection;
        private System.Net.Sockets.TcpClient client;
        private Exception lastException;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">IP 地址</param>
        /// <param name="port">端口</param>
        /// <param name="tryTimes">重试次数</param>
        /// <param name="longConnection">是否长连接</param>
        public TcpClient(string ip, int port, int tryTimes, bool longConnection)
        {
            this.ip = ip;
            this.port = port;
            this.tryTimes = tryTimes;
            this.longConnection = longConnection;
        }

        /// <summary>
        /// 获取最后的错误信息
        /// </summary>
        public Exception LastException
        {
            get { return this.lastException; }
        }

        /// <summary>
        /// 实例化TcpClient并建立连接
        /// </summary>
        /// <returns></returns>
        private bool TryConnect()
        {
            for (int i = 0; i < tryTimes; i++)
            {
                try
                {
                    client = new System.Net.Sockets.TcpClient(this.ip, this.port);
                    return true;
                }
                catch (Exception ex)
                {
                    this.lastException = ex;
                }
            }
            return false;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        private void TryClose()
        {
            if (!longConnection)
            {
                if (client != null)
                {
                    if (client.Client != null)
                        client.Client.Close();
                    client.Close();
                }
                client = null;
            }
        }

        /// <summary>
        /// 发送字节数据
        /// </summary>
        /// <param name="data">待发送的数据</param>
        /// <returns></returns>
        private bool TrySend(byte[] data)
        {
            for (int i = 0; i < tryTimes; i++)
            {
                try
                {
                    int size = client.Client.Send(data);
                    if (size > 0)
                    {
                        writeLog(Remark + "->发送成功,数据长度" + data.Length + ",已发送" + size.ToString());
                        return true;
                    }
                    else
                    {
                        writeLog(Remark + "->发送失败,数据长度" + data.Length + ",已发送" + size.ToString());
                        //    return false;
                    }
                }
                catch (Exception ex)
                {
                    this.TryConnect();
                    this.lastException = ex;
                    writeLog(Remark + "->发送异常,数据长度" + data.Length + ",异常信息:" + ex.ToString() + "->" + ex.StackTrace);
                }
            }
            //来到这里就表明发送失败了
            try
            {
                if (this.lastException == null)
                    throw new Exception("发送数据失败:数据长度" + data.Length + ",已发送长度0");
            }
            catch (Exception ex2)
            {
                this.lastException = ex2;
            }
            return false;
        }

        /// <summary>
        /// 接收字节数据
        /// </summary>
        /// <returns></returns>
        private byte[] TryReceive()
        {
            byte[] buf = new byte[8192];
            int size = 0;
            for (int i = 0; i < tryTimes; i++)
            {
                try
                {
                    size = client.Client.Receive(buf);
                    break;
                }
                catch (Exception ex)
                {
                    this.lastException = ex;
                    writeLog(Remark + "->接收数据异常:" + ex.ToString() + "->" + ex.StackTrace);
                }
            }
            //返回数据
            if (size > 0)
            {
                byte[] data = new byte[size];
                Array.Copy(buf, data, size);
                return data;
            }
            else
            {
                writeLog(Remark + "->接收数据长度为" + size.ToString());
            }
            return null;
        }

        /// <summary>
        /// 发送数据--未用
        /// </summary>
        /// <param name="sendData">待发送的数据</param>
        /// <returns></returns>
        public bool Send(byte[] sendData)
        {
            if (client == null)
            {
                //连接远程主机
                if (!TryConnect()) return false;
            }

            //发送数据
            bool result = TrySend(sendData);

            //关闭连接
            TryClose();
            return result;
        }
        /// <summary>
        /// 发送数据并接收数据
        /// </summary>
        /// <param name="sendData">待发送的数据</param>
        /// <returns></returns>
        public byte[] SendAndReceive(byte[] sendData)
        {
            if (client == null)
            {
                //连接远程主机
                if (!TryConnect()) return null;
            }

            byte[] data = null;
            //发送数据
            if (TrySend(sendData))
            {
                System.Threading.Thread.Sleep(30);
                //接收数据
                data = TryReceive();
                //给多一次机会
                if (data == null)
                {
                    System.Threading.Thread.Sleep(30);
                    data = TryReceive();
                }
            }

            //关闭连接
            TryClose();
            return data;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="content">日志内容</param>
        public void writeLog(string content)
        {
            System.IO.StreamWriter sw = null;
            try
            {
                string logDir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log";
                if (!System.IO.Directory.Exists(logDir))
                    System.IO.Directory.CreateDirectory(logDir);
                sw = System.IO.File.AppendText(logDir + @"\EtmUnionPay_" + DateTime.Now.ToString("yyyyMM") + ".log");
                sw.WriteLine("[" + DateTime.Now.ToString() + "] " + content);
                sw.Flush();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }
    }
}
