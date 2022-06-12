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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyChiNhanh
{
    public partial class fThemChiNhanhFileExcel : Form
    {
        private DataTable data;
        public DataTable Data { get => data; set => data = value; }

        public fThemChiNhanhFileExcel(DataTable data)
        {
            InitializeComponent();

            this.Data = data;

            chiNhanhBindingSource.DataSource = Data;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtgvChiNhanhFile.RowCount > 0)
            {
                for (int i = 0; i < dtgvChiNhanhFile.RowCount - 1; i++)
                {
                    int MaCTY = int.Parse(dtgvChiNhanhFile.Rows[i].Cells["MaCTY"].Value.ToString());

                    ChiNhanhDAL.Instance.ThemChiNhanh(dtgvChiNhanhFile.Rows[i].Cells["TenCN"].Value.ToString(), dtgvChiNhanhFile.Rows[i].Cells["DiaChiCN"].Value.ToString(), dtgvChiNhanhFile.Rows[i].Cells["DienThoaiCN"].Value.ToString(), dtgvChiNhanhFile.Rows[i].Cells["Email"].Value.ToString(), dtgvChiNhanhFile.Rows[i].Cells["TenNH"].Value.ToString(), dtgvChiNhanhFile.Rows[i].Cells["SoTKNH"].Value.ToString(), MaCTY);
                }
                MessageBox.Show("Thêm thành công!");
                this.Close();
            }
            else
                MessageBox.Show("Lỗi!");
        }
    }
}
