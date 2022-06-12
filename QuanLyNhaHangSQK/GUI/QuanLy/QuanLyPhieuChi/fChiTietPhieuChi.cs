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
    public partial class fChiTietPhieuChi : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private PhieuChi phieuChi;

        public PhieuChi PhieuChi { get => phieuChi; set => phieuChi = value; }

        public fChiTietPhieuChi(PhieuChi phieuChi)
        {
            InitializeComponent();

            this.PhieuChi = phieuChi;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbGetDate.Text = DateTime.Now.ToString();
        }

        private void fChiTietPhieuChi_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            lbNgayLapPhieu.Text = String.Format("{0:dd/MM/yyyy}", PhieuChi.NgayChi);

            TaiThongTinNCC();
            TaiTongTien();
            TaiNguoiLapPhieu();
        }

        private void TaiNguoiLapPhieu()
        {
            NguoiDung nguoiDung = NguoiDungDAL.Instance.TaithongTinNguoiDungTheoMa(PhieuChi.MaND);
            txtNgLapPhieu.Text = nguoiDung.HoTen;
        }

        private void TaiTongTien()
        {
            decimal thanhTien = PhieuChiDAL.Instance.TongTienPhieuChi(PhieuChi.MaPN);

            txtTongTien.Text = thanhTien.ToString("c", culture);
        }

        private void TaiThongTinNCC()
        {
            string MaNCC = PhieuNhapHangDAL.Instance.LayMaNCCTheoMaPN(PhieuChi.MaPN);
            NhaCungCap nhaCungCap = NhaCungCapDAL.Instance.TaiNhaCungCapTheoMa(MaNCC);

            txtTenNCC.Text = nhaCungCap.TenNCC;
            txtDienThoaiNCC.Text = nhaCungCap.DienThoaiNCC;
            txtDiaChi.Text = nhaCungCap.DiaChiNCC;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
