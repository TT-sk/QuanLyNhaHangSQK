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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhaCungCap
{
    public partial class fThemNhaCungCapFileExcel : Form
    {
        private DataTable data;
        public DataTable Data { get => data; set => data = value; }

        public fThemNhaCungCapFileExcel(DataTable dataTable)
        {
            InitializeComponent();

            this.Data = dataTable;

            nhaCungCapBindingSource.DataSource = Data;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvNhaCungCapFile.RowCount > 0)
                {
                    for (int i = 0; i < dtgvNhaCungCapFile.RowCount - 1; i++)
                    {
                        NhaCungCapDAL.Instance.ThemNCC(dtgvNhaCungCapFile.Rows[i].Cells["MaNCC"].Value.ToString(), dtgvNhaCungCapFile.Rows[i].Cells["TenNCC"].Value.ToString(), dtgvNhaCungCapFile.Rows[i].Cells["DienThoai"].Value.ToString(), dtgvNhaCungCapFile.Rows[i].Cells["DiaChi"].Value.ToString());
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
