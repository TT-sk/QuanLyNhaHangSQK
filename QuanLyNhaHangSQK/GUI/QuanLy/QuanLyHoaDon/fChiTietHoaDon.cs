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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyHoaDon
{
    public partial class fChiTietHoaDon : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private HoaDon hoaDon;
        private decimal TongHoaDon;
        private decimal GiamGia;
        private decimal KhachTra;

        public HoaDon HoaDon { get => hoaDon; set => hoaDon = value; }

        public fChiTietHoaDon(HoaDon maHoaDon)
        {
            InitializeComponent();

            this.HoaDon = maHoaDon;
        }

        private void fChiTietHoaDon_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            TaiDanhSachMonAn();
        }

        private void TaiDanhSachMonAn()
        {
            List<DTO.Menu> danhSachMonAn = MenuDAL.Instance.TaiDanhSachMonAnTheoHoaDon(HoaDon.MaHD);

            int MaKH = HoaDonDAL.Instance.LayMaKHTheoHoaDon(HoaDon.MaHD);
            int MaKM = HoaDonDAL.Instance.LayMaKMTheoHoaDon(HoaDon.MaHD);
            NguoiDung nguoiDung = NguoiDungDAL.Instance.TaithongTinNguoiDungTheoMa(HoaDon.MaND);

            lbNgayThanhToan.Text = String.Format("{0:u}", HoaDon.TGTT);
            txtNgLapPhieu.Text = nguoiDung.HoTen;

            decimal MucKM = 0;


            if (MaKM != 0)
            {
                KhuyenMai khuyenMai = KhuyenMaiDAL.Instance.LayTTKMTheoMaKM(MaKM);
                MucKM = (decimal)khuyenMai.MucKM;
            }

            if (MaKH != 0)
            {
                KhachHang khachHang = KhachHangDAL.Instance.LayTTKHTheoMaKH(MaKH);
                txtTenKH.Text = khachHang.HoTen;
                txtDienThoaiKH.Text = khachHang.DienThoai;
            }

            int stt = 1;

            foreach (DTO.Menu item in danhSachMonAn)
            {
                Button btnMonAn = new Button()
                {
                    Width = 610,
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

                Label labelTenMA = new Label()
                {
                    Width = 200,
                    Height = 17,
                    Location = new Point(40, 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.TenMA
                };

                Label labelSoLuong = new Label()
                {
                    Width = 50,
                    Height = 17,
                    Location = new Point(268, 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.SoLuong.ToString()
                };

                Label labelGiaTien = new Label()
                {
                    Width = 100,
                    Height = 17,
                    Location = new Point(360, 10),
                    TextAlign = ContentAlignment.MiddleRight,
                    Text = item.GiaTien.ToString("c", culture)
                };

                Label labelTongTien = new Label()
                {
                    Width = 100,
                    Height = 17,
                    Location = new Point(508, 10),
                    TextAlign = ContentAlignment.MiddleRight,
                    Text = item.TongTien.ToString("c", culture)
                };

                TongHoaDon += item.TongTien;
                stt++;

                btnMonAn.Controls.Add(labelTenMA);
                btnMonAn.Controls.Add(labelSoLuong);
                btnMonAn.Controls.Add(labelGiaTien);
                btnMonAn.Controls.Add(labelTongTien);

                flpnMonAn.Controls.Add(btnMonAn);
            }
            GiamGia = TongHoaDon * MucKM;
            KhachTra = TongHoaDon - GiamGia;

            lbTongTien.Text = TongHoaDon.ToString("c", culture);
            lbGiamGia.Text = GiamGia.ToString("c", culture);
            lbKhachTra.Text = KhachTra.ToString("c", culture);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbGetDate.Text = DateTime.Now.ToString();
        }
    }
}
