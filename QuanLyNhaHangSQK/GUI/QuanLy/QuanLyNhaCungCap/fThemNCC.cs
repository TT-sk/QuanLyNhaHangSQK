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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhieuNhap
{
    public partial class fThemNCC : Form
    {
        public fThemNCC()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaNCC.Text.Trim()))
                {
                    MessageBox.Show("Vul lòng nhập mã nhà cung cấp!");
                    txtMaNCC.Focus();
                }
                else if (string.IsNullOrEmpty(txtTenNCC.Text.Trim()))
                {
                    MessageBox.Show("Vul lòng nhập tên nhà cung cấp!");
                    txtTenNCC.Focus();
                }
                else if (string.IsNullOrEmpty(txtDienThoaiNCC.Text.Trim()))
                {
                    MessageBox.Show("Vul lòng nhập điện thoại nhà cung cấp!");
                    txtDienThoaiNCC.Focus();
                }
                else if (string.IsNullOrEmpty(txtDiaChiNCC.Text.Trim()))
                {
                    MessageBox.Show("Vul lòng nhập địa chỉ nhà cung cấp!");
                    txtDiaChiNCC.Focus();
                }
                else
                {
                    string TenNCC = txtTenNCC.Text;
                    string MaNCC = txtMaNCC.Text;
                    string DienThoai = txtDienThoaiNCC.Text;
                    string DiaChi = txtDiaChiNCC.Text;

                    if (NhaCungCapDAL.Instance.ThemNCC(MaNCC, TenNCC, DienThoai, DiaChi))
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
    }
}
