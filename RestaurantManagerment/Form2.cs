using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagerment
{
    public partial class Form2 : Form
    {
        Control c;
        public Form2()
        {
            InitializeComponent();
            c = tab1QLBanAn1;
        }
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn Có Muốn Thoát Hay Không ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            c.Visible=false;
            tab3QuanLiNhanSu1.Visible = true;
            c = tab3QuanLiNhanSu1;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            c.Visible = false;
            tab1QLBanAn1.Visible = true;
            c = tab1QLBanAn1;
        }

        private void QLTD_Click(object sender, EventArgs e)
        {
            c.Visible = false;
            tab2QLThucDon1.Visible = true;
            c = tab2QLThucDon1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Location = new System.Drawing.Point(gunaShadowPanel1.Width, gunaGradient2Panel2.Height);
            panel1.Size = new System.Drawing.Size(this.Width - gunaShadowPanel1.Width, this.Height - gunaGradient2Panel2.Height);
            tab1QLBanAn1.Location = new Point(0, 0);
            tab1QLBanAn1.Size = new System.Drawing.Size(this.Width - gunaShadowPanel1.Width, this.Height - gunaGradient2Panel2.Height);
            tab2QLThucDon1.Location = new Point(0, 0);
            tab2QLThucDon1.Size = panel1.Size;
            tab3QuanLiNhanSu1.Location = new Point(0, 0);
            tab3QuanLiNhanSu1.Size = panel1.Size;
            Tab4QuanLiHoaDon1.Location= new Point(0, 0);
            Tab4QuanLiHoaDon1.Size = panel1.Size;
            LoadInPanel();
        }
        private void LoadInPanel ()
        {
            panel1.Controls.Add(tab1QLBanAn1);
            tab1QLBanAn1.Visible = true;
            panel1.Controls.Add(tab2QLThucDon1);
            tab2QLThucDon1.Visible = false;
            panel1.Controls.Add(tab3QuanLiNhanSu1);
            tab3QuanLiNhanSu1.Visible = false;
            panel1.Controls.Add(Tab4QuanLiHoaDon1);
            Tab4QuanLiHoaDon1.Visible = false;
        }

        private void QLHD_Click(object sender, EventArgs e)
        {
            c.Visible = false;
            Tab4QuanLiHoaDon1.Visible = true;
            c = Tab4QuanLiHoaDon1;
        }
    }
}
