using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class QuyDinhDAL
    {
        private static QuyDinhDAL instance;

        public static QuyDinhDAL Instance
        {
            get { if (instance == null) instance = new QuyDinhDAL(); return instance; }
            private set { instance = value; }
        }

        private QuyDinhDAL() { }

        public List<QuyDinh> TaiDanhSachQuyDinh()
        {
            List<QuyDinh> danhSachQuyDinh = new List<QuyDinh>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblQuyDinh");

            foreach (DataRow item in data.Rows)
            {
                QuyDinh quyDinh = new QuyDinh(item);
                danhSachQuyDinh.Add(quyDinh);
            }

            return danhSachQuyDinh;
        }

        public bool XoaQuyDinh(int MaQD)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("delete tblQuyDinh where MaQD = " + MaQD);

            return result > 0;
        }

        public bool ThemQuyDinh(string TieuDe, string NoiDung)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("insert tblQuyDinh (TenQD, NoiDung) values (N'{0}', N'{1}')", TieuDe, NoiDung));

            return result > 0;
        }
    }
}
