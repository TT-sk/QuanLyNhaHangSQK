using ClosedXML.Excel;
using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn;
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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn
{
    public partial class fQuanLyMonAn : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private List<MonAn> monAnsToExcel;

        public fQuanLyMonAn()
        {
            InitializeComponent();
        }

        private void fQuanLyMonAn_Load(object sender, EventArgs e)
        {
            TaiDanhSachMonAn();
            TaiDanhSachNhomHang();
        }

        private void VongLapTaiDanhSachMA(List<MonAn> danhSachMonAn)
        {
            foreach (var item in danhSachMonAn)
            {
                Button btnMonAn = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnMonAn.Text = item.TenMA;
                btnMonAn.Click += btnMonAn_Click;
                btnMonAn.Tag = item;

                Label labelGiaBan = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(538, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.GiaTien.ToString("c", culture)
                };
                labelGiaBan.Click += lbMonAn_Click;
                labelGiaBan.Tag = item;

                Label labelGiaGoc = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(821, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.GiaGoc.ToString("c", culture)
                };
                labelGiaGoc.Click += lbMonAn_Click;
                labelGiaGoc.Tag = item;

                Label labelXoa = new Label()
                {
                    Width = 20,
                    Height = 20,
                    Location = new Point(970, 10),
                    BackColor = Color.Transparent,
                    Image = Image.FromFile(@"C:\Users\thien\Downloads\res\quanlynhahang\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\DelMA.png")
                };
                labelXoa.Click += labelXoa_Click;
                labelXoa.Tag = item;

                btnMonAn.Controls.Add(labelGiaBan);
                btnMonAn.Controls.Add(labelGiaGoc);
                btnMonAn.Controls.Add(labelXoa);

                flpnMonAn.Controls.Add(btnMonAn);
            }
        }

        private void TaiDanhSachMonAn()
        {
            flpnMonAn.Controls.Clear();

            List<MonAn> danhSachMonAn = MonAnDAL.Instance.TaiDanhSachMonAn();

            VongLapTaiDanhSachMA(danhSachMonAn);

            monAnsToExcel = danhSachMonAn;
        }

        public void TaiDanhSachMonAnTheoNhomHang(int MaNH)
        {
            flpnMonAn.Controls.Clear();

            List<MonAn> danhSachMonAn = MonAnDAL.Instance.TaiDanhSachMonAnTheoNhomHang(MaNH);

            VongLapTaiDanhSachMA(danhSachMonAn);

            monAnsToExcel = danhSachMonAn;
        }

        public void TaiDanhSachMonAnTheoTimKiem(string TenMA)
        {
            flpnMonAn.Controls.Clear();

            List<MonAn> danhSachMonAn = MonAnDAL.Instance.TimKiemMonAnTheoTenMA(TenMA);

            VongLapTaiDanhSachMA(danhSachMonAn);

            monAnsToExcel = danhSachMonAn;
        }

        private void TaiDanhSachNhomHang()
        {
            List<NhomHang> danhSachNhomHang = NhomHangDAL.Instance.TaiDanhSachNhomHang();

            foreach (var item in danhSachNhomHang)
            {
                Button btnNhomHang = new Button()
                {
                    Width = 250,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 0, 192)
                };
                btnNhomHang.Click += btnNhomHang_Click;
                btnNhomHang.Tag = item;
                btnNhomHang.Text = item.TenNH;

                flpnNhomHang.Controls.Add(btnNhomHang);
            }
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            int MaMA = ((sender as Label).Tag as MonAn).MaMA;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (MonAnDAL.Instance.XoaMonAn(MaMA))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachMonAn();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnNhomHang_Click(object sender, EventArgs e)
        {
            int MaNH = ((sender as Button).Tag as NhomHang).MaNH;

            TaiDanhSachMonAnTheoNhomHang(MaNH);
        }

        private void btnMonAn_Click(object sender, EventArgs e)
        {
            int MaMA = ((sender as Button).Tag as MonAn).MaMA;
            MonAn monAn = MonAnDAL.Instance.MonAnHienTai(MaMA);
            fChiTietMonAn f = new fChiTietMonAn(monAn);
            f.ShowDialog();
        }

        private void lbMonAn_Click(object sender, EventArgs e)
        {
            int MaMA = ((sender as Label).Tag as MonAn).MaMA;
            MonAn monAn = MonAnDAL.Instance.MonAnHienTai(MaMA);
            fChiTietMonAn f = new fChiTietMonAn(monAn);
            f.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin món ăn!");
            else
                TaiDanhSachMonAnTheoTimKiem(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemMonAn f = new fThemMonAn();
            f.ShowDialog();
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
                            DataTable data = MonAnDAL.Instance.ListToDataTable(monAnsToExcel);

                            workbook.Worksheets.Add(data, "tblMonAn");
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

                    fThemMonAnFileExcel f = new fThemMonAnFileExcel(dt);
                    f.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
