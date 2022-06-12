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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyChiNhanh
{
    public partial class fThemChiNhanh : Form
    {
        public fThemChiNhanh()
        {
            InitializeComponent();
        }

        private void fThemChiNhanh_Load(object sender, EventArgs e)
        {
            TaiDanhSachCTY();
        }

        private void TaiDanhSachCTY()
        {
            List<CTY> danhSachCTY = CTYDAL.Instance.TaiDanhSachCTY();

            cbbCTY.DataSource = danhSachCTY;
            cbbCTY.DisplayMember = "TenCTY";
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenCN.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập tên chi nhánh!");
                txtTenCN.Focus();
            }
            else if (string.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại chi nhánh!");
                txtDienThoai.Focus();
            }
            else if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ chi nhánh!");
                txtDiaChi.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập email!");
                txtEmail.Focus();
            }
            else if (string.IsNullOrEmpty(cbbTenNH.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa chọn ngân hàng!");
                cbbTenNH.Focus();
            }
            else if (string.IsNullOrEmpty(txtSoTKNH.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số tài khoản ngân hàng!");
                txtSoTKNH.Focus();
            }
            else
            {
                try
                {
                    string TenCN = txtTenCN.Text;
                    string DiaChi = txtDiaChi.Text;
                    string DienThoai = txtDienThoai.Text;
                    string Email = txtEmail.Text;
                    string TenNH = cbbTenNH.Text;
                    string SoTKNH = txtSoTKNH.Text;
                    int MaCTY = (cbbCTY.SelectedItem as CTY).MaCTY;

                    if (ChiNhanhDAL.Instance.ThemChiNhanh(TenCN, DiaChi, DienThoai, Email, TenNH, SoTKNH, MaCTY))
                    {
                        MessageBox.Show("Đăng ký thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thất bại!");
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi!");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
