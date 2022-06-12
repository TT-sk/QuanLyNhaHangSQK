using QuanLyNhaHangSQK.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyCaLamViec
{
    public partial class fThemCaLamViec : Form
    {
        public fThemCaLamViec()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string GhiChu = "Chưa có ghi chú";

                if (string.IsNullOrEmpty(txtMaCLV.Text.Trim()))
                {
                    MessageBox.Show("Vul lòng nhập mã ca làm việc!");
                    txtMaCLV.Focus();
                }
                else if (string.IsNullOrEmpty(txtTenCLV.Text.Trim()))
                {
                    MessageBox.Show("Vul lòng nhập tên ca làm việc!");
                    txtTenCLV.Focus();
                }
                else
                {
                    string MaCLV = txtMaCLV.Text;
                    string TenCLV = txtTenCLV.Text;
                    if (string.IsNullOrEmpty(txtGhiChu.Text.Trim()))
                        GhiChu = "Chưa có ghi chú";
                    else
                        GhiChu = txtGhiChu.Text;

                    string GioBD = nmrGioBD.Value + ":" + nmrPhutBD.Value + ":" + nmrGiayBD.Value;
                    string GioKT = nmrGioKT.Value + ":" + nmrPhutKT.Value + ":" + nmrGiayKT.Value;

                    if (CaLamViecDAL.Instance.ThemCLV(MaCLV, TenCLV, GhiChu, GioBD, GioKT))
                    {
                        MessageBox.Show("Thêm thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }
    }
}
