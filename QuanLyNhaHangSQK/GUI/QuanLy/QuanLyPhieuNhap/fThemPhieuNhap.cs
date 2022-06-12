using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhieuNhap
{
    public partial class fThemPhieuNhap : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private bool Hided;
        private NguoiDung nguoiDungDangNhap;

        public NguoiDung NguoiDungDangNhap
        {
            get { return nguoiDungDangNhap; }
            set { nguoiDungDangNhap = value; }
        }

        public fThemPhieuNhap(NguoiDung nguoiDung)
        {
            InitializeComponent();
            Hided = false;

            this.NguoiDungDangNhap = nguoiDung;
        }

        private void fThemPhieuNhap_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            TaiThongTinNCC();
            TaiDanhSachNhomHang();
        }

        private void TaiDanhSachNhomHang()
        {
            List<NhomHang> nhomHangs = NhomHangDAL.Instance.TaiDanhSachNhomHang();

            cbbNhomHang.DataSource = nhomHangs;
            cbbNhomHang.DisplayMember = "TenNH";
        }

        private void TaiThongTinNCC()
        {
            List<NhaCungCap> nhaCungCaps = NhaCungCapDAL.Instance.TaiDanhSachNhaCungCap();

            cbbTenNCC.DataSource = nhaCungCaps;
            cbbTenNCC.DisplayMember = "TenNCC";

            txtNgLapPhieu.Text = NguoiDungDangNhap.HoTen;
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            NhaCungCap nhaCungCap = cbb.SelectedItem as NhaCungCap;
            txtDiaChi.Text = nhaCungCap.DiaChiNCC;
            txtDienThoaiNCC.Text = nhaCungCap.DienThoaiNCC;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbGetDate.Text = DateTime.Now.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtgvNhapHang.RowCount > 0)
            {
                string MaNCC = (cbbTenNCC.SelectedItem as NhaCungCap).MaNCC;
                int MaND = NguoiDungDangNhap.MaND;
                datatimeNgayNhap.CustomFormat = "yyyy-MM-dd";

                PhieuNhapHangDAL.Instance.ThemPhieuNhap(MaNCC, MaND, datatimeNgayNhap.Text);
                for (int i = 0; i < dtgvNhapHang.RowCount; i++)
                {
                    ChiTietPhieuNhapHangDAL.Instance.ThemChiTietPhieuNhap(PhieuNhapHangDAL.Instance.LayMaPNLonNhat(), int.Parse(dtgvNhapHang.Rows[i].Cells["ColMaMA"].Value.ToString()), int.Parse(dtgvNhapHang.Rows[i].Cells["ColSoLuong"].Value.ToString()));
                }
                MessageBox.Show("Thêm thành công!");
                this.Close();
            }
            else
                MessageBox.Show("Chưa chọn hàng để nhập!");
        }

        private void btnThemMA_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Hided)
            {
                pnChonMon.Height = pnChonMon.Height - 10;
                if (pnChonMon.Height == 0)
                {
                    timer2.Stop();
                    Hided = false;
                }
            }
            else
            {
                pnChonMon.Height = pnChonMon.Height + 10;
                if (pnChonMon.Height == 420)
                {
                    timer2.Stop();
                    Hided = true;
                }

            }
        }

        private void cbbNhomHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            NhomHang nhomHang = cbb.SelectedItem as NhomHang;

            List<MonAn> monAns = MonAnDAL.Instance.TaiDanhSachMonAnTheoNhomHang(nhomHang.MaNH);

            monAnBindingSource.DataSource = monAns;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            for (int i = dtgvChonMonAn.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = dtgvChonMonAn.Rows[i];
                if (Convert.ToBoolean(row.Cells["Chon"].Value))
                {
                    monAnBindingSource1.Add((MonAn)row.DataBoundItem);
                }
            }

            decimal Tong = 0;
            foreach (DataGridViewRow row in dtgvNhapHang.Rows)
            {
                if (row.Cells["ColSoLuong"].Value == null)
                {
                    row.Cells["ColSoLuong"].Value = 1;
                }    
                row.Cells["ColThanhTien"].Value = decimal.Parse(row.Cells["ColGiaGoc"].Value.ToString()) * decimal.Parse(row.Cells["ColSoLuong"].Value.ToString());
                Tong += decimal.Parse(row.Cells["ColThanhTien"].Value.ToString());
            }

            lbTongTien.Text = Tong.ToString("c", culture);
            btnThemMA_Click(sender, e);

            foreach (DataGridViewRow row1 in dtgvNhapHang.Rows)
            {
                foreach (DataGridViewRow row2 in dtgvNhapHang.Rows)
                {
                    if (row2.Index != row1.Index)
                    {
                        if (int.Parse(row2.Cells["ColMaMA"].Value.ToString()) == int.Parse(row1.Cells["ColMaMA"].Value.ToString()))
                        {
                            row1.Cells["ColSoLuong"].Value = int.Parse(row1.Cells["ColSoLuong"].Value.ToString()) + int.Parse(row2.Cells["ColSoLuong"].Value.ToString());
                            dtgvNhapHang.Rows.RemoveAt(row2.Index);
                        }    
                    }
                }
            }    
        }

        private void dtgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvNhapHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvNhapHang_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            decimal Tong = 0;
            foreach (DataGridViewRow row in dtgvNhapHang.Rows)
            {
                row.Cells["ColThanhTien"].Value = decimal.Parse(row.Cells["ColGiaGoc"].Value.ToString()) * decimal.Parse(row.Cells["ColSoLuong"].Value.ToString());
                Tong += decimal.Parse(row.Cells["ColThanhTien"].Value.ToString());
            }

            lbTongTien.Text = Tong.ToString("c", culture);
        }

        private void dtgvNhapHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                dtgvNhapHang.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
