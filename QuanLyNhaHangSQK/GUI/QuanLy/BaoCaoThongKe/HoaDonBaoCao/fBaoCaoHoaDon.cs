using Microsoft.Reporting.WinForms;
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

namespace QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe.HoaDonBaoCao
{
    public partial class fBaoCaoHoaDon : Form
    {
        private string ngayBD;
        private string ngayKT;
        private int maCN;

        public int MaCN { get => maCN; set => maCN = value; }
        public string NgayKT { get => ngayKT; set => ngayKT = value; }
        public string NgayBD { get => ngayBD; set => ngayBD = value; }


        public fBaoCaoHoaDon(string ngayBD, string ngayKT, int maCN)
        {
            InitializeComponent();

            this.MaCN = maCN;
            this.NgayBD = ngayBD;
            this.NgayKT = ngayKT;
        }

        private void fBaoCaoHoaDon_Load(object sender, EventArgs e)
        {
            ChiNhanh chiNhanh = ChiNhanhDAL.Instance.TaiChiNhanhTheoCN(MaCN);
            CTY cTY = CTYDAL.Instance.TaiThongTinCTY();

            ReportParameter prTenCN = new ReportParameter("prTenCN", chiNhanh.TenCN);
            ReportParameter prTenCTY = new ReportParameter("prTenCTY", cTY.TenCTY);
            ReportParameter prDienThoai = new ReportParameter("prDienThoai", cTY.DienThoaiCTY);
            ReportParameter prDiaChi = new ReportParameter("prDiaChi", cTY.DiaChi);

            this.reportHoaDon.LocalReport.SetParameters(new ReportParameter[] { prTenCN, prTenCTY, prDienThoai, prDiaChi });


            List<BaoCaoHoaDon> baoCaoDoanhSoThuChis = DoanhThuGanDayDAL.Instance.BaoCaoHoaDon(NgayBD, NgayKT, MaCN);
            this.BaoCaoHoaDonBindingSource.DataSource = baoCaoDoanhSoThuChis;

            this.reportHoaDon.RefreshReport();

            
        }
    }
}
