using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class ChiTietPhieuNhapHang
    {
        private int maPN;
        private int maMA;
        private int soLuong;

        public int MaPN { get => maPN; set => maPN = value; }
        public int MaMA { get => maMA; set => maMA = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        
        public ChiTietPhieuNhapHang(int maPN, int maMA, int soLuong)
        {
            this.MaPN = maPN;
            this.MaMA = maMA;
            this.SoLuong = soLuong;

        }

        public ChiTietPhieuNhapHang(DataRow row)
        {
            this.MaPN = (int)row["MaPN"];
            this.MaMA = (int)row["MaMA"];
            this.SoLuong = (int)row["SoLuong"];
        }
    }
}
