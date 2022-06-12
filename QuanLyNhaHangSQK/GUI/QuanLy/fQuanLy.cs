using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyBoPhan;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyCaLamViec;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyChiNhanh;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyHoaDon;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyKhachHang;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyKhuVuc;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhaCungCap;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhanVien;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhomHang;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhieuChi;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhieuNhap;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhongBan;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyQuyDinh;
using QuanLyNhaHangSQK.GUI.QuanLy.ThongTinCongTy;
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

namespace QuanLyNhaHangSQK.GUI.QuanLy
{
    public partial class fQuanLy : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private Panel bottomborderbtn;
        private Form currentchildform;
        private decimal TongDoanhThuHomNay;
        private int TongHoaDonHomNay;
        private NguoiDung nguoiDungDangNhap;

        public NguoiDung NguoiDungDangNhap
        {
            get { return nguoiDungDangNhap; }
            set { nguoiDungDangNhap = value; }
        }

        public fQuanLy(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
            this.NguoiDungDangNhap = nguoiDung;

            bottomborderbtn = new Panel();
            bottomborderbtn.Size = new Size(180, 7);
            pnDanhMuc.Controls.Add(bottomborderbtn);
        }

        private void fQuanLy_Load(object sender, EventArgs e)
        {
            KetQuaBanHangHomNay();
            TaiDoanhThuGanDay();
            TaiTongHoaDonGanDay();
            TaiTopBanChay();
            lbDateToDay.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void KetQuaBanHangHomNay()
        {
            string HomNay = DateTime.Today.ToString("yyyy-MM-dd");

            List<DoanhThuGanDay> doanhThu = DoanhThuGanDayDAL.Instance.TaiDoanhThuTheoNgay(HomNay, HomNay);
            List<TongHoaDonGanDay> hoaDon = HoaDonGanDayDAL.Instance.TaiHoaDonGanDay(HomNay, HomNay);

            foreach (DoanhThuGanDay item in doanhThu)
            {
                TongDoanhThuHomNay += item.TongDoanhThuCN;
            }

            foreach (TongHoaDonGanDay item in hoaDon)
            {
                TongHoaDonHomNay += item.SoLuong;
            }

            lbTongDoanhThuToDay.Text = TongDoanhThuHomNay.ToString("c", culture);
            lbTongHDToDay.Text = TongHoaDonHomNay.ToString();
        }

        private void TaiDoanhThuGanDay()
        {
            string HomNay = DateTime.Today.ToString("yyyy-MM-dd");

            List<DoanhThuGanDay> doanhThu = DoanhThuGanDayDAL.Instance.TaiDoanhThuTheoNgay(HomNay, HomNay);
            XoaItemBieuDoDoanhThu();
            TaiBieuDo(doanhThu);
        }

        private void TaiTongHoaDonGanDay()
        {
            string HomNay = DateTime.Today.ToString("yyyy-MM-dd");

            List<TongHoaDonGanDay> hoaDon = HoaDonGanDayDAL.Instance.TaiHoaDonGanDay(HomNay, HomNay);
            XoaItemBieuDoHoaDon();
            TaiBieuDoHoaDon(hoaDon);
        }

        private void TaiTopBanChay()
        {
            string HomNay = DateTime.Today.ToString("yyyy-MM-dd");

            List<TopBanChay> monAn = TopBanChayDAL.Instance.TaiDanhSachTopBanChay(HomNay, HomNay);
            flpnTopBanChay.Controls.Clear();
            TaiDanhSachTopBanChay(monAn);
        }

        private void DanhMucClick(object senderbtn, Color color, int locationX)
        {
            if (senderbtn != null)
            {
                //left border btn
                bottomborderbtn.BackColor = color;
                bottomborderbtn.Location = new Point(locationX, 53);
                bottomborderbtn.Visible = true;
                bottomborderbtn.BringToFront();
            }
        }

        private void MoTrangCon(Form trangCon)
        {
            if (currentchildform != null)
            {
                currentchildform.Close();

            }
            currentchildform = trangCon;
            trangCon.TopLevel = false;
            trangCon.FormBorderStyle = FormBorderStyle.None;
            trangCon.Dock = DockStyle.Fill;
            pnChinh.Controls.Add(trangCon);
            pnChinh.Tag = trangCon;
            trangCon.BringToFront();
            trangCon.Show();
            trangCon.Text = trangCon.Text;
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 0);
            if (currentchildform != null)
            {
                currentchildform.Close();

            }

        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 180);
            MoTrangCon(new fQuanLyMonAn());
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 360);
            MoTrangCon(new fQuanLyPhongBan());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 540);
            MoTrangCon(new fQuanLyNhanVien());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 720);
            MoTrangCon(new fQuanLyHoaDon());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 1316);
            MoTrangCon(new fBaoCaoThongKe());
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fQuanLyPhieuNhap(NguoiDungDangNhap));
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fQuanLyKhachHang());
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fQuanLyNhaCungCap());
        }

        private void btnPhieuChi_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fQuanLyPhieuChi(NguoiDungDangNhap));
        }

        private void btnBoPhan_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fQuanLyBoPhan());
        }

        private void btnCaLamViec_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fQuanLyCaLamViec());
        }

        private void btnNhomHang_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fQuanLyNhomHang());
        }

        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fQuanLyKhuVuc());
        }

        private void btnChiNhanh_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fQuanLyChiNhanh());
        }

        private void btnCongTy_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fThongTinCongTy());
        }

        private void btnQuyDinh_Click(object sender, EventArgs e)
        {
            MoTrangCon(new fQuanLyQuyDinh());
        }
        private void ptExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbbDoanhSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string HomNay = DateTime.Today.ToString("yyyy-MM-dd");
            string HomQua = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            string Tuan = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");
            string Thang = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");


            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            if (cbb.SelectedIndex == 0)
            {
                List<DoanhThuGanDay> doanhThu = DoanhThuGanDayDAL.Instance.TaiDoanhThuTheoNgay(HomNay, HomNay);
                XoaItemBieuDoDoanhThu();
                TaiBieuDo(doanhThu);
            }    
            else if (cbb.SelectedIndex == 1)
            {
                List<DoanhThuGanDay> doanhThu = DoanhThuGanDayDAL.Instance.TaiDoanhThuTheoNgay(HomQua, HomQua);
                XoaItemBieuDoDoanhThu();
                TaiBieuDo(doanhThu);
            }
            else if (cbb.SelectedIndex == 2)
            {
                List<DoanhThuGanDay> doanhThu = DoanhThuGanDayDAL.Instance.TaiDoanhThuTheoNgay(Tuan, HomNay);
                XoaItemBieuDoDoanhThu();
                TaiBieuDo(doanhThu);
            }
            else if (cbb.SelectedIndex == 3)
            {
                List<DoanhThuGanDay> doanhThu = DoanhThuGanDayDAL.Instance.TaiDoanhThuTheoNgay(Thang, HomNay);
                XoaItemBieuDoDoanhThu();
                TaiBieuDo(doanhThu);
            }
        }

        private void cbbHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string HomNay = DateTime.Today.ToString("yyyy-MM-dd");
            string HomQua = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            string Tuan = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");
            string Thang = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");


            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            if (cbb.SelectedIndex == 0)
            {
                List<TongHoaDonGanDay> hoaDon = HoaDonGanDayDAL.Instance.TaiHoaDonGanDay(HomNay, HomNay);
                XoaItemBieuDoHoaDon();
                TaiBieuDoHoaDon(hoaDon);
            }
            else if (cbb.SelectedIndex == 1)
            {
                List<TongHoaDonGanDay> hoaDon = HoaDonGanDayDAL.Instance.TaiHoaDonGanDay(HomQua, HomQua);
                XoaItemBieuDoHoaDon();
                TaiBieuDoHoaDon(hoaDon);
            }
            else if (cbb.SelectedIndex == 2)
            {
                List<TongHoaDonGanDay> hoaDon = HoaDonGanDayDAL.Instance.TaiHoaDonGanDay(Tuan, HomNay);
                XoaItemBieuDoHoaDon();
                TaiBieuDoHoaDon(hoaDon);
            }
            else if (cbb.SelectedIndex == 3)
            {
                List<TongHoaDonGanDay> hoaDon = HoaDonGanDayDAL.Instance.TaiHoaDonGanDay(Thang, HomNay);
                XoaItemBieuDoHoaDon();
                TaiBieuDoHoaDon(hoaDon);
            }
        }

        private void cbbTopBanChay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string HomNay = DateTime.Today.ToString("yyyy-MM-dd");
            string HomQua = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            string Tuan = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");
            string Thang = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");


            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            if (cbb.SelectedIndex == 0)
            {
                List<TopBanChay> monAn = TopBanChayDAL.Instance.TaiDanhSachTopBanChay(HomNay, HomNay);
                flpnTopBanChay.Controls.Clear();
                TaiDanhSachTopBanChay(monAn);
            }
            else if (cbb.SelectedIndex == 1)
            {
                List<TopBanChay> monAn = TopBanChayDAL.Instance.TaiDanhSachTopBanChay(HomQua, HomQua);
                flpnTopBanChay.Controls.Clear();
                TaiDanhSachTopBanChay(monAn);
            }
            else if (cbb.SelectedIndex == 2)
            {
                List<TopBanChay> monAn = TopBanChayDAL.Instance.TaiDanhSachTopBanChay(Tuan, HomNay);
                flpnTopBanChay.Controls.Clear();
                TaiDanhSachTopBanChay(monAn);
            }
            else if (cbb.SelectedIndex == 3)
            {
                List<TopBanChay> monAn = TopBanChayDAL.Instance.TaiDanhSachTopBanChay(Thang, HomNay);
                flpnTopBanChay.Controls.Clear();
                TaiDanhSachTopBanChay(monAn);
            }
        }

        private void TaiBieuDo(List<DoanhThuGanDay> doanhThu)
        {
            foreach (DoanhThuGanDay item in doanhThu)
            {
                cTongDoanhThu.Series["Chi nhánh"].Points.AddXY(item.TenCN, item.TongDoanhThuCN);
            }
        }

        private void TaiBieuDoHoaDon(List<TongHoaDonGanDay> hoaDon)
        {
            foreach (TongHoaDonGanDay item in hoaDon)
            {
                cHoaDon.Series["Chi nhánh"].Points.AddXY(item.TenCN, item.SoLuong);
            }
        }

        private void TaiDanhSachTopBanChay(List<TopBanChay> topBanChays)
        {
            int stt = 1;
            foreach (TopBanChay item in topBanChays)
            {
                Button btnMonAn = new Button()
                {
                    Width = 310,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnMonAn.Text = stt + "..." + item.TenMA;

                Label lbSoLuong = new Label()
                {
                    Width = 40,
                    Height = 20,
                    Location = new Point(268, 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Text = item.SoLuong.ToString()
                };

                btnMonAn.Controls.Add(lbSoLuong);
                stt++;

                flpnTopBanChay.Controls.Add(btnMonAn);
            }
        }

        private void XoaItemBieuDoDoanhThu()
        {
            foreach (var series in cTongDoanhThu.Series)
            {
                series.Points.Clear();
            }
        }

        private void XoaItemBieuDoHoaDon()
        {
            foreach (var series in cHoaDon.Series)
            {
                series.Points.Clear();
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }
    }
}
