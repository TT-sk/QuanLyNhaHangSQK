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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhieuChi
{
    public partial class fThemPhieuChi : Form
    {
        CultureInfo culture = new CultureInfo("es-US");
         
        private NguoiDung nguoiDungDangNhap;

        public NguoiDung NguoiDungDangNhap
        {
            get { return nguoiDungDangNhap; }
            set { nguoiDungDangNhap = value; }
        }

        public fThemPhieuChi(NguoiDung nguoiDung)
        {
            InitializeComponent();

            this.NguoiDungDangNhap = nguoiDung;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fThemPhieuChi_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            TaiDanhSachPN();
            TaiThongTinNguoiDung();
        }

        private void TaiThongTinNCCTheoMa(string MaNCC)
        {
            NhaCungCap nhaCungCap = NhaCungCapDAL.Instance.TaiNhaCungCapTheoMa(MaNCC);

            txtTenNCC.Text = nhaCungCap.TenNCC;
            txtDienThoaiNCC.Text = nhaCungCap.DienThoaiNCC;
            txtDiaChi.Text = nhaCungCap.DiaChiNCC;
        }

        private void TaiDanhSachPN()
        {
            List<PhieuNhapHang> danhSachPhieuNhap = PhieuNhapHangDAL.Instance.TaiDanhSachPhieuNhap();

            cbbMaPN.DataSource = danhSachPhieuNhap;
            cbbMaPN.DisplayMember = "MaPN";
        }

        private void TaiTongTienPN(int MaPN)
        {
            decimal thanhTien = PhieuChiDAL.Instance.TongTienPhieuChi(MaPN);

            txtTongTien.Text = thanhTien.ToString("c", culture);
        }

        private void TaiThongTinNguoiDung()
        {
            NguoiDung nguoiDung = NguoiDungDAL.Instance.TaithongTinNguoiDungTheoMa(NguoiDungDangNhap.MaND);

            txtNgLapPhieu.Text = nguoiDung.HoTen;
        }

        private void cbbMaPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;
            PhieuNhapHang phieuNhapHang = cbb.SelectedItem as PhieuNhapHang;

            TaiThongTinNCCTheoMa(phieuNhapHang.MaNCC);
            TaiTongTienPN(phieuNhapHang.MaPN);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int MaND = NguoiDungDangNhap.MaND;
                int MaPN = (cbbMaPN.SelectedItem as PhieuNhapHang).MaPN;

                if (PhieuChiDAL.Instance.ThemPhieuChi(MaND, MaPN))
                {
                    PhieuNhapHangDAL.Instance.SuaPhieuNhap(MaPN);
                    MessageBox.Show("Thêm thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbGetDate.Text = DateTime.Now.ToString();
        }
    }
}
