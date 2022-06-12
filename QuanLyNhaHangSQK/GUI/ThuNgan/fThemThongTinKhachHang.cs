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

namespace QuanLyNhaHangSQK.GUI
{
    public partial class fThemThongTinKhachHang : Form
    {
        private Ban ban;
        private NguoiDung nguoiDungDangNhap;
        private int maHD;
        public Ban Ban { get => ban; set => ban = value; }
        public NguoiDung NguoiDungDangNhap { get => nguoiDungDangNhap; set => nguoiDungDangNhap = value; }
        public int MaHD { get => maHD; set => maHD = value; }

        public fThemThongTinKhachHang(Ban maBan, NguoiDung nguoiDung, int maHoaDon)
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
            this.Ban = maBan;
            this.NguoiDungDangNhap = nguoiDung;
            this.MaHD = maHoaDon;
        }

        private void btnLuuThongTinKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                int DienThoai = int.Parse(txtDienThoaiKH.Text.Trim());

                if (rdbtnKhachHangMoi.Checked)
                {
                    //Tạo KH mới
                    //Lưu mã KH vào hóa đơn
                    int MaKH = KhachHangDAL.Instance.ThemVaLayKhachHangMoi(txtTenKH.Text, DienThoai.ToString());
                    HoaDonDAL.Instance.UpdateMaKHHoaDon(MaHD, MaKH);
                    MessageBox.Show("Thêm thành công!");
                }
                else if (rdbtnKhachHangCu.Checked)
                {
                    //Lưu thông tin KH
                    //Lưu mã KH vào hóa đơn
                    try
                    {
                        int MaKH = int.Parse(txtMaKH.Text.Trim());

                        KhachHangDAL.Instance.UpdateKhachHangCu(int.Parse(txtMaKH.Text), txtTenKH.Text, DienThoai.ToString());
                        HoaDonDAL.Instance.UpdateMaKHHoaDon(MaHD, int.Parse(txtMaKH.Text));
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Mã khách hàng là 1 dãy số.");
                        txtMaKH.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Số điện thoại là 1 dãy 10 số .");
                txtDienThoaiKH.Focus();
            }
        }

        private void rdbtnKhachHangMoi_CheckedChanged(object sender, EventArgs e)
        {
            pnTimKiem.Controls.Clear();
            pnTimKiem.BackColor = Color.Gainsboro;

            txtMaKH.Enabled = false;
            txtMaKH.PlaceholderText = "Mã khách hàng";
        }

        private void rdbtnKhachHangCu_CheckedChanged(object sender, EventArgs e)
        {
            pnTimKiem.Controls.Clear();
            pnTimKiem.BackColor = Color.White;

            Label lbTimKiemMaKH = new Label()
            {
                Width = 25,
                Height = 25,
                Location = new Point(0, 0),
                BackgroundImage = Image.FromFile(@"D:\Study_Space\CongNghePhanMem\DoAn\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\Search.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Color.Transparent
            };
            lbTimKiemMaKH.Click += lbTimKiemMaKH_Click;

            pnTimKiem.Controls.Add(lbTimKiemMaKH);
            txtMaKH.Enabled = true;
            txtMaKH.PlaceholderText = "Mời bạn nhập mã khách hàng";
        }

        private void lbTimKiemMaKH_Click(object sender, EventArgs e)
        {
            try
            {
                int MaKH = int.Parse(txtMaKH.Text.Trim());

                List<KhachHang> danhSachKhachHang = KhachHangDAL.Instance.TimKiemKhachHang(int.Parse(txtMaKH.Text));

                foreach (KhachHang item in danhSachKhachHang)
                {
                    txtTenKH.Text = item.HoTen;
                    txtDienThoaiKH.Text = item.DienThoai;
                }
            }
            catch
            {
                MessageBox.Show("Mã khách hàng là 1 dãy số.");
                txtMaKH.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }
    }
}
