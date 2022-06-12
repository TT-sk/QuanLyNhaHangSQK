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

namespace QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe.DoanhSo
{
    public partial class fBieuDoDoanhSo : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private int maCN;
        private int nam;

        public int MaCN { get => maCN; set => maCN = value; }
        public int Nam { get => nam; set => nam = value; }

        public fBieuDoDoanhSo(int maCN, int nam)
        {
            InitializeComponent();

            this.MaCN = maCN;
            this.Nam = nam;
        }

        private void fBieuDoDoanhSo_Load(object sender, EventArgs e)
        {
            TaiDoanhThu();
        }

        private void TaiDoanhThu()
        {
            List<BaoCaoDoanhSoThuChi> baoCaoDoanhSoThuChis = DoanhThuGanDayDAL.Instance.DoanhSoThuChi(MaCN, Nam);
            XoaItemBieuDoDoanhSo();
            TaiBieuDo(baoCaoDoanhSoThuChis);
        }

        private void TaiBieuDo(List<BaoCaoDoanhSoThuChi> baoCaoDoanhSoThuChis)
        {
            foreach (BaoCaoDoanhSoThuChi item in baoCaoDoanhSoThuChis)
            {
                cBieuDoDoanhSo.Series["Tổng thu"].Points.AddXY("Tháng " + item.Thang, item.TongThu.ToString("c", culture));
                cBieuDoDoanhSo.Series["Tổng chi"].Points.AddXY("Tháng " + item.Thang, item.TongChi.ToString("c", culture));
                cBieuDoDoanhSo.Series["Lãi suất"].Points.AddXY("Tháng " + item.Thang, (item.TongThu - item.TongChi).ToString("c", culture));
            }
        }

        private void XoaItemBieuDoDoanhSo()
        {
            foreach (var series in cBieuDoDoanhSo.Series)
            {
                series.Points.Clear();
            }
        }
    }
}
