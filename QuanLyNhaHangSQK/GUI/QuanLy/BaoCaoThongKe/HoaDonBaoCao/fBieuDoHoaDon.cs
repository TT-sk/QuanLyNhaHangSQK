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

namespace QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe.HoaDonBaoCao
{
    public partial class fBieuDoHoaDon : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private string ngayBD;
        private string ngayKT;
        private int maCN;

        public int MaCN { get => maCN; set => maCN = value; }
        public string NgayKT { get => ngayKT; set => ngayKT = value; }
        public string NgayBD { get => ngayBD; set => ngayBD = value; }


        public fBieuDoHoaDon(string ngayBD, string ngayKT, int maCN)
        {
            InitializeComponent();

            this.MaCN = maCN;
            this.NgayBD = ngayBD;
            this.NgayKT = ngayKT;
        }

        private void fBieuDoHoaDon_Load(object sender, EventArgs e)
        {
            TaiHoaDon();
        }

        private void TaiHoaDon()
        {
            List<BaoCaoHoaDon> baoCaoHoaDons = DoanhThuGanDayDAL.Instance.BaoCaoHoaDon(NgayBD, NgayKT, MaCN);
            XoaItemBieuDoHoaDon();
            TaiBieuDo(baoCaoHoaDons);
        }

        private void TaiBieuDo(List<BaoCaoHoaDon> baoCaoHoaDons)
        {
            foreach (BaoCaoHoaDon item in baoCaoHoaDons)
            {
                cBieuDoHoaDon.Series["Tổng tiền"].Points.AddXY("Hóa đơn " + item.MaHD, item.TongHD.ToString("c", culture));
                cBieuDoHoaDon.Series["Giảm giá"].Points.AddXY("Hóa đơn " + item.MaHD, item.GiamGia.ToString("c", culture));
                cBieuDoHoaDon.Series["Thành tiền"].Points.AddXY("Hóa đơn " + item.MaHD, item.ThanhTien.ToString("c", culture));
            }
        }

        private void XoaItemBieuDoHoaDon()
        {
            foreach (var series in cBieuDoHoaDon.Series)
            {
                series.Points.Clear();
            }
        }
    }
}
