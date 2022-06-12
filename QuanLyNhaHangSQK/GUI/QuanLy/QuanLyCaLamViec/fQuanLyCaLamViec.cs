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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyCaLamViec
{
    public partial class fQuanLyCaLamViec : Form
    {
        private List<CaLamViec> caLamViecsToExcel;

        public fQuanLyCaLamViec()
        {
            InitializeComponent();
        }

        private void fQuanLyCaLamViec_Load(object sender, EventArgs e)
        {

            TaiDanhSachCaLamViec();
        }

        private void VongLapTaiDanhSachCaLamViec(List<CaLamViec> danhSachCaLamViec)
        {
            foreach(var item in danhSachCaLamViec)
            {
                Button btnCaLamViec = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnCaLamViec.Text = item.TenCLV;
                btnCaLamViec.Click += btnCaLamViec_Click;
                btnCaLamViec.Tag = item;

                TimeSpan timeBD = new TimeSpan(item.GioBatDau.Hours, item.GioBatDau.Minutes, item.GioBatDau.Seconds);
                TimeSpan timeKT = new TimeSpan(item.GioKetThuc.Hours, item.GioKetThuc.Minutes, item.GioKetThuc.Seconds);

                Label labelGioBD = new Label()
                {
                    Width = 300,
                    Height = 17,
                    Location = new Point(335, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = string.Format("{0:D2} : {1:D2} : {2:D2}", timeBD.Hours, timeBD.Minutes, timeBD.Seconds)
                };
                labelGioBD.Click += labelCaLamViec_Click;
                labelGioBD.Tag = item;

                Label labelGioKT = new Label()
                {
                    Width = 300,
                    Height = 17,
                    Location = new Point(630, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = string.Format("{0:D2} : {1:D2} : {2:D2}", timeKT.Hours, timeKT.Minutes, timeKT.Seconds)
                };
                labelGioKT.Click += labelCaLamViec_Click;
                labelGioKT.Tag = item;

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

                btnCaLamViec.Controls.Add(labelGioKT);
                btnCaLamViec.Controls.Add(labelGioBD);
                btnCaLamViec.Controls.Add(labelXoa);

                flpnCLV.Controls.Add(btnCaLamViec);
            }
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            string MaCLV = ((sender as Label).Tag as CaLamViec).MaCLV;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ca làm việc này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (CaLamViecDAL.Instance.XoaCaLamViec(MaCLV))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachCaLamViec();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void TaiDanhSachCaLamViec()
        {
            flpnCLV.Controls.Clear();

            List<CaLamViec> danhSachCaLamViec = CaLamViecDAL.Instance.TaiDanhSachCaLamViec() ;

            VongLapTaiDanhSachCaLamViec(danhSachCaLamViec);

            caLamViecsToExcel = danhSachCaLamViec;
        }

        private void TaiDanhSachCaLamViecTheoTen(string TenCLV)
        {
            flpnCLV.Controls.Clear();

            List<CaLamViec> danhSachCaLamViec = CaLamViecDAL.Instance.TaiDanhSachCaLamViecTheoTen(TenCLV);

            VongLapTaiDanhSachCaLamViec(danhSachCaLamViec);

            caLamViecsToExcel = danhSachCaLamViec;
        }

        private void labelCaLamViec_Click(object sender, EventArgs e)
        {
            CaLamViec caLamViec = (sender as Label).Tag as CaLamViec;

            fChiTietCaLamViec f = new fChiTietCaLamViec(caLamViec);
            f.ShowDialog();
            TaiDanhSachCaLamViec();
        }

        private void btnCaLamViec_Click(object sender, EventArgs e)
        {
            CaLamViec caLamViec = (sender as Button).Tag as CaLamViec;

            fChiTietCaLamViec f = new fChiTietCaLamViec(caLamViec);
            f.ShowDialog();
            TaiDanhSachCaLamViec();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin ca làm việc!");
            else
                TaiDanhSachCaLamViecTheoTen(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemCaLamViec f = new fThemCaLamViec();
            f.ShowDialog();
            TaiDanhSachCaLamViec();
        }

        private void label1_Click(object sender, EventArgs e)
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
                            DataTable data = CaLamViecDAL.Instance.ListToDataTable(caLamViecsToExcel);

                            workbook.Worksheets.Add(data, "tblCaLamViec");
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

                    fThemCaLamViecFileExcel f = new fThemCaLamViecFileExcel(dt);
                    f.ShowDialog();
                    TaiDanhSachCaLamViec();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
