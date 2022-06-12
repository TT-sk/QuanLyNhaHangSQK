using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe.DoanhSo;
using QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe.HoaDonBaoCao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe
{
    public partial class fBaoCaoThongKe : Form
    {
        private bool HidedDoanhSo;
        private bool HidedHoaDon;
        private Form currentchildform;

        private int nam;
        private int maCN;

        public fBaoCaoThongKe()
        {
            InitializeComponent();

            HidedDoanhSo = false;
            HidedHoaDon = false;
        }

        private void fBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            TaiDanhSachChiNhanh();
            TaiDanhSachNam();
            //TaiBaoCaoDoanhSo((cbbChiNhanh.SelectedItem as ChiNhanh).MaCN, (cbbNam.SelectedItem as BaoCaoDoanhSo).Nam);

        }

        private void TaiDanhSachNam()
        {
            List<BaoCaoDoanhSo> baoCaoDoanhSos = DoanhThuGanDayDAL.Instance.TaiDanhSachNam();

            cbbNam.DataSource = baoCaoDoanhSos;
            cbbNam.DisplayMember = "Nam";
        }

        private void TaiBaoCaoDoanhSo(int MaCN, int Nam)
        {
            MoTrangCon(new fBaoCaoDoanhSo(MaCN, Nam));
        }

        private void TaiBieuDoDoanhSo(int MaCN, int Nam)
        {
            MoTrangCon(new fBieuDoDoanhSo(MaCN, Nam));
        }

        private void TaiBaoCaoHoaDon(string ngayBD, string ngayKT, int maCN)
        {
            MoTrangCon(new fBaoCaoHoaDon(ngayBD, ngayKT, maCN));
        }

        private void TaiBieuDoHoaDon(string ngayBD, string ngayKT, int maCN)
        {
            MoTrangCon(new fBieuDoHoaDon(ngayBD, ngayKT, maCN));
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
            pnBaoCao.Controls.Add(trangCon);
            pnBaoCao.Tag = trangCon;
            trangCon.BringToFront();
            trangCon.Show();
            trangCon.Text = trangCon.Text;
        }


        private void TaiDanhSachChiNhanh()
        {
            List<ChiNhanh> chiNhanhs = ChiNhanhDAL.Instance.TaiDanhSachChiNhanh();

            cbbChiNhanh.DataSource = chiNhanhs;
            cbbChiNhanh.DisplayMember = "TenCN";
        }

        private void rdbtnHoaDon_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Start();
            if (rdbtnBaoCao.Checked)
            {
                try
                {
                    datetimeNgayBD.CustomFormat = "yyyy-MM-dd";
                    datetimeNgayKT.CustomFormat = "yyyy-MM-dd";

                    TaiBaoCaoHoaDon(datetimeNgayBD.Text, datetimeNgayKT.Text, (cbbChiNhanh.SelectedItem as ChiNhanh).MaCN);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
            }
            else if (rdbtnBieuDo.Checked)
            {
                try
                {
                    datetimeNgayBD.CustomFormat = "yyyy-MM-dd";
                    datetimeNgayKT.CustomFormat = "yyyy-MM-dd";

                    TaiBieuDoHoaDon(datetimeNgayBD.Text, datetimeNgayKT.Text, (cbbChiNhanh.SelectedItem as ChiNhanh).MaCN);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
            }
        }

        private void rdbtnDoanhSo_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Start();
            if (rdbtnBaoCao.Checked)
            {
                try
                {
                    TaiBaoCaoDoanhSo((cbbChiNhanh.SelectedItem as ChiNhanh).MaCN, (cbbNam.SelectedItem as BaoCaoDoanhSo).Nam);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
                
            }
            else if (rdbtnBieuDo.Checked)
            {
                try
                {
                    TaiBieuDoDoanhSo((cbbChiNhanh.SelectedItem as ChiNhanh).MaCN, (cbbNam.SelectedItem as BaoCaoDoanhSo).Nam);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (HidedHoaDon)
            {
                pnThoiGianHoaDon.Height = pnThoiGianHoaDon.Height - 10;
                if (pnThoiGianHoaDon.Height == 10)
                {
                    timer1.Stop();
                    HidedHoaDon = false;
                }
            }
            else
            {
                pnThoiGianHoaDon.Height = pnThoiGianHoaDon.Height + 10;
                if (pnThoiGianHoaDon.Height == 160)
                {
                    timer1.Stop();
                    HidedHoaDon = true;
                }
            }

            if (HidedDoanhSo)
            {
                pnThoiGianDoanhSo.Height = pnThoiGianDoanhSo.Height + 10;
                if (pnThoiGianDoanhSo.Height == 160)
                {
                    timer1.Stop();
                    HidedDoanhSo = false;
                }
            }
            else
            {
                pnThoiGianDoanhSo.Height = pnThoiGianDoanhSo.Height - 10;
                if (pnThoiGianDoanhSo.Height == 10)
                {
                    timer1.Stop();
                    HidedDoanhSo = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void rdbtnBaoCao_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnDoanhSo.Checked)
            {
                try
                {
                    TaiBaoCaoDoanhSo((cbbChiNhanh.SelectedItem as ChiNhanh).MaCN, (cbbNam.SelectedItem as BaoCaoDoanhSo).Nam);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
                
            }
            else if (rdbtnHoaDon.Checked)
            {
                try
                {
                    datetimeNgayBD.CustomFormat = "yyyy-MM-dd";
                    datetimeNgayKT.CustomFormat = "yyyy-MM-dd";

                    TaiBaoCaoHoaDon(datetimeNgayBD.Text, datetimeNgayKT.Text, (cbbChiNhanh.SelectedItem as ChiNhanh).MaCN);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
            }
        }

        private void cbbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            ChiNhanh chiNhanh = cbb.SelectedItem as ChiNhanh;

            maCN = chiNhanh.MaCN;

            if (rdbtnDoanhSo.Checked && rdbtnBaoCao.Checked)
            {
                try
                {
                    TaiBaoCaoDoanhSo(chiNhanh.MaCN, nam);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
            }
            else if (rdbtnDoanhSo.Checked && rdbtnBieuDo.Checked)
            {
                try
                {
                    TaiBieuDoDoanhSo(chiNhanh.MaCN, nam);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
            }    
            else if (rdbtnHoaDon.Checked && rdbtnBaoCao.Checked)
            {
                try
                {

                    datetimeNgayBD.CustomFormat = "yyyy-MM-dd";
                    datetimeNgayKT.CustomFormat = "yyyy-MM-dd";

                    TaiBaoCaoHoaDon(datetimeNgayBD.Text, datetimeNgayKT.Text, chiNhanh.MaCN);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
            }    
            else if (rdbtnHoaDon.Checked && rdbtnBieuDo.Checked)
            {
                try
                {
                    datetimeNgayBD.CustomFormat = "yyyy-MM-dd";
                    datetimeNgayKT.CustomFormat = "yyyy-MM-dd";

                    TaiBieuDoHoaDon(datetimeNgayBD.Text, datetimeNgayKT.Text, (cbbChiNhanh.SelectedItem as ChiNhanh).MaCN);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
            }
        }

        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            BaoCaoDoanhSo Nams = cbb.SelectedItem as BaoCaoDoanhSo;

            nam = Nams.Nam;

            if (rdbtnDoanhSo.Checked && rdbtnBaoCao.Checked)
            {
                try
                {
                    TaiBaoCaoDoanhSo(maCN, Nams.Nam);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
            }
            else if (rdbtnDoanhSo.Checked && rdbtnBieuDo.Checked)
            {
                try
                {
                    TaiBieuDoDoanhSo(maCN, Nams.Nam);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }
            }    
        }

        private void rdbtnBieuDo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnDoanhSo.Checked)
            {
                try
                {
                    TaiBieuDoDoanhSo((cbbChiNhanh.SelectedItem as ChiNhanh).MaCN, (cbbNam.SelectedItem as BaoCaoDoanhSo).Nam);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }

            }
            else if (rdbtnHoaDon.Checked)
            {
                try
                {
                    datetimeNgayBD.CustomFormat = "yyyy-MM-dd";
                    datetimeNgayKT.CustomFormat = "yyyy-MM-dd";

                    TaiBieuDoHoaDon(datetimeNgayBD.Text, datetimeNgayKT.Text, (cbbChiNhanh.SelectedItem as ChiNhanh).MaCN);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập năm!");
                }

            }
        }
    }
}
