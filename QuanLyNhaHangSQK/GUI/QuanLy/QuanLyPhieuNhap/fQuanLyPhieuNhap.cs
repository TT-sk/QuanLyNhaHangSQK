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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhieuNhap
{
    public partial class fQuanLyPhieuNhap : Form
    {
        private List<PhieuNhapHang> phieuNhapHangsToExcel;
        private NguoiDung nguoiDungDangNhap;

        public NguoiDung NguoiDungDangNhap
        {
            get { return nguoiDungDangNhap; }
            set { nguoiDungDangNhap = value; }
        }

        public fQuanLyPhieuNhap(NguoiDung nguoiDung)
        {
            InitializeComponent();

            this.NguoiDungDangNhap = nguoiDung;
        }

        private void fQuanLyPhieuNhap_Load(object sender, EventArgs e)
        {
            TaiDanhSachNhaCungCap();
            TaiDanhSachPhieuNhap();
        }

        private void TaiDanhSachNhaCungCap()
        {
            flpnNCC.Controls.Clear();

            List<NhaCungCap> danhSachNCC = NhaCungCapDAL.Instance.TaiDanhSachNhaCungCap();

            foreach (var item in danhSachNCC)
            {
                Button btnNCC = new Button()
                {
                    Width = 250,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 0, 192)
                };
                btnNCC.Click += btnNCC_Click;
                btnNCC.Tag = item;

                btnNCC.Text = item.TenNCC;


                flpnNCC.Controls.Add(btnNCC);
            }
        }

        private void VongLapTaiDanhSachPN(List<PhieuNhapHang> danhSachPhieuNhap)
        {
            foreach (PhieuNhapHang item in danhSachPhieuNhap)
            {
                NhaCungCap nhaCungCap = NhaCungCapDAL.Instance.TaiNhaCungCapTheoMa(item.MaNCC);

                Button btnPhieuNhap = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };
                btnPhieuNhap.Click += btnPhieuNhap_Click;
                btnPhieuNhap.Tag = item;

                btnPhieuNhap.Text = item.MaPN.ToString();

                Label labelNCC = new Label()
                {
                    Width = 200,
                    Height = 17,
                    Location = new Point(238, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = nhaCungCap.TenNCC
                };
                labelNCC.Click += lbPhieuNhap_Click;
                labelNCC.Tag = item;

                Label labelTGTT = new Label()
                {
                    Width = 200,
                    Height = 17,
                    Location = new Point(538, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = String.Format("{0:dd/MM/yyyy}", item.NgayLap)
                };
                labelTGTT.Click += lbPhieuNhap_Click;
                labelTGTT.Tag = item;

                Label labelTinhTrang = new Label()
                {
                    Width = 150,
                    Height = 17,
                    Location = new Point(821, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = String.Format("{0:dd/MM/yyyy}", item.NgayNhapHang)
                };
                labelTinhTrang.Click += lbPhieuNhap_Click;
                labelTinhTrang.Tag = item;

                btnPhieuNhap.Controls.Add(labelNCC);
                btnPhieuNhap.Controls.Add(labelTGTT);
                btnPhieuNhap.Controls.Add(labelTinhTrang);

                flpnPhieuNhap.Controls.Add(btnPhieuNhap);
            }
        }

        private void TaiDanhSachPhieuNhap()
        {
            flpnPhieuNhap.Controls.Clear();

            List<PhieuNhapHang> danhSachPhieuNhap = PhieuNhapHangDAL.Instance.TaiDanhSachPhieuNhap();

            VongLapTaiDanhSachPN(danhSachPhieuNhap);

            phieuNhapHangsToExcel = danhSachPhieuNhap;
        }

        private void TaiDanhSachPhieuNhapTheoMaPN(int MaPN)
        {
            flpnPhieuNhap.Controls.Clear();

            List<PhieuNhapHang> danhSachPhieuNhap = PhieuNhapHangDAL.Instance.TaiDanhSachPhieuNhapTheoMa(MaPN);

            VongLapTaiDanhSachPN(danhSachPhieuNhap);

            phieuNhapHangsToExcel = danhSachPhieuNhap;
        }

        private void TaiDanhSachPhieuNhapTheoNCC(string MaNCC)
        {
            flpnPhieuNhap.Controls.Clear();

            List<PhieuNhapHang> danhSachPhieuNhap = PhieuNhapHangDAL.Instance.TaiDanhSachPhieuNhapTheoNCC(MaNCC);

            VongLapTaiDanhSachPN(danhSachPhieuNhap);

            phieuNhapHangsToExcel = danhSachPhieuNhap;
        }

        private void TaiDanhSachPhieuNhapTheoNgayLap(string NgayBD, string NgayKT)
        {
            flpnPhieuNhap.Controls.Clear();

            List<PhieuNhapHang> danhSachPhieuNhap = PhieuNhapHangDAL.Instance.TaiDanhSachPhieuNhapTheoNgayLap(NgayBD, NgayKT);

            VongLapTaiDanhSachPN(danhSachPhieuNhap);

            phieuNhapHangsToExcel = danhSachPhieuNhap;
        }

        private void TaiDanhSachPhieuNhapTheoNgayNhap(string NgayBD, string NgayKT)
        {
            flpnPhieuNhap.Controls.Clear();

            List<PhieuNhapHang> danhSachPhieuNhap = PhieuNhapHangDAL.Instance.TaiDanhSachPhieuNhapTheoNgayNhap(NgayBD, NgayKT);

            VongLapTaiDanhSachPN(danhSachPhieuNhap);

            phieuNhapHangsToExcel = danhSachPhieuNhap;
        }



        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            PhieuNhapHang phieuNhap = (sender as Button).Tag as PhieuNhapHang;

            fChiTietPhieuNhap f = new fChiTietPhieuNhap(phieuNhap);
            f.ShowDialog();
        }

        private void lbPhieuNhap_Click(object sender, EventArgs e)
        {
            PhieuNhapHang phieuNhap = (sender as Label).Tag as PhieuNhapHang;

            fChiTietPhieuNhap f = new fChiTietPhieuNhap(phieuNhap);
            f.ShowDialog();
        }

        private void btnNCC_Click(object sender, EventArgs eventArgs)
        {
            string MaNCC = ((sender as Button).Tag as NhaCungCap).MaNCC;

            TaiDanhSachPhieuNhapTheoNCC(MaNCC);
        }

        private void labelXoaNCC_Click(object sender, EventArgs eventArgs)
        {
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaPN = int.Parse(txtTimKiem.Text.Trim());

                TaiDanhSachPhieuNhapTheoMaPN(MaPN);
            }
            catch
            {
                MessageBox.Show("Mã phiếu nhập là 1 dãy số.");
                txtTimKiem.Focus();
            }
        }

        private void datetimeBatDauLap_ValueChanged(object sender, EventArgs e)
        {
            datetimeBatDauLap.CustomFormat = "yyyy-MM-dd";
            datetiemKetThucLap.CustomFormat = "yyyy-MM-dd";
            TaiDanhSachPhieuNhapTheoNgayLap(datetimeBatDauLap.Text, datetiemKetThucLap.Text);
        }

        private void datetimeBatDauNhap_ValueChanged(object sender, EventArgs e)
        {
            datetimeBatDauNhap.CustomFormat = "yyyy-MM-dd";
            datetimeKetThucNhap.CustomFormat = "yyyy-MM-dd";
            TaiDanhSachPhieuNhapTheoNgayNhap(datetimeBatDauNhap.Text, datetimeKetThucNhap.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemPhieuNhap f = new fThemPhieuNhap(NguoiDungDangNhap);
            f.ShowDialog();
            TaiDanhSachPhieuNhap();
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
                            DataTable data = PhieuNhapHangDAL.Instance.ListToDataTable(phieuNhapHangsToExcel);

                            workbook.Worksheets.Add(data, "tblPhieuNhapHang");
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
