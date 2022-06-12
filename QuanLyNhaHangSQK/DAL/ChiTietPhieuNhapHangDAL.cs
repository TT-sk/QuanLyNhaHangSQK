using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace QuanLyNhaHangSQK.DAL
{
    public class ChiTietPhieuNhapHangDAL
    {
        private static ChiTietPhieuNhapHangDAL instance;

        public static ChiTietPhieuNhapHangDAL Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuNhapHangDAL(); return instance; }
            private set => instance = value;
        }

        private ChiTietPhieuNhapHangDAL() { }

        public bool ThemChiTietPhieuNhap(int MaPN, int MaMA, int SoLuong)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("Insert into tblChiTietPhieuNhapHang (MaPN, MaMA, SoLuong) values ({0}, {1}, {2})", MaPN, MaMA, SoLuong));

            return result > 0;
        }

    }
}
