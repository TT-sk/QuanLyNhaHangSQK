using ClosedXML.Excel;
using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhongBan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyKhuVuc
{
    public partial class fQuanLyKhuVuc : Form
    {
        List<KhuVuc> khuVucsToExcel;

        public fQuanLyKhuVuc()
        {
            InitializeComponent();
        }

        private void fQuanLyKhuVuc_Load(object sender, EventArgs e)
        {
            TaiDanhSachKhuVuc();
        }


        private void VongLapTaiDanhSachKhuVuc(List<KhuVuc> KhuVucs)
        {
            foreach (var item in KhuVucs)
            {
                Button btnKhuVuc = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnKhuVuc.Text = item.MaKV;
                btnKhuVuc.Click += btnKhuVuc_Click;
                btnKhuVuc.Tag = item;

                Label labelTenKV = new Label()
                {
                    Width = 300,
                    Height = 17,
                    Location = new Point(335, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.TenKV
                };
                labelTenKV.Click += labelKhuVuc_Click;
                labelTenKV.Tag = item;

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

                btnKhuVuc.Controls.Add(labelTenKV);
                btnKhuVuc.Controls.Add(labelXoa);


                flpnKV.Controls.Add(btnKhuVuc);
            }
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            string MaKV = ((sender as Label).Tag as KhuVuc).MaKV;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khu vực này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (KhuVucDAL.Instance.XoaKhuVuc(MaKV))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachKhuVuc();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void TaiDanhSachKhuVuc()
        {
            flpnKV.Controls.Clear();

            List<KhuVuc> KhuVucs = KhuVucDAL.Instance.LayDanhSachKhuVuc();

            VongLapTaiDanhSachKhuVuc(KhuVucs);

            khuVucsToExcel = KhuVucs;
        }

        private void TaiDanhSachKhuVucTheoTen(string TenKV)
        {
            flpnKV.Controls.Clear();

            List<KhuVuc> KhuVucs = KhuVucDAL.Instance.LayDanhSachKhuVucTheoTen(TenKV);

            VongLapTaiDanhSachKhuVuc(KhuVucs);

            khuVucsToExcel = KhuVucs;
        }

        private void labelKhuVuc_Click(object sender, EventArgs e)
        {
            KhuVuc khuVuc = (sender as Label).Tag as KhuVuc;

            fChiTietKhuVuc f = new fChiTietKhuVuc(khuVuc);
            f.ShowDialog();

            TaiDanhSachKhuVuc();
        }

        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            KhuVuc khuVuc = (sender as Button).Tag as KhuVuc;

            fChiTietKhuVuc f = new fChiTietKhuVuc(khuVuc);
            f.ShowDialog();

            TaiDanhSachKhuVuc();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin khu vực!");
            else
                TaiDanhSachKhuVucTheoTen(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemKhuVuc f = new fThemKhuVuc();
            f.ShowDialog();

            TaiDanhSachKhuVuc();
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
                            DataTable data = KhuVucDAL.Instance.ListToDataTable(khuVucsToExcel);

                            workbook.Worksheets.Add(data, "tblKhuVuc");
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

                    fThemKhuVucFileExcel f = new fThemKhuVucFileExcel(dt);
                    f.ShowDialog();
                    TaiDanhSachKhuVuc();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
