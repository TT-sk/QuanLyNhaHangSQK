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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyKhuVuc
{
    public partial class fThemKhuVucFileExcel : Form
    {
        private DataTable data;
        public DataTable Data { get => data; set => data = value; }

        public fThemKhuVucFileExcel(DataTable dataTable)
        {
            InitializeComponent();

            this.Data = dataTable;

            khuVucBindingSource.DataSource = Data;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvKhuVucFile.RowCount > 0)
                {
                    for (int i = 0; i < dtgvKhuVucFile.RowCount - 1; i++)
                    {
                        KhuVucDAL.Instance.ThemKhuVuc(dtgvKhuVucFile.Rows[i].Cells["MaKV"].Value.ToString(), dtgvKhuVucFile.Rows[i].Cells["TenKV"].Value.ToString());
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
