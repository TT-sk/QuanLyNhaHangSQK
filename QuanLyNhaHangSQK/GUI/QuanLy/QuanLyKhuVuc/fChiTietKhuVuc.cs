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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyKhuVuc
{
    public partial class fChiTietKhuVuc : Form
    {
        private KhuVuc khuVuc;

        public KhuVuc KhuVuc { get => khuVuc; set => khuVuc = value; }

        public fChiTietKhuVuc(KhuVuc khuVuc)
        {
            InitializeComponent();

            this.KhuVuc = khuVuc;
        }

        private void fChiTietKhuVuc_Load(object sender, EventArgs e)
        {
            TaiThongTinKhuVuc();
        }

        private void TaiThongTinKhuVuc()
        {
            txtMaKV.Text = KhuVuc.MaKV;
            txtTenKV.Text = KhuVuc.TenKV;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKV.Text.Trim()))
            {
                MessageBox.Show("Vul lòng nhập mã khu vực!");
                txtMaKV.Focus();
            }
            else if (string.IsNullOrEmpty(txtTenKV.Text.Trim()))
            {
                MessageBox.Show("Vul lòng nhập tên khu vực!");
                txtTenKV.Focus();
            }
            else
            {
                string TenKV = txtTenKV.Text;
                string MaKV = txtMaKV.Text;
                if (KhuVucDAL.Instance.SuaKhuVuc(MaKV, TenKV))
                {
                    MessageBox.Show("Sửa thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
