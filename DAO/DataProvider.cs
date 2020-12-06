using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        public static SQLiteConnection OpenConnection()
        {
            //Lấy file path mà chương trình chạy(VD:C:\...\bai1\bin\debug
            string CurrentDirectory = System.Environment.CurrentDirectory;
            //Lấy file path đã bỏ đi bin\debug -> Đây là địa chỉ của toàn bộ project
            string CurrentProjectD = Directory.GetParent(CurrentDirectory).Parent.FullName;
            string QueryString = @"Data Source=" + CurrentProjectD + @"\Database\NHAHANG.db;";
            SQLiteConnection conn = new SQLiteConnection(QueryString);
            conn.Open();
            return conn;
        }

        public static void CloseConnection(SQLiteConnection conn)
        {
            conn.Close();
        }

        public static DataTable LayDataTable(string QueryString, SQLiteConnection conn)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(QueryString, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool ThucThiTruyVanNonQuery(string QueryString, SQLiteConnection conn)
        {
            try
            {
                SQLiteCommand cm = new SQLiteCommand(QueryString, conn);
                cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
