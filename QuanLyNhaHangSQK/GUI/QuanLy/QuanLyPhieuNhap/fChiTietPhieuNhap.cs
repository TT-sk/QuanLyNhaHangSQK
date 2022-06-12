using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhieuNhap
{
    public partial class fChiTietPhieuNhap : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private PhieuNhapHang phieuNhap;
        private decimal TongTien;

        public PhieuNhapHang PhieuNhap { get => phieuNhap; set => phieuNhap = value; }

        public fChiTietPhieuNhap(PhieuNhapHang phieuNhapHang)
        {
            InitializeComponent();

            this.PhieuNhap = phieuNhapHang;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            TaiThongTinNhaCCTheoPN();
            TaiThongTinPhieuNhap();
            TaiThongTinMonAn();
            TaiThongTinNguoiLapPhieu();
        }

        private void TaiThongTinNguoiLapPhieu()
        {
            NguoiDung nguoiDung = NguoiDungDAL.Instance.TaithongTinNguoiDungTheoMa(PhieuNhap.MaND);
            txtNgLapPhieu.Text = nguoiDung.HoTen;

        }

        private void TaiThongTinMonAn()
        {
            List<MenuMonAnNhapHang> danhSachMenu = MenuMonAnNhapHangDAL.Instance.TaiDanhSachMonAnNhapHangTheoPN(PhieuNhap.MaPN);
            int stt = 1;

            foreach (var item in danhSachMenu)
            {
                Button btnMonAn = new Button()
                {
                    Width = 630,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat,
                    Text = stt.ToString()
                };

                btnMonAn.FlatAppearance.BorderSize = 0;
                btnMonAn.FlatAppearance.MouseOverBackColor = Color.White;
                btnMonAn.FlatAppearance.MouseDownBackColor = Color.White;

                Label lbTenMA = new Label()
                {
                    Width = 200,
                    Height = 17,
                    Location = new Point(44, 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.TenMA
                };

                Label lbSoLuong = new Label()
                {
                    Width = 50,
                    Height = 17,
                    Location = new Point(268, 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.SoLuong.ToString()
                };

                Label lbDonGia = new Label()
                {
                    Width = 100,
                    Height = 17,
                    Location = new Point(360, 10),
                    TextAlign = ContentAlignment.MiddleRight,
                    Text = item.DonGia.ToString("c", culture)
                };

                Label lbThanhTien = new Label()
                {
                    Width = 100,
                    Height = 17,
                    Location = new Point(508, 10),
                    TextAlign = ContentAlignment.MiddleRight,
                    Text = item.ThanhTien.ToString("c", culture)
                };

                TongTien += item.ThanhTien;
                stt++;

                btnMonAn.Controls.Add(lbThanhTien);
                btnMonAn.Controls.Add(lbTenMA);
                btnMonAn.Controls.Add(lbDonGia);
                btnMonAn.Controls.Add(lbSoLuong);

                flpnMonAn.Controls.Add(btnMonAn);
            }
            lbTongTien.Text = TongTien.ToString("c", culture);
        }

        private void TaiThongTinNhaCCTheoPN()
        {
            NhaCungCap nhaCungCap = NhaCungCapDAL.Instance.TaiNhaCungCapTheoMa(PhieuNhap.MaNCC);

            txtTenNCC.Text = nhaCungCap.TenNCC;
            txtDiaChi.Text = nhaCungCap.DiaChiNCC;
            txtDienThoaiNCC.Text = nhaCungCap.DienThoaiNCC;
        }

        private void TaiThongTinPhieuNhap()
        {
            List<PhieuNhapHang> phieuNhapHang = PhieuNhapHangDAL.Instance.TaiDanhSachPhieuNhapTheoMa(PhieuNhap.MaPN);

            foreach (PhieuNhapHang item in phieuNhapHang)
            {
                lbNgayLapPhieu.Text = String.Format("{0:dd/MM/yyyy}", item.NgayLap);
                txtNgayNhap.Text = String.Format("{0:dd/MM/yyyy}", item.NgayNhapHang);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbGetDate.Text = DateTime.Now.ToString();
        }
    }
}
