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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn
{
    public partial class fThemMonAnFileExcel : Form
    {
        private DataTable data;

        public DataTable Data { get => data; set => data = value; }

        public fThemMonAnFileExcel(DataTable dataTable)
        {
            InitializeComponent();

            this.Data = dataTable;

            monAnBindingSource.DataSource = Data;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvMonAnFile.RowCount > 0)
                {
                    for (int i = 0; i < dtgvMonAnFile.RowCount - 1; i++)
                    {
                        MonAnDAL.Instance.ThemMonAn((int)dtgvMonAnFile.Rows[i].Cells["MaNH"].Value, dtgvMonAnFile.Rows[i].Cells["TenMA"].Value.ToString(), (decimal)dtgvMonAnFile.Rows[i].Cells["GiaTien"].Value, (decimal)dtgvMonAnFile.Rows[i].Cells["GiaGoc"].Value, (byte[])dtgvMonAnFile.Rows[i].Cells["Anh"].Value, dtgvMonAnFile.Rows[i].Cells["DonViTinh"].Value.ToString());
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
