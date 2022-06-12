using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.ThuNgan
{
    public partial class fKhoaManHinh : Form
    {
        private string MatKhau;

        public fKhoaManHinh(string hoTen, string matKhau)
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
            lbTenND.Text = hoTen;
            MatKhau = matKhau;
        }


        private void KiemTraMatKhau()
        {
            if (txtMatKhau.Text == MatKhau)
            {
                this.Close();
            }
            else
            {
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            KiemTraMatKhau();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }
    }
}
