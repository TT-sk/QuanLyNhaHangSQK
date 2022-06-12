using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class TongHoaDonGanDay
    {
        private int maCN;
        private string tenCN;
        private int soLuong;

        public int MaCN { get => maCN; set => maCN = value; }
        public string TenCN { get => tenCN; set => tenCN = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public TongHoaDonGanDay(int maCN, string tenCN, int soLuong)
        {
            this.MaCN = maCN;
            this.TenCN = tenCN;
            this.SoLuong = soLuong;
        }

        public TongHoaDonGanDay(DataRow row)
        {
            this.MaCN = (int)row["MaCN"];
            this.TenCN = row["TenCN"].ToString();
            this.SoLuong = (int)row["SoLuong"];
        }
    }
}
