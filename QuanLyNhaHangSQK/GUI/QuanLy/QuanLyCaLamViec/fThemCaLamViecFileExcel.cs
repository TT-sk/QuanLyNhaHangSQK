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
    public partial class fThemCaLamViecFileExcel : Form
    {
        private DataTable dataCaLamViec;
        public DataTable DataCaLamViec { get => dataCaLamViec; set => dataCaLamViec = value; }

        public fThemCaLamViecFileExcel(DataTable dataTable)
        {
            InitializeComponent();
            this.DataCaLamViec = dataTable;

            caLamViecBindingSource.DataSource = DataCaLamViec;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvCaLamViecFile.RowCount > 0)
                {
                    for (int i = 0; i < dtgvCaLamViecFile.RowCount - 1; i++)
                    {
                        CaLamViecDAL.Instance.ThemCLV(dtgvCaLamViecFile.Rows[i].Cells["MaCLV"].Value.ToString(), dtgvCaLamViecFile.Rows[i].Cells["TenCLV"].Value.ToString(), dtgvCaLamViecFile.Rows[i].Cells["GhiChu"].Value.ToString(), dtgvCaLamViecFile.Rows[i].Cells["GioBD"].Value.ToString(), dtgvCaLamViecFile.Rows[i].Cells["GioKT"].Value.ToString());
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
