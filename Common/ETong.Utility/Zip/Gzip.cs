using System;
using System.IO;
using System.IO.Compression;

using ICSharpCode.SharpZipLib.Zip;
namespace ETong.Utility.Zip
{
    /// <summary>
    /// 为应用程序提供数据压缩与解压缩服务
    /// </summary>
    public class Gzip
    {
        /// <summary>
        /// 压缩指定的字节数组
        /// </summary>
        /// <param name="srcBuffer">要压缩的字节数组</param>
        /// <returns>byte[]</returns>
        public static byte[] Compress(byte[] srcBuffer)
        {
            MemoryStream ms = new MemoryStream();
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(srcBuffer, 0, srcBuffer.Length);
            }
            ms.Position = 0;
            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);
            byte[] gzBuffer = new byte[compressed.Length + 4];
            System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            System.Buffer.BlockCopy(BitConverter.GetBytes(srcBuffer.Length), 0, gzBuffer, 0, 4);
            return gzBuffer;
        }

        /// <summary>
        /// 压缩指定的字节数组
        /// </summary>
        /// <param name="srcBuffer">要压缩的字节数组</param>
        /// <returns>byte[]</returns>
        /// <returns>偏移量</returns>
        public static byte[] Compress(byte[] srcBuffer, int offset)
        {
            MemoryStream ms = new MemoryStream();
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(srcBuffer, 0, srcBuffer.Length);
            }
            ms.Position = 0;
            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);
            byte[] gzBuffer = new byte[compressed.Length + offset];
            System.Buffer.BlockCopy(compressed, 0, gzBuffer, offset, compressed.Length);
            System.Buffer.BlockCopy(BitConverter.GetBytes(srcBuffer.Length), 0, gzBuffer, 0, offset);
            return gzBuffer;
        }

        /// <summary>
        /// 压缩指定的文件
        /// </summary>
        /// <param name="srcFileName">要压缩的文件路径和文件名称</param>
        /// <returns>byte[]</returns>
        public static byte[] Compress(string srcFileName)
        {
            byte[] srcBuffer = File.ReadAllBytes(srcFileName);
            return Compress(srcBuffer);
        }

        /// <summary>
        /// 压缩指定的文件并存储到指定的位置
        /// </summary>
        /// <param name="srcFileName">要压缩的文件路径和文件名称</param>
        /// <param name="saveFileName">压缩后保存的路径和文件名称</param>
        public static void Compress(string srcFileName, string saveFileName)
        {
            byte[] srcBuffer = File.ReadAllBytes(srcFileName);
            File.ReadAllBytes(saveFileName);
        }

        /// <summary>
        /// 压缩文件夹及其子文件夹
        /// </summary>
        /// <param name="directoryPath">待压缩文件夹</param>
        /// <param name="zipFilePath">压缩文件路径</param>
        public static void CompressFolder(string directoryPath, string zipFilePath)
        {
            //快速压缩目录，包括目录下的所有文件
            (new FastZip()).CreateZip(zipFilePath, directoryPath, true, "");
        }
        /// <summary>
        /// 解压缩指定的字节数组
        /// </summary>
        /// <param name="gzBuffer">要解压缩的字节数组</param>
        /// <returns>byte[]</returns>
        public static byte[] Decompress(byte[] gzBuffer)
        {
            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);
                buffer = new byte[msgLength];
                ms.Position = 0;
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress, true))
                {
                    zip.Read(buffer, 0, buffer.Length);
                }
            }
            return buffer;
        }

        /// <summary>
        /// zip解压缩
        /// </summary>
        /// <param name="zipFilePath">zip文件路径</param>
        public static void UnZipFile(string zipFilePath)
        {
            if (!File.Exists(zipFilePath))
            {
                //Console.WriteLine("Cannot find file '{0}'", zipFilePath);
                return;
            }

            //创建当前总目录
            string currentDirPath = zipFilePath.Substring(0, zipFilePath.LastIndexOf("."));
            if (!Directory.Exists(currentDirPath))
                Directory.CreateDirectory(currentDirPath);

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
            {

                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {

                    //Console.WriteLine(theEntry.Name);

                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);

                    // create directory
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(currentDirPath + "\\" + directoryName);
                    }

                    if (fileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(currentDirPath + "\\" + theEntry.Name))
                        {

                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 解压缩指定的字节数组并存储到指定的文件
        /// </summary>
        /// <param name="saveFileName">压缩后保存的路径和文件名称</param>
        /// <param name="gzBuffer">要解压缩的字节数组</param>
        public static void Decompress(string saveFileName, byte[] gzBuffer)
        {
            byte[] buffer = Decompress(gzBuffer);
            File.WriteAllBytes(saveFileName, buffer);
        }

        /// <summary>
        /// 解压缩指定的文件
        /// </summary>
        /// <param name="srcFileName">要解压缩的文件路径和文件名称</param>
        /// <param name="saveFileName">压缩后保存的路径和文件名称</param>
        public static void Decompress(string srcFileName, string saveFileName)
        {
            byte[] buffer = File.ReadAllBytes(srcFileName);
            Decompress(saveFileName, buffer);
        }

        /// zip压缩
        /// </summary>
        /// <param name="filesPath"></param>
        /// <param name="zipFilePath"></param>
        private static void CreateZipFile(string filesPath, string zipFilePath)
        {
            if (!Directory.Exists(filesPath))
            {
                //Console.WriteLine("Cannot find directory '{0}'", filesPath);
                return;
            }
            try
            {
                string[] filenames = Directory.GetFiles(filesPath);
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath)))
                {

                    s.SetLevel(9); // 压缩级别 0-9
                    //s.Password = "123"; //Zip压缩文件密码
                    byte[] buffer = new byte[4096]; //缓冲区大小
                    foreach (string file in filenames)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during processing {0}", ex);
            }
        }        
    }
}

