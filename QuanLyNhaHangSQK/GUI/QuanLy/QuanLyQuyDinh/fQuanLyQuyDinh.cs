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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyQuyDinh
{
    public partial class fQuanLyQuyDinh : Form
    {
        private bool Hided;

        public fQuanLyQuyDinh()
        {
            InitializeComponent();

            Hided = false;
        }

        private void fQuanLyQuyDinh_Load(object sender, EventArgs e)
        {
            TaiDanhSachQuyDinh();
        }

        private void TaiDanhSachQuyDinh()
        {
            flpnQuyDinh.Controls.Clear();

            List<QuyDinh> quyDinhs = QuyDinhDAL.Instance.TaiDanhSachQuyDinh();

            foreach (QuyDinh item in quyDinhs)
            {
                uctrItemQuyDinh btnQuyDinh = new uctrItemQuyDinh();

                btnQuyDinh.TieuDe = item.TenQD;
                btnQuyDinh.NoiDung = item.NoiDung;
                btnQuyDinh.ButtonClick_Xoa += btnQuyDinh_Click;
                btnQuyDinh.Tag = item;

                flpnQuyDinh.Controls.Add(btnQuyDinh);
            }
        }

        private void btnQuyDinh_Click(object sender, EventArgs e)
        {
            int MaQD = ((sender as uctrItemQuyDinh).Tag as QuyDinh).MaQD;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa quy định này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (QuyDinhDAL.Instance.XoaQuyDinh(MaQD))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachQuyDinh();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hided)
            {
                pnThem.Height = pnThem.Height - 10;
                if (pnThem.Height == 0)
                {
                    timer1.Stop();
                    Hided = false;
                }
            }
            else
            {
                pnThem.Height = pnThem.Height + 10;
                if (pnThem.Height == 190)
                {
                    timer1.Stop();
                    Hided = true;
                }

            }
        }

        private void btnThemQD_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTieuDe.Text.Trim()))
                {
                    MessageBox.Show("Vul lòng nhập tiêu đề!");
                    txtTieuDe.Focus();
                }
                else if (string.IsNullOrEmpty(txtNoiDung.Text.Trim()))
                {
                    MessageBox.Show("Vul lòng nhập nội dung!");
                    txtNoiDung.Focus();
                }
                else
                {
                    string TieuDe = txtTieuDe.Text;
                    string NoiDung = txtNoiDung.Text;
                    if (QuyDinhDAL.Instance.ThemQuyDinh(TieuDe, NoiDung))
                    {
                        MessageBox.Show("Thêm thành công!");
                        TaiDanhSachQuyDinh();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Mã đã tồn tại!");
            }
        }
    }
}
