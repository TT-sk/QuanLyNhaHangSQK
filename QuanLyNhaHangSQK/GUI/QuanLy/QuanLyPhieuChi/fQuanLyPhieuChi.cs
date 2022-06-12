using ClosedXML.Excel;
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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhieuChi
{
    public partial class fQuanLyPhieuChi : Form
    {

        private List<PhieuChi> phieuChisToExcel;
        private NguoiDung nguoiDungDangNhap;

        public NguoiDung NguoiDungDangNhap
        {
            get { return nguoiDungDangNhap; }
            set { nguoiDungDangNhap = value; }
        }

        public fQuanLyPhieuChi(NguoiDung nguoiDung)
        {
            InitializeComponent();

            this.NguoiDungDangNhap = nguoiDung;
        }

        private void fQuanLyPhieuChi_Load(object sender, EventArgs e)
        {
            TaiDanhSachPhieuChi();
        }

        private void VongLapTaiDanhSachPC(List<PhieuChi> danhSachPhieuChi)
        {
            foreach (PhieuChi item in danhSachPhieuChi)
            {
                Button btnPhieuChi = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };
                btnPhieuChi.Click += btnPhieuChi_Click;
                btnPhieuChi.Tag = item;

                btnPhieuChi.Text = item.MaPC.ToString();

                Label labelPN = new Label()
                {
                    Width = 200,
                    Height = 17,
                    Location = new Point(238, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.MaPN.ToString()
                };
                labelPN.Click += lbPhieuChi_Click;
                labelPN.Tag = item;

                Label labelNgayChi = new Label()
                {
                    Width = 150,
                    Height = 17,
                    Location = new Point(821, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = String.Format("{0:dd/MM/yyyy}", item.NgayChi)
                };
                labelNgayChi.Click += lbPhieuChi_Click;
                labelNgayChi.Tag = item;

                btnPhieuChi.Controls.Add(labelPN);
                btnPhieuChi.Controls.Add(labelNgayChi);

                flpnPhieuChi.Controls.Add(btnPhieuChi);
            }
        }

        private void TaiDanhSachPhieuChi()
        {
            flpnPhieuChi.Controls.Clear();

            List<PhieuChi> danhSachPhieuChi = PhieuChiDAL.Instance.TaiDanhSachPhieuChi();

            VongLapTaiDanhSachPC(danhSachPhieuChi);

            phieuChisToExcel = danhSachPhieuChi;
        }

        private void TaiDanhSachPhieuChiTheoMaPN(int MaPN)
        {
            flpnPhieuChi.Controls.Clear();

            List<PhieuChi> danhSachPhieuChi = PhieuChiDAL.Instance.TaiDanhSachPhieuChiTheoMaPN(MaPN);

            VongLapTaiDanhSachPC(danhSachPhieuChi);

            phieuChisToExcel = danhSachPhieuChi;
        }

        private void TaiDanhSachPhieuChiTheoNgayChi(string NgayBD, string NgayKT)
        {
            flpnPhieuChi.Controls.Clear();

            List<PhieuChi> danhSachPhieuChi = PhieuChiDAL.Instance.TaiDanhSachPhieuChiTheoNgayChi(NgayBD, NgayKT);

            VongLapTaiDanhSachPC(danhSachPhieuChi);

            phieuChisToExcel = danhSachPhieuChi;
        }

        private void btnPhieuChi_Click(object sender, EventArgs e)
        {
            PhieuChi phieuChi = (sender as Button).Tag as PhieuChi;

            fChiTietPhieuChi f = new fChiTietPhieuChi(phieuChi);
            f.ShowDialog();
        }

        private void lbPhieuChi_Click(object sender, EventArgs e)
        {
            PhieuChi phieuChi = (sender as Label).Tag as PhieuChi;

            fChiTietPhieuChi f = new fChiTietPhieuChi(phieuChi);
            f.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaPN = int.Parse(txtTimKiem.Text.Trim());

                TaiDanhSachPhieuChiTheoMaPN(MaPN);
            }
            catch
            {
                MessageBox.Show("Mã phiếu nhập là 1 dãy số.");
                txtTimKiem.Focus();
            }
        }

        private void datetimeBatDau_ValueChanged(object sender, EventArgs e)
        {
            datetimeBatDau.CustomFormat = "yyyy-MM-dd";
            datetimeKetThuc.CustomFormat = "yyyy-MM-dd";
            TaiDanhSachPhieuChiTheoNgayChi(datetimeBatDau.Text, datetimeKetThuc.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemPhieuChi f = new fThemPhieuChi(NguoiDungDangNhap);
            f.ShowDialog();
            TaiDanhSachPhieuChi();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            DataTable data = PhieuChiDAL.Instance.ListToDataTable(phieuChisToExcel);

                            workbook.Worksheets.Add(data, "tblPhieuChi");
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file excel thành công!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
