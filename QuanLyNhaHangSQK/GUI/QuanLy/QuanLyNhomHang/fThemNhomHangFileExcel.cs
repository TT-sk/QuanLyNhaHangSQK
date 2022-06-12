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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhomHang
{
    public partial class fThemNhomHangFileExcel : Form
    {
        private DataTable data;
        public DataTable Data { get => data; set => data = value; }

        public fThemNhomHangFileExcel(DataTable dataTable)
        {
            InitializeComponent();

            this.Data = dataTable;

            nhomHangBindingSource.DataSource = Data;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvNhomHangFile.RowCount > 0)
                {
                    for (int i = 0; i < dtgvNhomHangFile.RowCount - 1; i++)
                    {
                        NhomHangDAL.Instance.ThemNhomHang(dtgvNhomHangFile.Rows[i].Cells["TenNH"].Value.ToString());
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
