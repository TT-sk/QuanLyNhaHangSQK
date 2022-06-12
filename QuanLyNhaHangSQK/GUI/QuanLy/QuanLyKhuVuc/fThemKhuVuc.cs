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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhongBan
{
    public partial class fThemKhuVuc : Form
    {
        public fThemKhuVuc()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaKV.Text.Trim()))
                {
                    MessageBox.Show("Vul lòng nhập mã khu vực!");
                    txtMaKV.Focus();
                }
                else if (string.IsNullOrEmpty(txtTenKV.Text.Trim()))
                {
                    MessageBox.Show("Vul lòng nhập tên khu vực!");
                    txtTenKV.Focus();
                }
                else
                {
                    string TenKV = txtTenKV.Text;
                    string MaKV = txtMaKV.Text;
                    if (KhuVucDAL.Instance.ThemKhuVuc(MaKV, TenKV))
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
