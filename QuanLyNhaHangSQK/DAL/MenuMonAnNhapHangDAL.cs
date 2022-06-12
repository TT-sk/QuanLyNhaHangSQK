using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class MenuMonAnNhapHangDAL
    {
        private static MenuMonAnNhapHangDAL instance;

        public static MenuMonAnNhapHangDAL Instance
        {
            get { if (instance == null) instance = new MenuMonAnNhapHangDAL(); return instance; }
            private set { instance = value; }
        }

        private MenuMonAnNhapHangDAL() { }

        public List<MenuMonAnNhapHang> TaiDanhSachMonAnNhapHangTheoPN(int MaPN)
        {
            List<MenuMonAnNhapHang> danhSachMenu = new List<MenuMonAnNhapHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select m.TenTP, c.SoLuong, m.GiaGoc, c.SoLuong * m.GiaGoc as ThanhTien from tblChiTietPhieuNhapHang c, tblMonAn m where c.MaMA = m.MaMA and c.MaPN = " + MaPN));

            foreach (DataRow item in data.Rows)
            {
                MenuMonAnNhapHang menu = new MenuMonAnNhapHang(item);
                danhSachMenu.Add(menu);
            }

            return danhSachMenu;
        }
    }
}
