using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class PhieuChi
    {
        private int maPC;
        private int maND;
        private int maPN;
        private DateTime ngayChi;
        private static decimal thanhTien;

        public int MaPC { get => maPC; set => maPC = value; }
        public int MaND { get => maND; set => maND = value; }
        public int MaPN { get => maPN; set => maPN = value; }
        public DateTime NgayChi { get => ngayChi; set => ngayChi = value; }
        public static decimal ThanhTien { get => thanhTien; set => thanhTien = value; }

        public PhieuChi(int maPC, int maND, int maPN, DateTime ngayChi)
        {
            this.MaND = maND;
            this.MaPC = maPC;
            this.MaPN = maPN;
            this.NgayChi = ngayChi;
        }

        public PhieuChi(DataRow row)
        {
            this.MaND = (int)row["MaND"];
            this.MaPC = (int)row["MaPC"];
            this.MaPN = (int)row["MaPN"];
            this.NgayChi = (DateTime)row["NgayChi"];
        }

    }
}
