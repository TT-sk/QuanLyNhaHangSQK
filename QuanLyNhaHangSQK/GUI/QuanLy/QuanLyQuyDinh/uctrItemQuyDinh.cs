using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyQuyDinh
{
    public partial class uctrItemQuyDinh : UserControl
    {
        private string tieuDe;
        private string noiDung;
        public event EventHandler ButtonClick_Xoa;

        public string TieuDe
        {
            get => tieuDe;
            set { tieuDe = value; txtTieuDe.Text = value; }
        }

        public string NoiDung
        {
            get => noiDung;
            set { noiDung = value; txtNoiDung.Text = value; }
        }

        public uctrItemQuyDinh()
        {
            InitializeComponent();
        }



        private void lbNoiDung_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick_Xoa != null)
                this.ButtonClick_Xoa(this, e);
        }
    }
}
