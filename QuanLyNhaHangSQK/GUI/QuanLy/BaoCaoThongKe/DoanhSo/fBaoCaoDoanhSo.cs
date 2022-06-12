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

namespace QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe.DoanhSo
{
    public partial class fBaoCaoDoanhSo : Form
    {
        private int maCN;
        private int nam;

        public int MaCN { get => maCN; set => maCN = value; }
        public int Nam { get => nam; set => nam = value; }

        public fBaoCaoDoanhSo(int maCN, int nam)
        {
            InitializeComponent();

            this.MaCN = maCN;
            this.Nam = nam;
        }


        private void fBaoCaoDoanhSo_Load(object sender, EventArgs e)
        {

            ChiNhanh chiNhanh = ChiNhanhDAL.Instance.TaiChiNhanhTheoCN(MaCN);
            CTY cTY = CTYDAL.Instance.TaiThongTinCTY();

            ReportParameter prTenCN = new ReportParameter("prTenCN", chiNhanh.TenCN);
            ReportParameter prTenCTY = new ReportParameter("prTenCTY", cTY.TenCTY);
            ReportParameter prDienThoai = new ReportParameter("prDienThoai", cTY.DienThoaiCTY);
            ReportParameter prDiaChi = new ReportParameter("prDiaChi", cTY.DiaChi);
            ReportParameter prNam = new ReportParameter("prNam", Nam.ToString());

            this.reportDoanhSo.LocalReport.SetParameters(new ReportParameter[] { prTenCN, prTenCTY, prDienThoai, prDiaChi , prNam});


            List<BaoCaoDoanhSoThuChi> baoCaoDoanhSoThuChis = DoanhThuGanDayDAL.Instance.DoanhSoThuChi(MaCN, Nam);
            this.baoCaoDoanhSoThuChiBindingSource.DataSource = baoCaoDoanhSoThuChis;


            this.reportDoanhSo.RefreshReport();
        }
    }
}
