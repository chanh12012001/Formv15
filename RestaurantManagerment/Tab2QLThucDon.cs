using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagerment
{
    public partial class Tab2QLThucDon : UserControl
    {
        public Tab2QLThucDon()
        {
            InitializeComponent();
            tab2_1ThongTinMonAn1.BringToFront();
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            tab2_1ThongTinMonAn1.BringToFront();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            tab2_2NhomMonAn1.BringToFront();
        }
    }
}
