using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class TopBanChayDAL
    {
        private static TopBanChayDAL instance;

        internal static TopBanChayDAL Instance 
        { 
            get { if (instance == null) instance = new TopBanChayDAL(); return instance; } 
            private set => instance = value; 
        }

        private TopBanChayDAL() { }

        public List<TopBanChay> TaiDanhSachTopBanChay(string NgayBD, string NgayKT)
        {
            List<TopBanChay> danhSachBanChay = new List<TopBanChay>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("exec ma_topbanchay '{0}', '{1}'", NgayBD, NgayKT));

            foreach (DataRow item in data.Rows)
            {
                TopBanChay topBanChay = new TopBanChay(item);
                danhSachBanChay.Add(topBanChay);
            }

            return danhSachBanChay;
        }
    }
}
