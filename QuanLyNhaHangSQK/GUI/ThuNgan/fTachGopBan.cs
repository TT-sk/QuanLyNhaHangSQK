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

namespace QuanLyNhaHangSQK.GUI
{
    public partial class fTachGopBan : Form
    {
        private List<DTO.Menu> menu;
        private Ban ban;
        private NguoiDung nguoiDungDangNhap;
        private int maHD;

        public List<DTO.Menu> MenuThanhToan { get => menu; set => menu = value; }
        public Ban Ban { get => ban; set => ban = value; }
        public NguoiDung NguoiDungDangNhap { get => nguoiDungDangNhap; set => nguoiDungDangNhap = value; }
        public int MaHD { get => maHD; set => maHD = value; }

        public fTachGopBan(List<DTO.Menu> menu, Ban ban, NguoiDung nguoiDung, int hoaDon)
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
            this.MenuThanhToan = menu;
            this.Ban = ban;
            this.NguoiDungDangNhap = nguoiDung;
            this.MaHD = hoaDon;
        }

        private void fTachGopBan_Load(object sender, EventArgs e)
        {
            TaiDanhSachMenuHienTai();
            TaiThongTinBanVaKhuVuc();
        }

        private void TaiThongTinBanVaKhuVuc()
        {
            string TenKV = KhuVucDAL.Instance.LayTenKhuVucTheoMa(Ban.MaKV);

            txtKhuVucBanCu.Text = TenKV;
            txtBanCu.Text = "Bàn " + Ban.MaBan.ToString();

            List<KhuVuc> khuVucs = KhuVucDAL.Instance.LayDanhSachKhuVuc();

            cbbKhuVucBanMoi.DataSource = khuVucs;
            cbbKhuVucBanMoi.DisplayMember = "TenKV";
        }

        private void TaiDanhSachMenuHienTai()
        {
            menuBindingSource.DataSource = MenuThanhToan;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_MouseLeave(object sender, EventArgs e)
        {
            btnLuu.ForeColor = Color.White;
        }

        private void btnLuu_MouseMove(object sender, MouseEventArgs e)
        {
            btnLuu.ForeColor = Color.Yellow;
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.ForeColor = Color.White;
        }

        private void btnThoat_MouseMove(object sender, MouseEventArgs e)
        {
            btnThoat.ForeColor = Color.Yellow;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dtgvMenuBanCu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvMenuBanMoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnChuyenMot_Click(object sender, EventArgs e)
        {
            for (int i = dtgvMenuHienTai.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = dtgvMenuHienTai.Rows[i];
                if (Convert.ToBoolean(row.Cells["Chuyen"].Value))
                {
                    menuBindingSource1.Add((DTO.Menu)row.DataBoundItem);
                    menuBindingSource.RemoveAt(row.Index);
                }
            }
        }

        private void btnTraLaiMot_Click(object sender, EventArgs e)
        {
            for (int i = dtgvMenuMoi.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = dtgvMenuMoi.Rows[i];
                if (Convert.ToBoolean(row.Cells["ChuyenLai"].Value))
                {
                    menuBindingSource.Add((DTO.Menu)row.DataBoundItem);
                    menuBindingSource1.RemoveAt(row.Index);
                }
            }
        }

        private void menuBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cbbKhuVucBanMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            KhuVuc khuVuc = cbb.SelectedItem as KhuVuc;

            List<Ban> bans = BanDAL.Instance.TaiDanhSachBanTheoKVVaTinhTrang(khuVuc.MaKV, 0);

            cbbBanMoi.DataSource = bans;
            cbbBanMoi.DisplayMember = "MaBan";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvMenuMoi.RowCount > 0)
                {
                    HoaDonDAL.Instance.ThemHoaDon(NguoiDungDangNhap.MaND, (cbbBanMoi.SelectedItem as Ban).MaBan);
                    for (int i = 0; i < dtgvMenuMoi.RowCount; i++)
                    {
                        ChiTietHoaDonDAL.Instance.ThemChiTietHoaDon(HoaDonDAL.Instance.LayMaHDLonNhat(), (int)dtgvMenuMoi.Rows[i].Cells["ColMaMA"].Value, (int)dtgvMenuMoi.Rows[i].Cells["ColSoLuong"].Value);
                    }
                }

                if (dtgvMenuHienTai.RowCount > 0)
                {
                    ChiTietHoaDonDAL.Instance.XoaChiTietHoaDon(MaHD);
                    for (int i = 0; i < dtgvMenuHienTai.RowCount; i++)
                    {
                        ChiTietHoaDonDAL.Instance.ThemChiTietHoaDon(MaHD, (int)dtgvMenuHienTai.Rows[i].Cells["MaMA"].Value, (int)dtgvMenuHienTai.Rows[i].Cells["SoLuong"].Value);
                    }
                }
                else
                    ChiTietHoaDonDAL.Instance.XoaChiTietHoaDon(MaHD);

                MessageBox.Show("Tách bàn thành công!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }
    }
}
