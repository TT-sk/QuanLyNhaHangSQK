using ClosedXML.Excel;
using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhomHang
{
    public partial class fQuanLyNhomHang : Form
    {
        private List<NhomHang> nhomHangsToExcel;

        public fQuanLyNhomHang()
        {
            InitializeComponent();
        }

        private void fQuanLyNhomHang_Load(object sender, EventArgs e)
        {
            TaiDanhSachNhomHang();
        }

        private void VongLapTaiDanhSachNhomHang(List<NhomHang> nhomHangs)
        {
            foreach (var item in nhomHangs)
            {
                Button btnNhomHang = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnNhomHang.Text = item.MaNH.ToString() ;
                btnNhomHang.Click += btnNhomHang_Click;
                btnNhomHang.Tag = item;

                Label labelTenNH = new Label()
                {
                    Width = 300,
                    Height = 17,
                    Location = new Point(335, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.TenNH
                };
                labelTenNH.Click += labelNhomHang_Click;
                labelTenNH.Tag = item;

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

                btnNhomHang.Controls.Add(labelTenNH);
                btnNhomHang.Controls.Add(labelXoa);

                flpnNH.Controls.Add(btnNhomHang);
            }
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            int MaNH = ((sender as Label).Tag as NhomHang).MaNH;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ca làm việc này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (NhomHangDAL.Instance.XoaNhomHang(MaNH))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachNhomHang();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void TaiDanhSachNhomHang()
        {
            flpnNH.Controls.Clear();

            List<NhomHang> nhomHangs = NhomHangDAL.Instance.TaiDanhSachNhomHang();

            VongLapTaiDanhSachNhomHang(nhomHangs);

            nhomHangsToExcel = nhomHangs;
        }

        private void TaiDanhSachNhomHangTheoTen(string TenNH)
        {
            flpnNH.Controls.Clear();

            List<NhomHang> nhomHangs = NhomHangDAL.Instance.TaiDanhSachNhomHangTheoTen(TenNH);

            VongLapTaiDanhSachNhomHang(nhomHangs);

            nhomHangsToExcel = nhomHangs;
        }

        private void labelNhomHang_Click(object sender, EventArgs e)
        {
            NhomHang nhomHang = (sender as Label).Tag as NhomHang;

            fChiTietNhomHang f = new fChiTietNhomHang(nhomHang);
            f.ShowDialog();

            TaiDanhSachNhomHang();
        }

        private void btnNhomHang_Click(object sender, EventArgs e)
        {
            NhomHang nhomHang = (sender as Button).Tag as NhomHang;

            fChiTietNhomHang f = new fChiTietNhomHang(nhomHang);
            f.ShowDialog();

            TaiDanhSachNhomHang();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin nhóm hàng!");
            else
                TaiDanhSachNhomHangTheoTen(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemNhomHang f = new fThemNhomHang();
            f.ShowDialog();

            TaiDanhSachNhomHang();
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
                            DataTable data = NhomHangDAL.Instance.ListToDataTable(nhomHangsToExcel);

                            workbook.Worksheets.Add(data, "tblNhomHang");
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

                    fThemNhomHangFileExcel f = new fThemNhomHangFileExcel(dt);
                    f.ShowDialog();
                    TaiDanhSachNhomHang();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
