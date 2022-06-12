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

namespace QuanLyNhaHangSQK.GUI.QuanLy.ThongTinCongTy
{
    public partial class fThongTinCongTy : Form
    {
        private int MaCTY;

        public fThongTinCongTy()
        {
            InitializeComponent();
        }

        private void fThongTinCongTy_Load(object sender, EventArgs e)
        {
            TaiThongTinCongTy();
        }

        private void TaiThongTinCongTy()
        {
            CTY cTY = CTYDAL.Instance.TaiThongTinCTY();

            MaCTY = cTY.MaCTY;
            txtTenCTY.Text = cTY.TenCTY;
            txtTenVietTat.Text = cTY.TenVietTat;
            txtSoLuoc.Text = cTY.SoLuoc;
            txtTenNH.Text = cTY.TenNH;
            txtSTKNH.Text = cTY.SoTKNH;
            txtDienThoai.Text = cTY.DienThoaiCTY;
            txtEmail.Text = cTY.Email;
            txtWebsite.Text = cTY.Website;
            txtDiaChi.Text = cTY.DiaChi;

            byte[] Img = CTYDAL.Instance.TaiAnhLen(cTY.MaCTY);

            pctLogoCTY.BackgroundImage = XuLyAnh.Instance.ByteArrayToImage(Img);
        }

        private void pctLogoCTY_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pctLogoCTY.BackgroundImage = Image.FromFile(openFileDialog.FileName);
            }

            LuuThongTin();
        }


        private void LuuThongTin()
        {

            if (string.IsNullOrEmpty(txtTenCTY.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập tên công ty!");
                txtTenCTY.Focus();
            }
            else if (string.IsNullOrEmpty(txtTenVietTat.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập tên viết tắt!");
                txtTenVietTat.Focus();
            }
            else if (string.IsNullOrEmpty(txtSoLuoc.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập sơ lược công ty!");
                txtSoLuoc.Focus();
            }
            else if (string.IsNullOrEmpty(txtTenNH.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập tên ngân hàng!");
                txtTenNH.Focus();
            }
            else if (string.IsNullOrEmpty(txtSTKNH.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số tài khoản!");
                txtSTKNH.Focus();
            }
            else if (string.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại công ty!");
                txtDienThoai.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập email công ty!");
                txtEmail.Focus();
            }
            else if (string.IsNullOrEmpty(txtWebsite.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập website công ty!");
                txtWebsite.Focus();
            }
            else if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ công ty!");
                txtDiaChi.Focus();
            }
            else
            {
                string TenCTY = txtTenCTY.Text;
                string TenVietTat = txtTenVietTat.Text;
                string SoLuoc = txtSoLuoc.Text;
                string TenNH = txtTenNH.Text;
                string SoTKNH = txtSTKNH.Text;
                string DienThoai = txtDienThoai.Text;
                string Email = txtEmail.Text;
                string Website = txtWebsite.Text;
                string DiaChi = txtDiaChi.Text;

                byte[] Img = XuLyAnh.Instance.ImageToByteArray(pctLogoCTY.BackgroundImage);

                if (Img != null)
                {
                    CTYDAL.Instance.CapNhatCTY(MaCTY, TenCTY, TenVietTat, SoLuoc, TenNH, SoTKNH, DienThoai, Email, Website, DiaChi, Img);
                }

            }
        }

        private void txtTenCTY_Leave(object sender, EventArgs e)
        {
            LuuThongTin();
        }
    }
}
