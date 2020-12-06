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
using DAO;
using BUS;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace RestaurantManagerment
{
    public partial class tab2_1ThongTinMonAn : UserControl
    {
        public tab2_1ThongTinMonAn()
        {
            InitializeComponent();
            LoadNhomMonAn();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {

            //UpLoad Image Từ Máy Tính
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private List<NhomMonAn_DTO> listNhomMonAn;
        private void LoadNhomMonAn()
        {
            listNhomMonAn = NhomMonAn_DAO.LayNhomMonAn();
            for (int i = 0; i < listNhomMonAn.Count; i++)
            {
                string str = listNhomMonAn[i].TenNhomMonAn;
                cbNhomMon.Items.Add(str);
                cbFillNhomMon.Items.Add(str);
            }
        }

        private void tab2_1ThongTinMonAn_Load(object sender, EventArgs e)
        {
            LoadMonAn();
        }

        private void LoadImage()
        {
            
        }

        List<MonAn_DTO> lstMonAn;
        private void LoadMonAn()
        {
            lstMonAn = MonAn_BUS.LoadMonAn();
            dtgrvDanhSachMonAn.DataSource = lstMonAn;

            if (lstMonAn == null)
                return;


          /*  dtgrvDanhSachMonAn.Columns["ID"].HeaderText = "ID";
            dtgrvDanhSachMonAn.Columns["TenNhom"].HeaderText = "Tên Nhóm";
            dtgrvDanhSachMonAn.Columns["TenMonAn"].HeaderText = "Tên Món";
            dtgrvDanhSachMonAn.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
            dtgrvDanhSachMonAn.Columns["Gia"].HeaderText = "Giá";

            dtgrvDanhSachMonAn.Columns["ID"].Width = 50;
            dtgrvDanhSachMonAn.Columns["MaNhomMon"].Width = 100;
            dtgrvDanhSachMonAn.Columns["TenMonAn"].Width = 221;
            dtgrvDanhSachMonAn.Columns["DonViTinh"].Width = 100;
            dtgrvDanhSachMonAn.Columns["Gia"].Width = 124;*/
        }

        //----------------- chuẩn hóa chuỗi ---------------------------------
        public static string ChuanHoaChuoi(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            if (cbNhomMon.Text == "")
            {
                MessageBox.Show("Chon nhom mon an");
                return;
            }
            if (txtTenMonAn.Text == "")
            {
                MessageBox.Show("Nhập tên món ăn");
                return;
            }
            if (txtDonViTinh.Text == "")
            {
                MessageBox.Show("Nhập đơn vị tính");
                return;
            }
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Nhập đơn giá");
                return;
            }

            MonAn_DTO monAn = new MonAn_DTO();
            monAn.TenNhomMon = cbNhomMon.Text;
            monAn.TenMonAn = txtTenMonAn.Text.ToString();
            monAn.DonViTinh = txtDonViTinh.Text.ToString();
            monAn.IMAGE = pictureBox1.Image;
            try
            {
                monAn.Gia = int.Parse(txtDonGia.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập có lỗi. Xin kiểm tra lại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lstMonAn != null)
            {
                for (int i = 0; i < lstMonAn.Count; i++)
                {
                    if (ChuanHoaChuoi(monAn.TenMonAn.ToLower()) == ChuanHoaChuoi(lstMonAn[i].TenMonAn.ToLower()))
                    {
                        MessageBox.Show("Món ăn đã có trong thực đơn rồi");
                        return;
                    }
                }
            }
            if (MonAn_BUS.ThemMonAn(monAn))
            {
                MessageBox.Show("Đã Thêm");
                LoadMonAn();
                return;
            }
            MessageBox.Show("Thêm thất bại !");
        }
    }
}
