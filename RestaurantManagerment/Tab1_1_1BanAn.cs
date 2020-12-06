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
using System.Threading;

namespace RestaurantManagerment
{
    public partial class Tab1_1_1BanAn : UserControl
    {
        public Tab1_1_1BanAn()
        {
            InitializeComponent();
            this.Controls.Add(this.flpSoDoBan);
        }

        List<BanAn_DTO> tableList;
        int tableID;
        private void LoadBanAn()
        {
            tableList = BanAn_DAO.LayBanAn();
            for (int i = 0; i < tableList.Count; i++)
            {
                Button btn = new Button() { Width = BanAn_DAO.tableWidth, Height = BanAn_DAO.tableHeight };
                btn.Image = Properties.Resources.icons8_tableware_48px;
                btn.ImageAlign = ContentAlignment.BottomCenter;
                btn.Text = Environment.NewLine + tableList[i].TenBan;
                btn.Font = new Font("Arial", 11, FontStyle.Bold);
                btn.TextAlign = ContentAlignment.TopCenter;

                btn.Click += btn_Click;
                tableID = BanAn_BUS.layIDBanAn(tableList[i].TenBan);
                btn.Tag = tableList[i];

                switch (tableList[i].TrangThai)
                {
                    case "Trống":
                        btn.BackColor = Color.Linen;
                        break;
                    default:
                        btn.BackColor = Color.Aqua;
                        break;
                }
                flpSoDoBan.Controls.Add(btn);
            }
        }

        public void ShowBill(int iDBan)
        {
          
        }
        private void btn_Click(object sender, EventArgs e)
        {
            int tableI = ((sender as Button).Tag as BanAn_DTO).ID;
            ShowBill(tableID);
            LoadHoaDon(tableI);
        }

        private void Tab1_1_1BanAn_Load(object sender, EventArgs e)
        {
            LoadBanAn();
            LoadThoiGian();
        }

        //------------- lấy ngày tháng năm hiện tại ---------------------------
        void LoadThoiGian()
        {
            DateTime nowTime = DateTime.Now;
            lbNgay.Text = nowTime.ToString("dd/MM/yyyy");
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            flpSoDoBan.Controls.Clear();
            LoadBanAn();
        }

        // ----------------------- Load Hóa Đơn -----------------------------
        List<HoaDonOrder_DTO> danhSachHoaDon;
        private void LoadHoaDon(int idBan)
        {
            int tongTien = 0;
            dgvHoaDonOrder.Rows.Clear();  // xóa hết các dòng trên listview đi để tránh cái sau đè lên cái trước
            danhSachHoaDon = HoaDonOrder_BUS.LoadHoaDon(idBan);  // lấy hóa đơn của bàn đang được click
            if (danhSachHoaDon == null)                    // nếu không có hóa đơn tiền = 0
            {
                LabelTongTienSo.Text = "0";
                return;
            }
              
            else    // nếu có hóa đơn
            {
                for (int i = 0; i < danhSachHoaDon.Count; i++)  // duyệt từ đầu danh sách hóa đơn đến cuối danh sách hóa đơn
                {

                    tongTien += int.Parse(danhSachHoaDon[i].ThanhTien.ToString());  // tính tổng tiền
                    dgvHoaDonOrder.Rows.Add(danhSachHoaDon[i].TenMonAn.ToString(), danhSachHoaDon[i].SoLuong.ToString(), danhSachHoaDon[i].Gia.ToString(), danhSachHoaDon[i].ThanhTien.ToString()); // thêm items vừa tạo vào listview
                }
                //CultureInfo cul = new CultureInfo("vi-VN");

                // Gán Tiền vào textbox
                LabelTongTienSo.Text = tongTien.ToString();
            }

        }

    }
}
