using ClosedXML.Excel;
using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhieuNhap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhaCungCap
{
    public partial class fQuanLyNhaCungCap : Form
    {
        private List<NhaCungCap> nhaCungCapsToExcel;

        public fQuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void fQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            TaiDanhSachNhaCungCap();
        }

        private void VongLapTaiDanhSachNCC(List<NhaCungCap> nhaCungCaps)
        {
            foreach (var item in nhaCungCaps)
            {
                Button btnNCC = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnNCC.Text = item.MaNCC;
                btnNCC.Click += btnNCC_Click;
                btnNCC.Tag = item;

                Label labelTenNCC = new Label()
                {
                    Width = 300,
                    Height = 17,
                    Location = new Point(335, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.TenNCC
                };
                labelTenNCC.Click += labelNCC_Click;
                labelTenNCC.Tag = item;

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

                btnNCC.Controls.Add(labelTenNCC);
                btnNCC.Controls.Add(labelXoa);

                flpnNCC.Controls.Add(btnNCC);
            }
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            string MaNCC = ((sender as Label).Tag as NhaCungCap).MaNCC;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ca làm việc này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (NhaCungCapDAL.Instance.XoaNhaCungCap(MaNCC))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachNhaCungCap();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void TaiDanhSachNhaCungCap()
        {
            flpnNCC.Controls.Clear();

            List<NhaCungCap> danhSachNCC = NhaCungCapDAL.Instance.TaiDanhSachNhaCungCap();

            VongLapTaiDanhSachNCC(danhSachNCC);

            nhaCungCapsToExcel = danhSachNCC;
        }

        private void TaiDanhSachNhaCungCapTheoTimKiem(string TenNCC)
        {
            flpnNCC.Controls.Clear();

            List<NhaCungCap> danhSachNCC = NhaCungCapDAL.Instance.TaiNhaCungCapTheoTimKiem(TenNCC);

            VongLapTaiDanhSachNCC(danhSachNCC);

            nhaCungCapsToExcel = danhSachNCC;
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            string MaNCC = ((sender as Button).Tag as NhaCungCap).MaNCC;

            fChiTietNCC f = new fChiTietNCC(MaNCC);
            f.ShowDialog();

            TaiDanhSachNhaCungCap();
        }

        private void labelNCC_Click(object sender, EventArgs e)
        {
            string MaNCC = ((sender as Label).Tag as NhaCungCap).MaNCC;

            fChiTietNCC f = new fChiTietNCC(MaNCC);
            f.ShowDialog();

            TaiDanhSachNhaCungCap();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin nhà cung cấp!");
            else
                TaiDanhSachNhaCungCapTheoTimKiem(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemNCC f = new fThemNCC();
            f.ShowDialog();
            TaiDanhSachNhaCungCap();
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
                            DataTable data = NhaCungCapDAL.Instance.ListToDataTable(nhaCungCapsToExcel);

                            workbook.Worksheets.Add(data, "tblNhaCungCap");
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

                    fThemNhaCungCapFileExcel f = new fThemNhaCungCapFileExcel(dt);
                    f.ShowDialog();
                    TaiDanhSachNhaCungCap();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
