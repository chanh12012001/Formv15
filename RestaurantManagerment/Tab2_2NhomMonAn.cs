using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using DAO;

namespace RestaurantManagerment
{
    public partial class Tab2_2NhomMonAn : UserControl
    {
        public Tab2_2NhomMonAn()
        {
            InitializeComponent();
        }

        private void Tab2_2NhomMonAn_Load(object sender, EventArgs e)
        {
            LoadNhomMonAn();
        }


        List<NhomMonAn_DTO> danhSachNhomMonAn;
        private void LoadNhomMonAn()
        {

            danhSachNhomMonAn = NhomMonAn_BUS.LoadNhomMonAn();
            dtgrvDanhSachNhomMon.DataSource = danhSachNhomMonAn;

            if (danhSachNhomMonAn == null)
                return;
            dtgrvDanhSachNhomMon.Columns["MaNhomMonAn"].HeaderText = "Mã Nhóm";
            dtgrvDanhSachNhomMon.Columns["TenNhomMonAn"].HeaderText = "Tên Nhóm";

        }
    }
}
