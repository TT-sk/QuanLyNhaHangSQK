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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyBoPhan
{
    public partial class fQuanLyBoPhan : Form
    {
        private List<BoPhan> boPhansToExcel;
        public fQuanLyBoPhan()
        {
            InitializeComponent();
        }

        private void fQuanLyBoPhan_Load(object sender, EventArgs e)
        {
            TaiDanhSachBoPhan();
        }

        private void VongLapTaiDanhSachBoPhan(List<BoPhan> boPhans)
        {
            foreach (var item in boPhans)
            {
                Button btnBoPhan = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnBoPhan.Text = item.MaBP;
                btnBoPhan.Click += btnBoPhan_Click;
                btnBoPhan.Tag = item;

                Label labelTenBP = new Label()
                {
                    Width = 300,
                    Height = 17,
                    Location = new Point(335, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.TenBP
                };
                labelTenBP.Click += labelTenBP_Click;
                labelTenBP.Tag = item;

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

                btnBoPhan.Controls.Add(labelTenBP);
                btnBoPhan.Controls.Add(labelXoa);

                flpnBP.Controls.Add(btnBoPhan);
            }
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            string MaBP = ((sender as Label).Tag as BoPhan).MaBP;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bộ phận này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (BoPhanDAL.Instance.XoaBoPhan(MaBP))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachBoPhan();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void labelTenBP_Click(object sender, EventArgs e)
        {
            BoPhan boPhan = (sender as Label).Tag as BoPhan;

            fChiTietBoPhan f = new fChiTietBoPhan(boPhan);
            f.ShowDialog();
            TaiDanhSachBoPhan();
        }

        private void btnBoPhan_Click(object sender, EventArgs e)
        {
            BoPhan boPhan = (sender as Button).Tag as BoPhan;

            fChiTietBoPhan f = new fChiTietBoPhan(boPhan);
            f.ShowDialog();
            TaiDanhSachBoPhan();
        }

        private void TaiDanhSachBoPhan()
        {
            flpnBP.Controls.Clear();

            List<BoPhan> danhSachBoPhan = BoPhanDAL.Instance.TaiDanhSachBoPhan();

            VongLapTaiDanhSachBoPhan(danhSachBoPhan);

            boPhansToExcel = danhSachBoPhan;
        }

        private void TaiDanhSachBoPhanTheoTen(string TenBP)
        {
            flpnBP.Controls.Clear();

            List<BoPhan> danhSachBoPhan = BoPhanDAL.Instance.TaiDanhSachBoPhanTheoTen(TenBP);

            VongLapTaiDanhSachBoPhan(danhSachBoPhan);

            boPhansToExcel = danhSachBoPhan;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemBoPhan f = new fThemBoPhan();
            f.ShowDialog();
            TaiDanhSachBoPhan();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin bộ phận!");
            else
                TaiDanhSachBoPhanTheoTen(txtTimKiem.Text);
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
                            DataTable data = BoPhanDAL.Instance.ListToDataTable(boPhansToExcel);

                            workbook.Worksheets.Add(data, "tblBoPhan");
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

                    fThemBoPhanFileExcel f = new fThemBoPhanFileExcel(dt);
                    f.ShowDialog();
                    TaiDanhSachBoPhan();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
