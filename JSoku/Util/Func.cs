using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace JSoku
{
    class Func
    {
        public static string FilterEscape(string src)
        {

            var buff = src;
            buff = buff.Replace("*", "[*]");
            buff = buff.Replace("%", "[%]");
            buff = buff.Replace("'", "''");
            buff = "'*" + buff + "*'";

            return buff;

        }
        public static string GetWorkFolder()
        {
            var appPath = Environment.CurrentDirectory;

            return appPath;
        }
        public static string GetTempFolder()
        {

            var tempPath = GetWorkFolder() + "/temp/";

            if(File.Exists(tempPath)) {
            }
            else{
                // フォルダが無ければ作成しておく
                Directory.CreateDirectory(tempPath);
            }

            return tempPath;

        }
        public static string GetBumonCD()
        {
            // ホスト名を取得する
            string hostname = Dns.GetHostName();
            string BCD = null;
            string[] IPCDS;

            // ホスト名からIPアドレスを取得する
            IPAddress[] adrList = Dns.GetHostAddresses(hostname);
            foreach (IPAddress address in adrList)
            {
                //Console.WriteLine(address.ToString());
                BCD = address.ToString();
            }
            IPCDS = BCD.Split('.');

            return IPCDS[2];

        }
        public static void SetReadonly(String fileName, Boolean flag)
        {
            FileInfo fi = new FileInfo(fileName);
            fi.IsReadOnly = flag;
        }

    }
}
