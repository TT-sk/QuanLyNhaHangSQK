using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class TopBanChay
    {
        private string tenMA;
        private int soLuong;

        public string TenMA { get => tenMA; set => tenMA = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public TopBanChay(string tenMA, int soLuong)
        {
            this.TenMA = tenMA;
            this.SoLuong = soLuong;
        }

        public TopBanChay(DataRow row)
        {
            this.TenMA = row["TenTP"].ToString();
            this.SoLuong = (int)row["SoLuong"];
        }
    }
}
