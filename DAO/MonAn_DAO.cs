using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Drawing;

namespace DAO
{
    public class MonAn_DAO
    {
        static SQLiteConnection conn;
        public static List<MonAn_DTO> LoadMonAn()
        {
            string chuoiTruyVan = "Select ID, TenMonAn, DonViTinh, Gia, TenNhom From MonAn, NhomMon where MaNhomMon = MaNhom";
            conn = DataProvider.OpenConnection();
            DataTable dt = DataProvider.LayDataTable(chuoiTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;

            List<MonAn_DTO> lstMonAn = new List<MonAn_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MonAn_DTO monAn = new MonAn_DTO();
                monAn.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                monAn.TenMonAn = dt.Rows[i]["TenMonAn"].ToString();
                monAn.DonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                monAn.Gia = int.Parse(dt.Rows[i]["Gia"].ToString());
                monAn.TenNhomMon = dt.Rows[i]["TenNhom"].ToString();
                lstMonAn.Add(monAn);
            }
            DataProvider.CloseConnection(conn);
            return lstMonAn;
        }
        // ------------------------ thêm món ăn -----------------------
        public static bool ThemMonAn(MonAn_DTO monAn)
        {
            string maNHOM = NhomMonAn_DAO.layIDNhomMonAn(monAn.TenNhomMon);
            string QueryString = string.Format("insert into MonAn(MaNhomMon,TenMonAn,DonViTinh,Gia) values('{0}','{1}','{2}','{3}')", maNHOM, monAn.TenMonAn, monAn.DonViTinh, monAn.Gia);
            conn = DataProvider.OpenConnection();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(QueryString, conn);
                DataProvider.CloseConnection(conn);
                return true;
            }
            catch (Exception)
            {
                DataProvider.CloseConnection(conn);
                return false;
            }

        }
      
    }
}
