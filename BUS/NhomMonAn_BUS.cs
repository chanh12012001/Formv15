using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class NhomMonAn_BUS
    {
        public static List<NhomMonAn_DTO> LoadNhomMonAn()
        {
            return NhomMonAn_DAO.LayNhomMonAn();
        }
    }
}
