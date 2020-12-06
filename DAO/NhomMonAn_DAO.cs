using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhomMonAn_DAO
    {
        static SQLiteConnection conn;
        public static List<NhomMonAn_DTO> LayNhomMonAn()
        {
            string QueryString = "Select * From NhomMon";
            conn = DataProvider.OpenConnection();
            DataTable dt = DataProvider.LayDataTable(QueryString, conn);
            if (dt.Rows.Count == 0)
                return null;

            List<NhomMonAn_DTO> danhSachNhomMonAn = new List<NhomMonAn_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhomMonAn_DTO nhomMonAn = new NhomMonAn_DTO();

                nhomMonAn.MaNhomMonAn = dt.Rows[i]["MaNhom"].ToString();
                nhomMonAn.TenNhomMonAn = dt.Rows[i]["TenNhom"].ToString();

                danhSachNhomMonAn.Add(nhomMonAn);
            }
            DataProvider.CloseConnection(conn);
            return danhSachNhomMonAn;
        }

        // ------------  lấy id của nhóm món ăn dựa vào tên --------------------------
        public static string layIDNhomMonAn(string tenNhomMonAn)
        {
            string QueryString = string.Format("Select MaNhom from NhomMon where TenNhom = '{0}'", tenNhomMonAn);
            conn = DataProvider.OpenConnection();
            DataTable dtIDNhomMonAn = DataProvider.LayDataTable(QueryString, conn);
            if (dtIDNhomMonAn.Rows.Count == 0)
                return "";
            string idNhomMonAn = dtIDNhomMonAn.Rows[0]["MaNhom"].ToString();
            DataProvider.CloseConnection(conn);
            return idNhomMonAn;
        }
    }
}
