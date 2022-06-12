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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhanVien
{
    public partial class fQuanLyNhanVien : Form
    {
        private List<NguoiDung> nguoiDungsToExcel;

        public fQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            TaiDanhSachBoPhan();
            TaiDanhSachChiNhanh();
            TaiDanhSachNhanVien();
            TaiDanhSachCaLamViec();
        }

        private void TaiDanhSachChiNhanh()
        {
            List<ChiNhanh> danhSachChiNhanh = ChiNhanhDAL.Instance.TaiDanhSachChiNhanh();

            foreach (var item in danhSachChiNhanh)
            {
                Button btnChiNhanh = new Button()
                {
                    Width = 250,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 0, 192)
                };
                btnChiNhanh.Click += btnChiNhanh_Click;
                btnChiNhanh.Tag = item;

                btnChiNhanh.Text = item.TenCN;

                flpnChiNhanh.Controls.Add(btnChiNhanh);
            }
        }


        private void TaiDanhSachBoPhan()
        {
            List<BoPhan> danhSachBoPhan = BoPhanDAL.Instance.TaiDanhSachBoPhan();

            foreach (var item in danhSachBoPhan)
            {
                Button btnBoPhan = new Button()
                {
                    Width = 250,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 0, 192)
                };
                btnBoPhan.Click += btnBoPhan_Click;
                btnBoPhan.Tag = item;
                btnBoPhan.Text = item.TenBP;

                flpnBoPhan.Controls.Add(btnBoPhan);
            }
        }

        private void TaiDanhSachCaLamViec()
        {
            List<CaLamViec> danhSachCaLamViec = CaLamViecDAL.Instance.TaiDanhSachCaLamViec();

            cbbCaLamViec.DataSource = danhSachCaLamViec;
            cbbCaLamViec.DisplayMember = "TenCLV";
        }

        private void VongLapTaiDanhSachNhanVien(List<NguoiDung> danhSachNguoiDung)
        {
            foreach (var item in danhSachNguoiDung)
            {
                BoPhan boPhan = BoPhanDAL.Instance.BoPhanNDDangNhap(item.MaBP);
                ChiNhanh chiNhanh = ChiNhanhDAL.Instance.TaiChiNhanhTheoCN(item.MaCN);

                Button btnNhanVien = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnNhanVien.Text = item.HoTen;
                btnNhanVien.Click += btnNhanVien_Click;
                btnNhanVien.Tag = item;

                Label labelTenBP = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(349, 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = boPhan.TenBP
                };
                labelTenBP.Click += labelNhanVien_Click;
                labelTenBP.Tag = item;

                Label labelTenChiNhanh = new Label()
                {
                    Width = 200,
                    Height = 17,
                    Location = new Point(535, 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = chiNhanh.TenCN
                };
                labelTenChiNhanh.Click += labelNhanVien_Click;
                labelTenChiNhanh.Tag = item;

                Label labelTrangThai = new Label()
                {
                    Width = 50,
                    Height = 17,
                    Location = new Point(843, 10),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                labelTrangThai.Click += labelNhanVien_Click;
                labelTrangThai.Tag = item;

                if (item.TrangThai == true)
                {
                    labelTrangThai.Text = "Mở";
                }
                else
                    labelTrangThai.Text = "Khóa";

                Label labelXoa = new Label()
                {
                    Width = 20,
                    Height = 20,
                    Location = new Point(970, 10),
                    BackColor = Color.Transparent,
                    Image = Image.FromFile(@"D:\Study_Space\CongNghePhanMem\DoAn\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\DelMA.png")
                };
                labelXoa.Click += labelXoa_Click;
                labelXoa.Tag = item;

                btnNhanVien.Controls.Add(labelTrangThai);
                btnNhanVien.Controls.Add(labelTenBP);
                btnNhanVien.Controls.Add(labelTenChiNhanh);
                btnNhanVien.Controls.Add(labelXoa);

                flpnNhanVien.Controls.Add(btnNhanVien);
            }
        }

        private void TaiDanhSachNhanVien()
        {
            flpnNhanVien.Controls.Clear();

            List<NguoiDung> danhSachNguoiDung = NguoiDungDAL.Instance.TaiDanhSachNguoiDung();

            VongLapTaiDanhSachNhanVien(danhSachNguoiDung);

            nguoiDungsToExcel = danhSachNguoiDung;
        }

        private void TaiDanhSachNhanVienTheoBoPhan(string MaBP)
        {
            flpnNhanVien.Controls.Clear();

            List<NguoiDung> danhSachNguoiDung = NguoiDungDAL.Instance.TaiDanhSachNguoiDungTheoBP(MaBP);

            VongLapTaiDanhSachNhanVien(danhSachNguoiDung);

            nguoiDungsToExcel = danhSachNguoiDung;
        }

        private void TaiDanhSachNhanVienTheoChiNhanh(int MaCN)
        {
            flpnNhanVien.Controls.Clear();

            List<NguoiDung> danhSachNguoiDung = NguoiDungDAL.Instance.TaiDanhSachNguoiDungTheoChiNhanh(MaCN);

            VongLapTaiDanhSachNhanVien(danhSachNguoiDung);

            nguoiDungsToExcel = danhSachNguoiDung;
        }

        private void TaiDanhSachNhanVienTheoCLV(string MaCLV)
        {
            flpnNhanVien.Controls.Clear();

            List<NguoiDung> danhSachNguoiDung = NguoiDungDAL.Instance.TaiDanhSachNguoiDungTheoCLV(MaCLV);

            VongLapTaiDanhSachNhanVien(danhSachNguoiDung);

            nguoiDungsToExcel = danhSachNguoiDung;
        }

        private void TaiDanhSachNhanVienTheoTimKiem(string HoTen)
        {
            flpnNhanVien.Controls.Clear();

            List<NguoiDung> danhSachNguoiDung = NguoiDungDAL.Instance.TaiDanhSachNguoiDungTheoTenND(HoTen);

            VongLapTaiDanhSachNhanVien(danhSachNguoiDung);

            nguoiDungsToExcel = danhSachNguoiDung;
        }

        private void btnChiNhanh_Click(object sender, EventArgs e)
        {
            int MaCN = ((sender as Button).Tag as ChiNhanh).MaCN;

            TaiDanhSachNhanVienTheoChiNhanh(MaCN);
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            int MaND = ((sender as Label).Tag as NguoiDung).MaND;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (NguoiDungDAL.Instance.XoaNguoiDung(MaND))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachNhanVien();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            int MaND = ((sender as Button).Tag as NguoiDung).MaND;

            fChiTietNhanVien f = new fChiTietNhanVien(MaND);
            f.ShowDialog();
        }

        private void labelNhanVien_Click(object sender, EventArgs e)
        {
            int MaND = ((sender as Label).Tag as NguoiDung).MaND;

            fChiTietNhanVien f = new fChiTietNhanVien(MaND);
            f.ShowDialog();
        }


        private void btnBoPhan_Click(object sender, EventArgs e)
        {
            string MaBP = ((sender as Button).Tag as BoPhan).MaBP;

            TaiDanhSachNhanVienTheoBoPhan(MaBP);

        }

        private void cbbCaLamViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            CaLamViec caLamViec = cbb.SelectedItem as CaLamViec;

            TimeSpan timeBD = new TimeSpan(caLamViec.GioBatDau.Hours, caLamViec.GioBatDau.Minutes, caLamViec.GioBatDau.Seconds);
            txtGioBD.Text = string.Format("{0:D2}", timeBD.Hours);
            txtPhutBD.Text = string.Format("{0:D2}", timeBD.Minutes);
            txtGiayBD.Text = string.Format("{0:D2}", timeBD.Seconds);

            TimeSpan timeKT = new TimeSpan(caLamViec.GioKetThuc.Hours, caLamViec.GioKetThuc.Minutes, caLamViec.GioKetThuc.Seconds);
            txtGioKT.Text = string.Format("{0:D2}", timeKT.Hours);
            txtPhutKT.Text = string.Format("{0:D2}", timeKT.Minutes);
            txtGiayKT.Text = string.Format("{0:D2}", timeKT.Seconds);

            TaiDanhSachNhanVienTheoCLV(caLamViec.MaCLV);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin nhân viên!");
            else
                TaiDanhSachNhanVienTheoTimKiem(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemNhanVien f = new fThemNhanVien();
            f.ShowDialog();

            fQuanLyNhanVien_Load(sender, e);
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
                            DataTable data = NguoiDungDAL.Instance.ListToDataTable(nguoiDungsToExcel);

                            workbook.Worksheets.Add(data, "tblNguoiDung");
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

        private void btnNhapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1;
            string file = ""; //variable for the Excel File Location
            DataTable dt = new DataTable(); //container for our excel data
            DataRow row;
            openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Check if Result == "OK".
            {
                file = openFileDialog1.FileName; //get the filename with the location of the file
                try
                {
                    //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);

                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

                    int rowCount = excelRange.Rows.Count; //get row count of excel data

                    int colCount = excelRange.Columns.Count; // get column count of excel data

                    //Get the first Column of excel file which is the Column Name

                    for (int i = 1; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
                        }
                        break;
                    }

                    //Get Row Data of Excel

                    int rowCounter; //This variable is used for row index number
                    for (int i = 2; i <= rowCount; i++) //Loop for available row of excel data
                    {
                        row = dt.NewRow(); //assign new row to DataTable
                        rowCounter = 0;
                        for (int j = 1; j <= colCount; j++) //Loop for available column of excel data
                        {
                            //check if cell is empty
                            if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                            {
                                row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
                            }
                            else
                            {
                                row[i] = "";
                            }
                            rowCounter++;
                        }
                        dt.Rows.Add(row); //add row to DataTable
                    }

                    fThemNhanVienFileExcel f = new fThemNhanVienFileExcel(dt);
                    f.ShowDialog();
                    TaiDanhSachNhanVien();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
