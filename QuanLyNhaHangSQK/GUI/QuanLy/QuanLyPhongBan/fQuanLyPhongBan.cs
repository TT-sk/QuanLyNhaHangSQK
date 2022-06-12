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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhongBan
{
    public partial class fQuanLyPhongBan : Form
    {
        private List<Ban> bansToExcel;

        public fQuanLyPhongBan()
        {
            InitializeComponent();
        }

        private void fQuanLyPhongBan_Load(object sender, EventArgs e)
        {
            TaiDanhSachKhuVuc();
            TaiDanhSachBan();
        }

        private void TaiDanhSachKhuVuc()
        {
            flpnKhuVuc.Controls.Clear();

            List<KhuVuc> danhSachKhuVuc = KhuVucDAL.Instance.LayDanhSachKhuVuc();

            foreach (var item in danhSachKhuVuc)
            {
                Button btnKhuVuc = new Button()
                {
                    Width = 250,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 0, 192)

                };
                btnKhuVuc.Click += btnKhuVuc_Click;
                btnKhuVuc.Tag = item;
                btnKhuVuc.Text = item.TenKV;

                flpnKhuVuc.Controls.Add(btnKhuVuc);
            }
        }

        private void VongLapTaiDanhSachBan(List<Ban> danhSachBan)
        {
            foreach (var item in danhSachBan)
            {
                string tenKhuVuc = KhuVucDAL.Instance.LayTenKhuVucTheoMa(item.MaKV);

                Button btnBan = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black,

                };
                btnBan.Click += btnBan_Click;
                btnBan.Tag = item;
                btnBan.Text = "Bàn số " + item.MaBan.ToString();

                Label labelGhiChu = new Label()
                {
                    Width = 150,
                    Height = 17,
                    Location = new Point(538, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.GhiChu
                };
                labelGhiChu.Click += lbBan_Click;
                labelGhiChu.Tag = item;

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

                Label labelKhuVuc = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(821, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = tenKhuVuc
                };
                labelKhuVuc.Click += lbBan_Click;
                labelKhuVuc.Tag = item;

                btnBan.Controls.Add(labelGhiChu);
                btnBan.Controls.Add(labelKhuVuc);
                btnBan.Controls.Add(labelXoa);

                flpnBan.Controls.Add(btnBan);
            }
        }

        private void TaiDanhSachBan()
        {
            flpnBan.Controls.Clear();

            List<Ban> danhSachBan = BanDAL.Instance.TaiDanhSachBan();

            VongLapTaiDanhSachBan(danhSachBan);

            bansToExcel = danhSachBan;
        }

        public void TaiDanhSachBanTheoKhuVuc(string MaKV)
        {
            flpnBan.Controls.Clear();

            List<Ban> danhSachBan = BanDAL.Instance.TaiDanhSachBanTheoKV(MaKV);

            VongLapTaiDanhSachBan(danhSachBan);

            bansToExcel = danhSachBan;
        }

        public void TaiDanhSachBanTheoTimKiem(int MaBan)
        {
            flpnBan.Controls.Clear();

            List<Ban> danhSachBan = BanDAL.Instance.TaiDanhSachBanTheoMaBan(MaBan);

            VongLapTaiDanhSachBan(danhSachBan);

            bansToExcel = danhSachBan;
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            int MaBan = ((sender as Label).Tag as Ban).MaBan;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (BanDAL.Instance.XoaBan(MaBan))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachBan();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }
        private void btnBan_Click(object sender, EventArgs e)
        {
            int MaBan = ((sender as Button).Tag as Ban).MaBan;

            fChiTietBan f = new fChiTietBan(MaBan);
            f.ShowDialog();
            TaiDanhSachBan();
        }

        private void lbBan_Click(object sender, EventArgs e)
        {
            int MaBan = ((sender as Label).Tag as Ban).MaBan;

            fChiTietBan f = new fChiTietBan(MaBan);
            f.ShowDialog();
            TaiDanhSachBan();
        }

        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            string MaKV = ((sender as Button).Tag as KhuVuc).MaKV;

            TaiDanhSachBanTheoKhuVuc(MaKV);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập số bàn!");
            else
                TaiDanhSachBanTheoTimKiem(int.Parse(txtTimKiem.Text));

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemBan f = new fThemBan();
            f.ShowDialog();
            TaiDanhSachBan();
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
                            DataTable data = BanDAL.Instance.ListToDataTable(bansToExcel);

                            workbook.Worksheets.Add(data, "tblBan");
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

                    fThemBanFileExcel f = new fThemBanFileExcel(dt);
                    f.ShowDialog();
                    TaiDanhSachBan();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
