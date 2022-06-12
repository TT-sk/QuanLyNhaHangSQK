using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI;
using QuanLyNhaHangSQK.GUI.ThuNgan;
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

namespace QuanLyNhaHangSQK
{
    public partial class fThuNgan : Form
    {
        private bool Hided;

        CultureInfo culture = new CultureInfo("es-US");

        private NguoiDung nguoiDungDangNhap;
        
        public NguoiDung NguoiDungDangNhap
        {
            get { return nguoiDungDangNhap; }
            set { nguoiDungDangNhap = value; }
        }

        public fThuNgan(NguoiDung nguoiDung)
        {
            InitializeComponent();
            Hided = false;
            this.Opacity = 0;
            timer2.Start();
            this.NguoiDungDangNhap = nguoiDung;
        }

        private void fThuNgan_Load(object sender, EventArgs e)
        {
            TaiDanhSachKhuVuc();
            TaiDanhSachNhomHang();
        }

        public void TaiDanhSachKhuVuc()
        {
            List<KhuVuc> khuVucs = KhuVucDAL.Instance.LayDanhSachKhuVuc();

            cbbKhuVuc.DataSource = khuVucs;
            cbbKhuVuc.DisplayMember = "TenKV";
        }

        public void TaiDanhSachBan(List<Ban> danhSachBan)
        {
            foreach (Ban item in danhSachBan)
            {
                Button btnBan = new Button()
                {
                    Width = 110,
                    Height = 90,
                    TextAlign = ContentAlignment.BottomCenter,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };
                btnBan.Text = "Bàn " + item.MaBan;
                btnBan.Click += btnBan_Click;
                btnBan.Tag = item;

                switch (item.TinhTrang)
                {
                    case true:
                        btnBan.Image = Image.FromFile(@"C:\Users\thien\Downloads\res\quanlynhahang\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\BanCoNgSizeM.png");
                        break;
                    case false:
                        btnBan.Image = Image.FromFile(@"C:\Users\thien\Downloads\res\quanlynhahang\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\BanTrongSizeM.png");
                        break;
                }

                flpnBan.Controls.Add(btnBan);
            }
        }

        public void TaiHoaDonTheoBan(int MaBan)
        {
            decimal TongHoaDon = 0;

            List<DTO.Menu> danhSachChiTietHoaDon = MenuDAL.Instance.LayDanhSachMenuTheoBan(MaBan);

            foreach (DTO.Menu item in danhSachChiTietHoaDon)
            {
                Button btnMonAn = new Button()
                {
                    Width = 550,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                btnMonAn.Font = new Font("Arial", 10, FontStyle.Bold);
                btnMonAn.Text = item.TenMA;
                btnMonAn.Click += btnMonAnHD_Click;
                btnMonAn.Tag = item;

                Label labelSoLuong = new Label()
                {
                    Width = 50,
                    Height = 17 ,
                    Location = new Point(160, 12),
                    TextAlign = ContentAlignment.MiddleRight,
                    Text = item.SoLuong.ToString()
                };
                labelSoLuong.Click += lbMonAnHD_Click;
                labelSoLuong.Tag = item;

                Label labelGiaTien = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(210, 12),
                    TextAlign = ContentAlignment.MiddleRight,
                    Text = item.GiaTien.ToString("c", culture)
                };
                labelGiaTien.Click += lbMonAnHD_Click;
                labelGiaTien.Tag = item;

                Label labelTongTien = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(350, 12),
                    TextAlign = ContentAlignment.MiddleRight,
                    Text = item.TongTien.ToString("c", culture)
                };
                labelTongTien.Click += lbMonAnHD_Click;
                TongHoaDon += item.TongTien;
                labelGiaTien.Tag = item;

                Label labelXoa = new Label()
                {
                    Width = 20,
                    Height = 20,
                    Location = new Point(490, 10),
                    BackColor = Color.Transparent,
                    Image = Image.FromFile(@"C:\Users\thien\Downloads\res\quanlynhahang\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\DelMA.png")
                };
                labelXoa.MouseUp += labelXoa_MouseUp;
                labelXoa.Tag = item;

                Label labelHienTrang = new Label()
                {
                    Width = 20,
                    Height = 20,
                    Location = new Point(520, 10),
                    BackColor = Color.Transparent
                };
                labelHienTrang.Click += lbMonAnHD_Click;
                labelHienTrang.Tag = item;

                switch (item.HienTrang)
                {
                    case 0:
                        labelHienTrang.Image = Image.FromFile(@"C:\Users\thien\Downloads\res\quanlynhahang\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\ChuaNau.png");
                        break;
                    case 1:
                        labelHienTrang.Image = Image.FromFile(@"D:\Study_Space\CongNghePhanMem\DoAn\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\DangNau.png");
                        break;
                    case 2:
                        labelHienTrang.Image = Image.FromFile(@"C:\Users\thien\Downloads\res\quanlynhahang\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\DaNau.png");
                        break;
                }
                
                lbMaHoaDon.Text = item.MaHD.ToString();
                
                btnMonAn.Controls.Add(labelSoLuong);
                btnMonAn.Controls.Add(labelGiaTien);
                btnMonAn.Controls.Add(labelTongTien);
                btnMonAn.Controls.Add(labelXoa);
                btnMonAn.Controls.Add(labelHienTrang);

                flpnHoaDon.Controls.Add(btnMonAn);
            }

            Label labelHuyHoaDon = new Label()
            {
                Width = 20,
                Height = 18,
                Location = new Point(556, 7),
                BackColor = Color.Transparent,
                Image = Image.FromFile(@"C:\Users\thien\Downloads\res\quanlynhahang\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\HuyHoaDon.png")
            };
            labelHuyHoaDon.Click += labelHuyHoaDon_Click;

            pnCotHoaDon.Controls.Add(labelHuyHoaDon);
            lbTongHoaDon.Text = TongHoaDon.ToString("c", culture);
        }

        public void TaiDanhSachNhomHang()
        {
            flpnDanhMucMonAn.Controls.Clear();

            List<NhomHang> danhSachNhomHang = NhomHangDAL.Instance.TaiDanhSachNhomHang();
            
            foreach(var item in danhSachNhomHang)
            {
                Button btnDanhMucNhomHang = new Button()
                {
                    Width = 200,
                    Height = 35,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                };
                btnDanhMucNhomHang.Text = item.TenNH;

                btnDanhMucNhomHang.Click += btnDanhMucNhomHang_Click;
                btnDanhMucNhomHang.Tag = item;

                flpnDanhMucMonAn.Controls.Add(btnDanhMucNhomHang);
            }
        }

        public void TaiDanhSachMonAnTheoNhomHang(int MaNH)
        {
            flpnMonAn.Controls.Clear();

            List<MonAn> danhSachMonAn = MonAnDAL.Instance.TaiDanhSachMonAnTheoNhomHang(MaNH);

            foreach (MonAn item in danhSachMonAn)
            {
                uctrItemMonAn btnMonAn = new uctrItemMonAn();
                btnMonAn.TieuDeMA = item.TenMA + "\n" + item.GiaTien.ToString("c", culture);
                try
                {
                    byte[] anhMA = MonAnDAL.Instance.TaiAnhLen(item.MaMA);

                    btnMonAn.AnhMA = XuLyAnh.Instance.ByteArrayToImage(anhMA);
                }
                catch { }
                
                btnMonAn.ButtonClick += btnMonAn_Click;

                btnMonAn.Tag = item;

                flpnMonAn.Controls.Add(btnMonAn);
            }
        }

        public void TaiDanhSachMonAnTheoTimKiem(string TenMA)
        {
            flpnMonAn.Controls.Clear();

            List<MonAn> danhSachMonAn = MonAnDAL.Instance.TimKiemMonAnTheoTenMA(TenMA);

            foreach (MonAn item in danhSachMonAn)
            {
                uctrItemMonAn btnMonAn = new uctrItemMonAn();
                btnMonAn.TieuDeMA = item.TenMA + "\n" + item.GiaTien.ToString("c", culture);
                try
                {
                    byte[] anhMA = MonAnDAL.Instance.TaiAnhLen(item.MaMA);

                    btnMonAn.AnhMA = XuLyAnh.Instance.ByteArrayToImage(anhMA);
                }
                catch { }
                btnMonAn.ButtonClick += btnMonAn_Click;

                btnMonAn.Tag = item;

                flpnMonAn.Controls.Add(btnMonAn);
            }
        }

        public void TaiDanhSachMonAnTheoMaMA(int MaMA)
        {
            flpnMonAn.Controls.Clear();

            List<MonAn> danhSachMonAn = MonAnDAL.Instance.TaiDanhSachMonAnTheoMaMA(MaMA);

            foreach (MonAn item in danhSachMonAn)
            {
                uctrItemMonAn btnMonAn = new uctrItemMonAn();
                btnMonAn.TieuDeMA = item.TenMA + "\n" + item.GiaTien.ToString("c", culture);
                try
                {
                    byte[] anhMA = MonAnDAL.Instance.TaiAnhLen(item.MaMA);

                    btnMonAn.AnhMA = XuLyAnh.Instance.ByteArrayToImage(anhMA);
                }
                catch { }
                btnMonAn.ButtonClick += btnMonAn_Click;

                btnMonAn.Tag = item;

                flpnMonAn.Controls.Add(btnMonAn);
            }
        }

        private void btnBan_Click(object sender, EventArgs eventArgs)
        {
            flpnHoaDon.Controls.Clear();

            int maBan = ((sender as Button).Tag as Ban).MaBan;
            lbBanThanhToan.Text = maBan.ToString();
            flpnHoaDon.Tag = (sender as Button).Tag;
            TaiHoaDonTheoBan(maBan);
        }

        private void cbbKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpnBan.Controls.Clear();

            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            KhuVuc khuVuc = cbb.SelectedItem as KhuVuc;
            List<Ban> danhSachBan = BanDAL.Instance.TaiDanhSachBanTheoKV(khuVuc.MaKV);
            TaiDanhSachBan(danhSachBan);
        }

        private void btnTatCaBan_Click(object sender, EventArgs e)
        {
            flpnBan.Controls.Clear();

            List<Ban> danhSachBan = BanDAL.Instance.TaiDanhSachBan();
            TaiDanhSachBan(danhSachBan);
        }

        private void btnBanTrong_Click(object sender, EventArgs e)
        {
            flpnBan.Controls.Clear();

            List<Ban> danhSachBan = BanDAL.Instance.TaiDanhSachBanTheoTinhTrang(0);
            TaiDanhSachBan(danhSachBan);
        }

        private void btnBanCoNguoi_Click(object sender, EventArgs e)
        {
            flpnBan.Controls.Clear();

            List<Ban> danhSachBan = BanDAL.Instance.TaiDanhSachBanTheoTinhTrang(1);
            TaiDanhSachBan(danhSachBan);
        }

        private void btnDanhMucNhomHang_Click(object sender, EventArgs eventArgs)
        {
            int maNH = ((sender as Button).Tag as NhomHang).MaNH;
            TaiDanhSachMonAnTheoNhomHang(maNH);
        }

        private void btnMonAn_Click(object sender, EventArgs eventArgs)
        {
            flpnHoaDon.Controls.Clear();

            Ban ban = flpnHoaDon.Tag as Ban;

            if (ban != null)
            {
                int MaHD = HoaDonDAL.Instance.LayMaHDTheoBan(ban.MaBan);
                int MaMA = ((sender as uctrItemMonAn).Tag as MonAn).MaMA;
                int SoLuong = 1;

                if (MaHD == -1)
                {
                    HoaDonDAL.Instance.ThemHoaDon(NguoiDungDangNhap.MaND, ban.MaBan);
                    ChiTietHoaDonDAL.Instance.ThemChiTietHoaDon(HoaDonDAL.Instance.LayMaHDLonNhat(), MaMA, SoLuong);
                }
                else
                {
                    ChiTietHoaDonDAL.Instance.ThemChiTietHoaDon(MaHD, MaMA, SoLuong);
                }
                TaiHoaDonTheoBan(ban.MaBan);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn!");
            }
            fThuNgan_Load(sender, eventArgs);
        }

        private void btnMonAnHD_Click(object sender, EventArgs eventArgs)
        {
            int MaMA = ((sender as Button).Tag as DTO.Menu).MaMA;

            TaiDanhSachMonAnTheoMaMA(MaMA);
        }

        private void lbMonAnHD_Click(object sender, EventArgs eventArgs)
        {
            int MaMA = ((sender as Label).Tag as DTO.Menu).MaMA;

            TaiDanhSachMonAnTheoMaMA(MaMA);
        }

        private void labelXoa_MouseUp(object sender, MouseEventArgs e)
        {
            flpnHoaDon.Controls.Clear();

            Ban ban = flpnHoaDon.Tag as Ban;
            int MaHD = HoaDonDAL.Instance.LayMaHDTheoBan(ban.MaBan);
            int MaMA = ((sender as Label).Tag as DTO.Menu).MaMA;
            int SoLuong = ((sender as Label).Tag as DTO.Menu).SoLuong;

            if (e.Button == MouseButtons.Left)
            {
                ChiTietHoaDonDAL.Instance.XoaMonAnChiTietHoaDon(MaHD, MaMA, SoLuong);
            }
            else if (e.Button == MouseButtons.Right)
            {
                ChiTietHoaDonDAL.Instance.XoaMonAnChiTietHoaDon(MaHD, MaMA, 0);
            }
            
            TaiHoaDonTheoBan(ban.MaBan);
        }

        private void labelHuyHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int Dem = 0;
            Ban ban = flpnHoaDon.Tag as Ban;
            if (ban != null)
            {
                List<DTO.Menu> menu = MenuDAL.Instance.LayDanhSachMenuTheoBan(ban.MaBan);

                foreach (DTO.Menu item in menu)
                {
                    if (item.HienTrang == 0 || item.HienTrang == 1)
                    {
                        Dem++;
                    }
                }

                if (flpnHoaDon.Controls.Count > 0 && Dem == 0)
                {
                    fThanhToan f = new fThanhToan(menu, ban, NguoiDungDangNhap);
                    f.ShowDialog();
                    fThuNgan_Load(sender, e);
                }
                else if (Dem > 0)
                    MessageBox.Show("Chưa thể thanh toán do món ăn chưa lên hết!");
                else
                    MessageBox.Show("Chưa có hóa đơn để thanh toán!");

            }
            else
                MessageBox.Show("Chưa có hóa đơn để thanh toán!");

        }

        private void btnThongBao_MouseLeave(object sender, EventArgs e)
        {
            btnThongBao.ForeColor = Color.Black;
        }

        private void btnThongBao_MouseMove(object sender, MouseEventArgs e)
        {
            btnThongBao.ForeColor = Color.Yellow;
        }

        private void btnThanhToan_MouseLeave(object sender, EventArgs e)
        {
            btnThanhToan.ForeColor = Color.Black;
        }

        private void btnThanhToan_MouseMove(object sender, MouseEventArgs e)
        {
            btnThanhToan.ForeColor = Color.Yellow;
        }

        private void btnTatCaBan_MouseLeave(object sender, EventArgs e)
        {
            btnTatCaBan.ForeColor = Color.Black;
        }

        private void btnTatCaBan_MouseMove(object sender, MouseEventArgs e)
        {
            btnTatCaBan.ForeColor = Color.Yellow;
        }

        private void btnBanTrong_MouseLeave(object sender, EventArgs e)
        {
            btnBanTrong.ForeColor = Color.Black;
        }

        private void btnBanTrong_MouseMove(object sender, MouseEventArgs e)
        {
            btnBanTrong.ForeColor = Color.Yellow;
        }

        private void btnBanCoNguoi_MouseLeave(object sender, EventArgs e)
        {
            btnBanCoNguoi.ForeColor = Color.Black;
        }

        private void btnBanCoNguoi_MouseMove(object sender, MouseEventArgs e)
        {
            btnBanCoNguoi.ForeColor = Color.Yellow;
        }

        private void ptExit_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.close();
            this.Close();
        }

        private void btnChuyenGopBan_MouseLeave(object sender, EventArgs e)
        {
            btnChuyenGopBan.ForeColor = Color.Black;
        }

        private void btnChuyenGopBan_MouseMove(object sender, MouseEventArgs e)
        {
            btnChuyenGopBan.ForeColor = Color.Yellow;
        }

        private void btnTachGopBan_MouseLeave(object sender, EventArgs e)
        {
            btnTachGopBan.ForeColor = Color.Black;
        }

        private void btnTachGopBan_MouseMove(object sender, MouseEventArgs e)
        {
            btnTachGopBan.ForeColor = Color.Yellow;
        }

        private void btnTachGopBan_Click(object sender, EventArgs e)
        {
            try
            {
                Ban ban = flpnHoaDon.Tag as Ban;
                int hoaDon = int.Parse(lbMaHoaDon.Text);
                List<DTO.Menu> menu = MenuDAL.Instance.LayDanhSachMenuTheoBan(ban.MaBan);

                if (flpnHoaDon.Controls.Count > 0)
                {
                    fTachGopBan f = new fTachGopBan(menu, ban, NguoiDungDangNhap, hoaDon);
                    f.ShowDialog();
                    fThuNgan_Load(sender, e);
                }
                else
                    MessageBox.Show("Không thể thực hiện!");
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn bàn cần tách!");
            }
        }

        private void btnChuyenGopBan_Click(object sender, EventArgs e)
        {
            try
            { 
                Ban ban = flpnHoaDon.Tag as Ban;
                int MaHD = int.Parse(lbMaHoaDon.Text);

                if(ban != null && BanDAL.Instance.KemTraTinhTrangBan(ban.MaBan) && lbMaHoaDon.Text != "...")
                {
                    fChuyenGopBan f = new fChuyenGopBan(ban, MaHD);
                    f.ShowDialog();

                    flpnHoaDon.Controls.Clear();
                    TaiHoaDonTheoBan(ban.MaBan);
                    fThuNgan_Load(sender, e);
                }
                else if (ban == null)
                {
                    MessageBox.Show("Chưa chọn bàn!");
                }
                else
                    MessageBox.Show("Bàn trống! Không thể chuyển hoặc gộp!");
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn bàn cần tách!");
            }

        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            if (lbBanThanhToan.Text != "...")
            {
                if (flpnHoaDon.Controls.Count > 0)
                {
                    MessageBox.Show("Đã thông báo!");
                }
                else
                    MessageBox.Show("Chưa có hóa đơn để thông báo!");

            }
            else
                MessageBox.Show("Chưa có hóa đơn để thông báo!");
        }

        private void txtTimMon_Enter(object sender, EventArgs e)
        {
            if (txtTimMon.Text == "Tìm món")
            {
                txtTimMon.Text = "";
                txtTimMon.ForeColor = Color.White;
            }
        }

        private void txtTimMon_Leave(object sender, EventArgs e)
        {
            if (txtTimMon.Text == "")
            {
                txtTimMon.Text = "Tìm món";
                txtTimMon.ForeColor = Color.WhiteSmoke;
            }
        }

        private void lbTimMon_Click(object sender, EventArgs e)
        {
            TaiDanhSachMonAnTheoTimKiem(txtTimMon.Text);
        }

        private void btnTachHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnTachHoaDon_MouseLeave(object sender, EventArgs e)
        {
            btnKhoaManHinh.ForeColor = Color.Black;
        }

        private void btnTachHoaDon_MouseMove(object sender, MouseEventArgs e)
        {
            btnKhoaManHinh.ForeColor = Color.Yellow;

        }

        private void btnKhoaManHinh_Click(object sender, EventArgs e)
        {
            fKhoaManHinh f = new fKhoaManHinh(NguoiDungDangNhap.HoTen, NguoiDungDangNhap.MatKhau);
            f.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hided)
            {
                pnTrinhPhatNhac.Height = pnTrinhPhatNhac.Height - 10;
                if (pnTrinhPhatNhac.Height == 10)
                {
                    timer1.Stop();
                    Hided = false;
                }
            }
            else
            {
                pnTrinhPhatNhac.Height = pnTrinhPhatNhac.Height + 10;
                if (pnTrinhPhatNhac.Height == 450)
                {
                    timer1.Stop();
                    Hided = true;
                }

            }    
        }

        OpenFileDialog openFileDialog;
        string[] filePaths;
        string[] fileNames;


        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Mp3 files, mp4 files (*.mp3, *.mp4)|*.mp*";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Open";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePaths = openFileDialog.FileNames;
                fileNames = openFileDialog.SafeFileNames;
                foreach (var item in fileNames)
                {
                    this.listDanhSachNhac.Items.Add(item);
                }
            }
        }

        private void listDanhSachNhac_DoubleClick(object sender, EventArgs e)
        {
            if (listDanhSachNhac.SelectedIndex != -1)
            {
                int choose = listDanhSachNhac.SelectedIndex;
                axWindowsMediaPlayer1.URL = filePaths[choose];
                this.txtDuongDan.Text = fileNames[choose];
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer2.Stop();
        }
    }
}
