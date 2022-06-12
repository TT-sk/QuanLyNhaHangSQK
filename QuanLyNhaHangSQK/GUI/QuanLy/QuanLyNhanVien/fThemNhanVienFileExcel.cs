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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhanVien
{
    public partial class fThemNhanVienFileExcel : Form
    {
        private DataTable data;

        public DataTable Data { get => data; set => data = value; }

        public fThemNhanVienFileExcel(DataTable dataTable)
        {
            InitializeComponent();

            this.Data = dataTable;

            nguoiDungBindingSource.DataSource = Data;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvNhanVienFile.RowCount > 0)
                {
                    for (int i = 0; i < dtgvNhanVienFile.RowCount - 1; i++)
                    {
                        int MaCN = int.Parse(dtgvNhanVienFile.Rows[i].Cells["MaCN"].Value.ToString());
                        DateTime NgaySinh = DateTime.Parse(dtgvNhanVienFile.Rows[i].Cells["NgaySinh"].Value.ToString());
                        DateTime NgayVL = DateTime.Parse(dtgvNhanVienFile.Rows[i].Cells["NgayVL"].Value.ToString());
                        decimal Luong = decimal.Parse(dtgvNhanVienFile.Rows[i].Cells["Luong"].Value.ToString());

                        NguoiDungDAL.Instance.ThemNguoiDung(dtgvNhanVienFile.Rows[i].Cells["MaBP"].Value.ToString(), dtgvNhanVienFile.Rows[i].Cells["MaCLV"].Value.ToString(), MaCN, dtgvNhanVienFile.Rows[i].Cells["HoTen"].Value.ToString(), NgaySinh.ToShortDateString(), NgayVL.ToShortDateString(), dtgvNhanVienFile.Rows[i].Cells["GioiTinh"].Value.ToString(), dtgvNhanVienFile.Rows[i].Cells["DienThoai"].Value.ToString(), dtgvNhanVienFile.Rows[i].Cells["DiaChi"].Value.ToString(), Luong, dtgvNhanVienFile.Rows[i].Cells["CMND"].Value.ToString(), dtgvNhanVienFile.Rows[i].Cells["Email"].Value.ToString());
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
