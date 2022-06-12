using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class PhieuNhapHang
    {
        private int maPN;
        private string maNCC;
        private int maND;
        private DateTime ngayLap;
        private DateTime ngayNhapHang;

        public int MaPN { get => maPN; set => maPN = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public int MaND { get => maND; set => maND = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public DateTime NgayNhapHang { get => ngayNhapHang; set => ngayNhapHang = value; }


        public PhieuNhapHang(int maPN, string maNCC, int maND, DateTime ngayLap, DateTime ngayNhapHang)
        {
            this.MaPN = maPN;
            this.MaNCC = maNCC;
            this.MaND = maND;
            this.NgayLap = ngayLap;
            this.NgayNhapHang = ngayNhapHang;

        }
        public PhieuNhapHang(DataRow row)
        {
            this.MaPN = (int)row["MaPN"];
            this.MaNCC = row["MaNCC"].ToString();
            this.MaND = (int)row["MaND"];
            this.NgayLap = (DateTime)row["NgayLap"];
            this.NgayNhapHang = (DateTime)row["NgayNhapHang"];
        }
    }
}
