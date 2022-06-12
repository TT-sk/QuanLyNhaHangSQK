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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyCaLamViec
{
    public partial class fChiTietCaLamViec : Form
    {
        private CaLamViec caLamViec;

        public CaLamViec CaLamViec { get => caLamViec; set => caLamViec = value; }

        public fChiTietCaLamViec(CaLamViec caLamViec)
        {
            InitializeComponent();

            this.CaLamViec = caLamViec;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fChiTietCaLamViec_Load(object sender, EventArgs e)
        {
            TaiThongTinCaLamViec();
        }

        private void TaiThongTinCaLamViec()
        {
            txtMaCLV.Text = CaLamViec.MaCLV;
            txtTenCLV.Text = CaLamViec.TenCLV;
            txtGhiChu.Text = CaLamViec.GhiChu;

            TimeSpan timeBD = new TimeSpan(CaLamViec.GioBatDau.Hours, CaLamViec.GioBatDau.Minutes, CaLamViec.GioBatDau.Seconds);
            nmrGioBD.Text = string.Format("{0:D2}", timeBD.Hours);
            nmrPhutBD.Text = string.Format("{0:D2}", timeBD.Minutes);
            nmrGiayBD.Text = string.Format("{0:D2}", timeBD.Seconds);

            TimeSpan timeKT = new TimeSpan(CaLamViec.GioKetThuc.Hours, CaLamViec.GioKetThuc.Minutes, CaLamViec.GioKetThuc.Seconds);
            nmrGioKT.Text = string.Format("{0:D2}", timeKT.Hours);
            nmrPhutKT.Text = string.Format("{0:D2}", timeKT.Minutes);
            nmrGiayKT.Text = string.Format("{0:D2}", timeKT.Seconds);
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

                    if (CaLamViecDAL.Instance.SuaCLV(MaCLV, TenCLV, GhiChu, GioBD, GioKT))
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
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }
    }
}
