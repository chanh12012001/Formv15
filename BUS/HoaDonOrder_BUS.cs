using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class HoaDonOrder_BUS
    {
        public static List<HoaDonOrder_DTO> LoadHoaDon(int idBan)
        {
            return HoaDonOrder_DAO.LoadHoaDon(idBan);
        }
    }
}
