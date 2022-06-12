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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyChiNhanh
{
    public partial class fQuanLyChiNhanh : Form
    {
        private List<ChiNhanh> chiNhanhsToExcel;

        public fQuanLyChiNhanh()
        {
            InitializeComponent();
        }

        private void fQuanLyChiNhanh_Load(object sender, EventArgs e)
        {
            TaiDanhSachCTY();
            TaiDanhSachChiNhanh();
        }

        private void TaiDanhSachCTY()
        {
            List<CTY> danhSachCTY = CTYDAL.Instance.TaiDanhSachCTY();

            foreach (var item in danhSachCTY)
            {
                Button btnCTY = new Button()
                {
                    Width = 250,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 0, 192)
                };
                btnCTY.Click += btnCTY_Click;
                btnCTY.Tag = item;

                btnCTY.Text = item.TenCTY;

                flpnCTy.Controls.Add(btnCTY);
            }
        }

        private void VongLapTaiDanhSachChiNhanh(List<ChiNhanh> danhSachChiNhanh)
        {
            foreach (ChiNhanh item in danhSachChiNhanh)
            {
                CTY cTY = CTYDAL.Instance.TaiThongTinCTYTheoMa(item.MaCTY);

                Button btnChiNhanh = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };
                btnChiNhanh.Click += btnChiNhanh_Click;
                btnChiNhanh.Tag = item;

                btnChiNhanh.Text = item.MaCN.ToString();

                Label labelTenCN = new Label()
                {
                    Width = 200,
                    Height = 17,
                    Location = new Point(238, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.TenCN
                };
                labelTenCN.Click += lbChiNhanh_Click;
                labelTenCN.Tag = item;

                Label labelTenCTy = new Label()
                {
                    Width = 150,
                    Height = 17,
                    Location = new Point(821, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = cTY.TenCTY
                };
                labelTenCTy.Click += lbChiNhanh_Click;
                labelTenCTy.Tag = item;

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

                btnChiNhanh.Controls.Add(labelTenCN);
                btnChiNhanh.Controls.Add(labelTenCTy);
                btnChiNhanh.Controls.Add(labelXoa);

                flpnChiNhanh.Controls.Add(btnChiNhanh);
            }
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            int MaCN = ((sender as Label).Tag as ChiNhanh).MaCN;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chi nhánh này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (ChiNhanhDAL.Instance.XoaChiNhanh(MaCN))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachChiNhanh();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void TaiDanhSachChiNhanh()
        {
            flpnChiNhanh.Controls.Clear();

            List<ChiNhanh> danhSachChiNhanh = ChiNhanhDAL.Instance.TaiDanhSachChiNhanh();

            VongLapTaiDanhSachChiNhanh(danhSachChiNhanh);

            chiNhanhsToExcel = danhSachChiNhanh;
        }

        private void TaiDanhSachChiNhanhTheoTenCN(string TenCN)
        {
            flpnChiNhanh.Controls.Clear();

            List<ChiNhanh> danhSachChiNhanh = ChiNhanhDAL.Instance.TaiDanhSachChiNhanhTheoTen(TenCN);

            VongLapTaiDanhSachChiNhanh(danhSachChiNhanh);

            chiNhanhsToExcel = danhSachChiNhanh;
        }

        private void TaiDanhSachChiNhanhTheoCTY(int MaCTY)
        {
            flpnChiNhanh.Controls.Clear();

            List<ChiNhanh> danhSachChiNhanh = ChiNhanhDAL.Instance.TaiDanhSachChiNhanhTheoMaCTY(MaCTY);

            VongLapTaiDanhSachChiNhanh(danhSachChiNhanh);

            chiNhanhsToExcel = danhSachChiNhanh;
        }

        private void lbChiNhanh_Click(object sender, EventArgs e)
        {
            ChiNhanh chiNhanh = (sender as Label).Tag as ChiNhanh;

            fChiTietChiNhanh f = new fChiTietChiNhanh(chiNhanh);
            f.ShowDialog();

            TaiDanhSachChiNhanh();
        }

        private void btnChiNhanh_Click(object sender, EventArgs e)
        {
            ChiNhanh chiNhanh = (sender as Button).Tag as ChiNhanh;

            fChiTietChiNhanh f = new fChiTietChiNhanh(chiNhanh);
            f.ShowDialog();

            TaiDanhSachChiNhanh();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin nhóm hàng!");
            else
                TaiDanhSachChiNhanhTheoTenCN(txtTimKiem.Text);
        }


        private void btnCTY_Click(object sender, EventArgs e)
        {
            int MaCTY = ((sender as Button).Tag as CTY).MaCTY;

            TaiDanhSachChiNhanhTheoCTY(MaCTY);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemChiNhanh f = new fThemChiNhanh();
            f.ShowDialog();

            TaiDanhSachChiNhanh();
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
                            DataTable data = ChiNhanhDAL.Instance.ListToDataTable(chiNhanhsToExcel);

                            workbook.Worksheets.Add(data, "tblChiNhanh");
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

        private void btnNhapFile_Click_1(object sender, EventArgs e)
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

                    fThemChiNhanhFileExcel f = new fThemChiNhanhFileExcel(dt);
                    f.ShowDialog();
                    TaiDanhSachChiNhanh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
