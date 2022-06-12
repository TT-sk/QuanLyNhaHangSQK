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
    public partial class fChiTietChiNhanh : Form
    {
        private ChiNhanh chiNhanh;

        public ChiNhanh ChiNhanh { get => chiNhanh; set => chiNhanh = value; }

        public fChiTietChiNhanh(ChiNhanh chiNhanh)
        {
            InitializeComponent();

            this.ChiNhanh = chiNhanh;
        }

        private void fChiTietChiNhanh_Load(object sender, EventArgs e)
        {
            TaiDanhSachCTY();
            TaiThongTinChiNhanh();
        }

        private void TaiDanhSachCTY()
        {
            List<CTY> danhSachCTY = CTYDAL.Instance.TaiDanhSachCTY();

            cbbCTY.DataSource = danhSachCTY;
            cbbCTY.DisplayMember = "TenCTY";
        }

        private void TaiThongTinChiNhanh()
        {
            txtTenCN.Text = ChiNhanh.TenCN;
            txtDienThoai.Text = ChiNhanh.DienThoaiCN;
            txtDiaChi.Text = ChiNhanh.DiaChiCN;
            txtEmail.Text = ChiNhanh.Email;
            txtSoTKNH.Text = ChiNhanh.SoTKNH;
            cbbTenNH.Text = ChiNhanh.TenNH;

            int index = -1;
            int i = 0;
            foreach (CTY item in cbbCTY.Items)
            {
                if (item.MaCTY == ChiNhanh.MaCTY)
                {
                    index = i;
                    break;
                }
                i++;
            }
            cbbCTY.SelectedIndex = index;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
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
                    int MaCN = ChiNhanh.MaCN;

                    if (ChiNhanhDAL.Instance.SuaChiNhanh(TenCN, DiaChi, DienThoai, Email, TenNH, SoTKNH, MaCTY, MaCN))
                    {
                        MessageBox.Show("Sửa thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!");
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi!");
                }
            }
        }
    }
}
