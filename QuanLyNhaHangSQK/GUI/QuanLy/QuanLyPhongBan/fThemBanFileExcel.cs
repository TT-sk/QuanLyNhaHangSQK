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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhongBan
{
    public partial class fThemBanFileExcel : Form
    {
        private DataTable data;

        public DataTable Data { get => data; set => data = value; }

        public fThemBanFileExcel(DataTable dataTable)
        {
            InitializeComponent();

            this.Data = dataTable;

            banBindingSource.DataSource = Data;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvBanFile.RowCount > 0)
                {
                    for (int i = 0; i < dtgvBanFile.RowCount - 1; i++)
                    {
                        BanDAL.Instance.ThemBan(dtgvBanFile.Rows[i].Cells["MaKV"].Value.ToString(), dtgvBanFile.Rows[i].Cells["GhiChu"].Value.ToString());
                    }
                    MessageBox.Show("Thêm thành công!");
                    this.Close();
                }
                else
                    MessageBox.Show("Lỗi!");
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }
    }
}
