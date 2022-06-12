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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyHoaDon
{
    public partial class fQuanLyHoaDon : Form
    {
        private List<HoaDon> hoaDonsToExcel;

        public fQuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void fQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            TaiDanhSachHoaDon();
        }

        private void VongLapTaiDanhSachHD(List<HoaDon> danhSachHoaDon)
        {
            foreach (HoaDon item in danhSachHoaDon)
            {
                Button btnHoaDon = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };
                btnHoaDon.Click += btnHoaDon_Click;
                btnHoaDon.Tag = item;

                btnHoaDon.Text = item.MaHD.ToString();

                Label labelTGTT = new Label()
                {
                    Width = 200,
                    Height = 17,
                    Location = new Point(538, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = String.Format("{0:u}", item.TGTT)
                };
                labelTGTT.Click += lbHoaDon_Click;
                labelTGTT.Tag = item;

                Label labelTinhTrang = new Label()
                {
                    Width = 150,
                    Height = 17,
                    Location = new Point(821, 11),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                labelTinhTrang.Click += lbHoaDon_Click;
                labelTinhTrang.Tag = item;

                if (item.TinhTrang)
                    labelTinhTrang.Text = "Đã thanh toán";
                else
                    labelTinhTrang.Text = "Chưa thanh toán";

                btnHoaDon.Controls.Add(labelTGTT);
                btnHoaDon.Controls.Add(labelTinhTrang);

                flpnHoaDon.Controls.Add(btnHoaDon);
            }
        }

        private void TaiDanhSachHoaDon()
        {
            flpnHoaDon.Controls.Clear();

            List<HoaDon> danhSachHoaDon = HoaDonDAL.Instance.TaiDanhSachHoaDon();

            VongLapTaiDanhSachHD(danhSachHoaDon);

            hoaDonsToExcel = danhSachHoaDon;
        }

        private void TaiDanhSachHoaDonTheoNgay(string NgayBD, string NgayKT)
        {
            flpnHoaDon.Controls.Clear();

            List<HoaDon> danhSachHoaDon = HoaDonDAL.Instance.TaiDanhSachHoaDonTheoNgay(NgayBD, NgayKT);

            VongLapTaiDanhSachHD(danhSachHoaDon);

            hoaDonsToExcel = danhSachHoaDon;
        }

        private void TaiDanhSachHoaDonTheoMaHD(int MaHD)
        {
            flpnHoaDon.Controls.Clear();

            List<HoaDon> danhSachHoaDon = HoaDonDAL.Instance.TaiDanhSachHoaDonTheoMaHD(MaHD);

            VongLapTaiDanhSachHD(danhSachHoaDon);

            hoaDonsToExcel = danhSachHoaDon;
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = ((sender as Button).Tag as HoaDon);

            fChiTietHoaDon f = new fChiTietHoaDon(hoaDon);
            f.ShowDialog();
        }

        private void lbHoaDon_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = ((sender as Label).Tag as HoaDon);

            fChiTietHoaDon f = new fChiTietHoaDon(hoaDon);
            f.ShowDialog();
        }

        private void datetimeBatDau_ValueChanged(object sender, EventArgs e)
        {
            datetimeBatDau.CustomFormat = "yyyy-MM-dd";
            datetiemKetThuc.CustomFormat = "yyyy-MM-dd";
            TaiDanhSachHoaDonTheoNgay(datetimeBatDau.Text, datetiemKetThuc.Text);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaHD = int.Parse(txtTimKiem.Text.Trim());

                TaiDanhSachHoaDonTheoMaHD(MaHD);
            }
            catch
            {
                MessageBox.Show("Mã hóa đơn là 1 dãy số.");
                txtTimKiem.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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
                            DataTable data = HoaDonDAL.Instance.ListToDataTable(hoaDonsToExcel);

                            workbook.Worksheets.Add(data, "tblHoaDon");
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
