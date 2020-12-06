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
    public class HoaDonOrder_DAO
    {
        static SQLiteConnection conn;
        // load hoa don
        public static List<HoaDonOrder_DTO> LoadHoaDon(int idBan)
        {
            string chuoiTruyVan = "select HoaDonInFo.ID,MonAn.TenMonAn,HoaDonInFo.SoLuong,MonAn.Gia, (HoaDonInFo.SoLuong * MonAn.Gia) as ThanhTien from BanAn, HoaDon, MonAn, HoaDonInFo where HoaDonInFo.IDMonAn = MonAn.ID AND HoaDonInFo.IDHoaDon = HoaDon.ID and HoaDon.IDBan = BanAn.ID AND BanAn.ID = " + idBan;
            conn = DataProvider.OpenConnection();
            DataTable dtHoaDon = DataProvider.LayDataTable(chuoiTruyVan, conn);
            if (dtHoaDon.Rows.Count == 0)
                return null;

            List<HoaDonOrder_DTO> lstHoaDon = new List<HoaDonOrder_DTO>();

            for (int i = 0; i < dtHoaDon.Rows.Count; i++)
            {
                HoaDonOrder_DTO hoaDon = new HoaDonOrder_DTO();
                hoaDon.ID = int.Parse(dtHoaDon.Rows[i]["ID"].ToString());
                hoaDon.TenMonAn = dtHoaDon.Rows[i]["TenMonAn"].ToString();
                hoaDon.SoLuong = int.Parse(dtHoaDon.Rows[i]["SoLuong"].ToString());
                hoaDon.Gia = int.Parse(dtHoaDon.Rows[i]["Gia"].ToString());
                hoaDon.ThanhTien = int.Parse(dtHoaDon.Rows[i]["ThanhTien"].ToString());

                lstHoaDon.Add(hoaDon);
            }
            DataProvider.CloseConnection(conn);
            return lstHoaDon;
        }
    }
}
