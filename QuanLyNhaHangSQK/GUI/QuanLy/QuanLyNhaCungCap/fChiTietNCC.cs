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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhaCungCap
{
    public partial class fChiTietNCC : Form
    {
        private string maNCC;

        public string MaNCC { get => maNCC; set => maNCC = value; }

        public fChiTietNCC(string maNhaCungCap)
        {
            InitializeComponent();

            this.MaNCC = maNhaCungCap;
        }

        private void fChiTietNCC_Load(object sender, EventArgs e)
        {
            TaiThongTinNCC();
        }

        private void TaiThongTinNCC()
        {
            NhaCungCap nhaCungCap = NhaCungCapDAL.Instance.TaiNhaCungCapTheoMa(MaNCC);

            txtMaNCC.Text = nhaCungCap.MaNCC;
            txtTenNCC.Text = nhaCungCap.TenNCC;
            txtDienThoaiNCC.Text = nhaCungCap.DienThoaiNCC;
            txtDiaChiNCC.Text = nhaCungCap.DiaChiNCC;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenNCC.Text.Trim()))
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

                    if (NhaCungCapDAL.Instance.SuaNCC(MaNCC, TenNCC, DienThoai, DiaChi))
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!");
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
