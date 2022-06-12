using QuanLyNhaHangSQK.DAL;
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
    public partial class fThemBoPhan : Form
    {
        public fThemBoPhan()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
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
                    if (BoPhanDAL.Instance.ThemBoPhan(MaBP, TenBP))
                    {
                        MessageBox.Show("Thêm thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Mã đã tồn tại!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
