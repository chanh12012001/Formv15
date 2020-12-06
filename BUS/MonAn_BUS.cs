using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Drawing;
namespace BUS
{
    public class MonAn_BUS
    {
        public static List<MonAn_DTO> LoadMonAn()
        {
            return MonAn_DAO.LoadMonAn();
        }
        public static bool ThemMonAn(MonAn_DTO monAn)
        {
            return MonAn_DAO.ThemMonAn(monAn);
        }
   
    }
}
