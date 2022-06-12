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
    public partial class fChuyenGopBan : Form
    {
        private Ban ban;
        private int hoaDon;

        public Ban Ban { get => ban; set => ban = value; }
        public int HoaDon { get => hoaDon; set => hoaDon = value; }

        public fChuyenGopBan(Ban maBan, int maHD)
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
            this.Ban = maBan;
            this.HoaDon = maHD;
        }

        private void fChuyenGopBan_Load(object sender, EventArgs e)
        {
            TaiLenKhuVucVaBanCu();
            TaiLenKhuVucMoi();
        }
        private void TaiLenKhuVucVaBanCu()
        {
            string TenKhuVuc = KhuVucDAL.Instance.LayTenKhuVucTheoMa(Ban.MaKV);
            if (TenKhuVuc != null)
            {
                txtBanCu.Text = Ban.MaBan.ToString();
                txtKhuVucBanCu.Text = TenKhuVuc;
            }
        }

        public void TaiLenKhuVucMoi()
        {
            List<KhuVuc> khuVucs = KhuVucDAL.Instance.LayDanhSachKhuVuc();

            cbbKhuVucBanMoi.DataSource = khuVucs;
            cbbKhuVucBanMoi.DisplayMember = "TenKV";
        }

        public bool ChuyenBan()
        {
            if (rdbtnChuyenBan.Checked)
            {
                int MaBanCu = Ban.MaBan;
                int MaBanMoi = (cbbBanMoi.SelectedItem as Ban).MaBan;
                int MaHD = HoaDon;

                if (HoaDonDAL.Instance.ChuyenHoaDon(MaBanCu, MaBanMoi, MaHD))
                {
                    MessageBox.Show("Chuyển thành công!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Chuyển thất bại!");
                    return false;
                }
            }
            else if (rdbtnGopBan.Checked)
            {
                int MaBanCu = Ban.MaBan;
                int MaBanMoi = (cbbBanMoi.SelectedItem as Ban).MaBan;
                int MaHDCu = HoaDon;
                int MaHDMoi = HoaDonDAL.Instance.LayMaHDTheoBan(MaBanMoi);

                if (HoaDonDAL.Instance.GopHoaDon(MaBanCu, MaBanMoi, MaHDCu, MaHDMoi))
                {
                    MessageBox.Show("Gộp thành công!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Gộp thất bại!");
                    return false;
                }
            }
            return false;
        }

        private void cbbKhuVucBanMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if(cbb.SelectedItem == null)
                return;

            KhuVuc khuVuc = cbb.SelectedItem as KhuVuc;

            if (rdbtnChuyenBan.Checked)
            {
                List<Ban> ban = BanDAL.Instance.TaiDanhSachBanTheoKVVaTinhTrang(khuVuc.MaKV, 0);
                cbbBanMoi.DataSource = ban;
                cbbBanMoi.DisplayMember = "MaBan";
            }
            else if (rdbtnGopBan.Checked)
            {
                List<Ban> ban = BanDAL.Instance.TaiDanhSachBanTheoKVVaTinhTrang(khuVuc.MaKV, 1);
                cbbBanMoi.DataSource = ban;
                cbbBanMoi.DisplayMember = "MaBan";
            }
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ChuyenBan())
                this.Close();
        }

        private void rdbtnGopBan_CheckedChanged(object sender, EventArgs e)
        {
            fChuyenGopBan_Load(sender, e);
        }

        private void rdbtnChuyenBan_CheckedChanged(object sender, EventArgs e)
        {
            fChuyenGopBan_Load(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }
    }
}
