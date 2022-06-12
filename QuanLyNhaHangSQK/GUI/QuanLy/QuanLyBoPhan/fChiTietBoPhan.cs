using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyBoPhan
{
    public partial class fChiTietBoPhan : Form
    {
        private BoPhan boPhan;

        public BoPhan BoPhan { get => boPhan; set => boPhan = value; }

        public fChiTietBoPhan(BoPhan boPhan)
        {
            InitializeComponent();

            this.BoPhan = boPhan;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fChiTietBoPhan_Load(object sender, EventArgs e)
        {
            TaiThongTinBoPhan();
        }

        private void TaiThongTinBoPhan()
        {
            txtMaBP.Text = BoPhan.MaBP;
            txtTenBP.Text = BoPhan.TenBP;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBP.Text.Trim()))
            {
                MessageBox.Show("Vul lòng nhập mã bộ phận!");
                txtMaBP.Focus();
            }
            else if (string.IsNullOrEmpty(txtTenBP.Text.Trim()))
            {
                MessageBox.Show("Vul lòng nhập tên bộ phận!");
                txtTenBP.Focus();
            }
            else
            {
                string TenBP = txtTenBP.Text;
                string MaBP = txtMaBP.Text;
                if (BoPhanDAL.Instance.SuaBoPhan(MaBP, TenBP))
                {
                    MessageBox.Show("Sửa thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                }
            }
        }
    }
}
