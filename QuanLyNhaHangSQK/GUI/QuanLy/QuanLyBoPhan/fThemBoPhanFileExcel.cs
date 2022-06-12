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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyBoPhan
{

    public partial class fThemBoPhanFileExcel : Form
    {
        private DataTable dataBoPhan;
        public DataTable DataBoPhan { get => dataBoPhan; set => dataBoPhan = value; }

        public fThemBoPhanFileExcel(DataTable dataTable)
        {
            InitializeComponent();

            this.DataBoPhan = dataTable;

            boPhanBindingSource.DataSource = DataBoPhan;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvBoPhanFile.RowCount > 0)
                {
                    for (int i = 0; i < dtgvBoPhanFile.RowCount -1; i++)
                    {
                        BoPhanDAL.Instance.ThemBoPhan(dtgvBoPhanFile.Rows[i].Cells["MaBP"].Value.ToString(), dtgvBoPhanFile.Rows[i].Cells["TenBP"].Value.ToString());
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
