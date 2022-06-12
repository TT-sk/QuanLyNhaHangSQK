using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class HoaDonGanDayDAL
    {
        private static HoaDonGanDayDAL instance;

        public static HoaDonGanDayDAL Instance 
        { 
            get { if (instance == null) instance = new HoaDonGanDayDAL(); return instance; }
            private set => instance = value; 
        }

        private HoaDonGanDayDAL() { }

        public List<TongHoaDonGanDay> TaiHoaDonGanDay(string NgayBD, string NgayKT)
        {
            List<TongHoaDonGanDay> danhSachHoaDon = new List<TongHoaDonGanDay>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("exec cn_soluonghoadon '{0}', '{1}'", NgayBD, NgayKT));

            foreach (DataRow item in data.Rows)
            {
                TongHoaDonGanDay hoaDonGanDay = new TongHoaDonGanDay(item);
                danhSachHoaDon.Add(hoaDonGanDay);
            }

            return danhSachHoaDon;
        }
    }
}
