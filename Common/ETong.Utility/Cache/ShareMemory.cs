using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ETong.Utility.Converts;

namespace ETong.Utility.Cache
{
    public class ShareMemory
    {
        static ShareMemory()
        {
            Inital("memShare", maxLenght);
        }

        static int maxLenght = 1024 * 1024 * 5;

        int id = 0;

        int offset
        {
            get
            {
                return id * 1024;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFileMapping(int hFile, IntPtr lpAttributes, uint flProtect, uint dwMaxSizeHi, uint dwMaxSizeLow, string lpName);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr OpenFileMapping(int dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, string lpName);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr MapViewOfFile(IntPtr hFileMapping, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool UnmapViewOfFile(IntPtr pvBaseAddress);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32", EntryPoint = "GetLastError")]
        public static extern int GetLastError();

        const int ERROR_ALREADY_EXISTS = 183;

        const int FILE_MAP_COPY = 0x0001;
        const int FILE_MAP_WRITE = 0x0002;
        const int FILE_MAP_READ = 0x0004;
        const int FILE_MAP_ALL_ACCESS = 0x0002 | 0x0004;

        const int PAGE_READONLY = 0x02;
        const int PAGE_READWRITE = 0x04;
        const int PAGE_WRITECOPY = 0x08;
        const int PAGE_EXECUTE = 0x10;
        const int PAGE_EXECUTE_READ = 0x20;
        const int PAGE_EXECUTE_READWRITE = 0x40;

        const int SEC_COMMIT = 0x8000000;
        const int SEC_IMAGE = 0x1000000;
        const int SEC_NOCACHE = 0x10000000;
        const int SEC_RESERVE = 0x4000000;

        const int INVALID_HANDLE_VALUE = -1;

        static bool initalSuccess = false;

        static IntPtr m_hSharedMemoryFile = IntPtr.Zero;
        static IntPtr point = IntPtr.Zero;

        static Semaphore semWrite;

        /// 
        /// Inital共享内存
        /// 
        /// 共享内存名称
        /// 共享内存大小
        /// 
        public static void Inital(string strName, long lngSize)
        {

            m_hSharedMemoryFile = CreateFileMapping(INVALID_HANDLE_VALUE, IntPtr.Zero, (uint)PAGE_READWRITE, 0, (uint)lngSize, strName);

            if (GetLastError() == ERROR_ALREADY_EXISTS) //已经创建
            {
                m_hSharedMemoryFile = OpenFileMapping(FILE_MAP_ALL_ACCESS, false, strName);
            }

            if (m_hSharedMemoryFile == IntPtr.Zero)
            {
                return;
            }


            //---------------------------------------
            //创建内存映射
            point = MapViewOfFile(m_hSharedMemoryFile, FILE_MAP_ALL_ACCESS, 0, 0, (uint)lngSize);

            if (point == IntPtr.Zero)
            {
                CloseHandle(m_hSharedMemoryFile);
                return;
            }
            //---------------------------------------


            SetSemaphore();

            initalSuccess = true;

            memData = new Hashtable();
        }

        /// 
        /// 关闭共享内存
        /// 
        public static void Close()
        {
            if (initalSuccess)
            {
                UnmapViewOfFile(point);
                CloseHandle(m_hSharedMemoryFile);
            }
        }

        public static bool SetSemaphore()
        {
            try
            {
                semWrite = Semaphore.OpenExisting("WriteShareMemory");
            }
            catch (Exception)
            {
                semWrite = new Semaphore(1, 1, "WriteShareMemory");
            }
            return true;
        }

        private static Int32 getData_Int32()
        {
            if (initalSuccess == false)
            {
                return -1;
            }

            Byte[] bytData = new Byte[sizeof(Int32)];

            Marshal.Copy(point, bytData, 0, bytData.Length);

            return BitConverter.ToInt32(bytData, 0);
        }

        private static void setData_bool(bool data)
        {
            if (initalSuccess == false)
            {
                return;
            }

            Byte[] bytData = BitConverter.GetBytes(data);

            Marshal.Copy(bytData, 0, point, bytData.Length);
        }

        private static bool getData_bool()
        {
            if (initalSuccess == false)
            {
                return false;
            }

            Byte[] bytData = new Byte[sizeof(bool)];

            Marshal.Copy(point, bytData, 0, bytData.Length);

            return BitConverter.ToBoolean(bytData, 0);
        }

        private static void setData_Int32(int data)
        {
            if (initalSuccess == false)
            {
                return;
            }

            Byte[] bytData = BitConverter.GetBytes(data);

            Marshal.Copy(bytData, 0, point, bytData.Length);
        }

        private static double getData_double()
        {
            if (initalSuccess == false)
            {
                return -1;
            }

            Byte[] bytData = new Byte[sizeof(double)];

            Marshal.Copy(point, bytData, 0, bytData.Length);

            return BitConverter.ToDouble(bytData, 0);
        }

        private static void setData_double(double data)
        {
            if (initalSuccess == false)
            {
                return;
            }

            Byte[] bytData = BitConverter.GetBytes(data);

            semWrite.WaitOne(1000);
            Marshal.Copy(bytData, 0, point, bytData.Length);
            semWrite.Release();
        }

        public static Hashtable memData
        {
            get
            {
                if (initalSuccess == false)
                {
                    return null;
                }
                byte[] bytData = new byte[maxLenght];
                Marshal.Copy(point, bytData, 0, bytData.Length);
                return Converter.Deserialize<Hashtable>(bytData);
            }
            private set
            {
                if (initalSuccess == false)
                {
                    return;
                }

                byte[] bytData = Converter.SerializeToByteArray(value);
                Marshal.Copy(bytData, 0, point, bytData.Length);
            }
        }

        public static void setValue(string key, object value)
        {
            Hashtable data = memData;
            if (data != null)
            {
                if (data.ContainsKey(key))
                    data[key] = value;
                else
                    data.Add(key, value);
                memData = data;
            }
        }

        public static object getValue(string key)
        {
            if (memData != null)
                return memData[key];
            return null;
        }
    }
}
