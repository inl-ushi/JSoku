using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data;

namespace JSoku
{
    class DB
    {
        public const string NEW_SID = "-1";

        public static string GetSchemaName()
        {
            var schemaName = Properties.Settings.Default.DB_Schema_Dev;
            return schemaName;
        }
        public static Color GetSchemaColor()
        {
            var schemaColor = Color.Red;
            return schemaColor;
        }
        public static string GetConnString()
        {
            var connString = new MySqlConnectionStringBuilder
            {
                ConnectionTimeout = 20,
                UserID = Properties.Settings.Default.DB_UserID,
                Password = Properties.Settings.Default.DB_Password,
# if DEBUG
                Server = Properties.Settings.Default.DB_ServerName_Stage,
# else           
                Server = Properties.Settings.Default.DB_ServerName_Release,
# endif
                Database = DB.GetSchemaName(),
                Pooling = true,

                //0000-00-00を許さない
                AllowZeroDateTime = false,
                ConvertZeroDateTime = false
            };
            return connString.ToString();
        }
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = DB.GetConnString();
            conn.Open();

            var comm = new MySqlCommand();

            comm.Connection = conn;
            comm.CommandText = String.Format("USE `{0}`;", DB.GetSchemaName());
            comm.ExecuteNonQuery();
            return conn;
        }
        public static MySqlCommand GetCommand()
        {
            MySqlCommand com = new MySqlCommand();
            com.Connection = DB.GetConnection();
            com.CommandTimeout = 30;

            return com;
        }
        public static MySqlCommand GetCommand(MySqlConnection _conn)
        {
            MySqlCommand com = new MySqlCommand();
            com.Connection = _conn;
            com.CommandTimeout = 30;
            return com;
        }
        public static void Execute(string _query)
        {
            MySqlCommand com = new MySqlCommand();
            com.CommandText = _query;
            com.ExecuteNonQuery();

            com.Connection.Close();
            com.Connection.Dispose();
            com.Dispose();
        }
        public static MySqlDataReader GetReader(string _query)
        {
            var conn = DB.GetConnection();

            return DB.GetReader(conn, _query);
        }
        public static MySqlDataReader GetReader(MySqlConnection _conn, string _query)
        {
            var com = DB.GetCommand(_conn);
            com.CommandText = _query;
            var rs = com.ExecuteReader();
            return rs;
        }
        public static DataTable GetDataTable(MySqlConnection _conn, string _query)
        {
            var dt = new DataTable("Table1");
            MySqlCommand selComm = DB.GetCommand();
            selComm.CommandText = _query;
            var adp = new MySqlDataAdapter(selComm);

            adp.Fill(dt);

            adp.Dispose();
            selComm.Connection.Dispose();
            selComm.Dispose();

            return dt;
        }
        public static DataTable GetDataTable(string _query)
        {
            var conn = DB.GetConnection();
            return DB.GetDataTable(conn, _query);
        }
        public static string GetScalar(string _query)
        {
            var comm = DB.GetCommand();
            comm.CommandText = _query;

            string ret;
            ret = comm.ExecuteScalar().ToString();

            comm.Connection.Close();
            comm.Connection.Dispose();
            comm.Dispose();

            return ret;
        }
        public static MySqlParameter NewParam(string columnName, object newValue)
        {
            MySqlParameter ret = new MySqlParameter();

            ret.ParameterName = columnName;
            ret.Value = newValue;

            /*
            if (newValue == null)
            {
                //値なし
                ret.Value = DBNull.Value;
            }
            else {
                //値あり
                switch(newValue.GetType().ToString())
                {
                    case "int":
                        ret.MySqlDbType = MySqlDbType.Int32;
                        break;
                    case "String":
                        ret.MySqlDbType = MySqlDbType.VarChar;
                        break;
                    case "DateTime":
                        break;
                    case typeof(Byte):
                        break;
                    case typeof(Bitmap):
                        break;
                    case typeof(System.IO.MemoryStream):
                        break;
                }
            }

            */
            return ret;
        }
        public static Object NVL(Object src)
        {
            return NVL(src, "");
        }
        public static Object NVL(Object src,Object dest)
        {
            var ret = src;
            if (src==DBNull.Value)
            {
                ret = dest;
            }
            return ret;
        }

        public static string Escape(string src)
        {
            string buff;

            if (src == null)
            {
                buff = "";
            }
            else
            {
                buff = src;
            }
            return String.Format("'{0}'", buff.Replace("'", "''"));
        }
    }
}
