using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class DoanhThuGanDay
    {
        private int maCN;
        private string tenCN;
        private decimal tongDoanhThuCN;

        public int MaCN { get => maCN; set => maCN = value; }
        public string TenCN { get => tenCN; set => tenCN = value; }
        public decimal TongDoanhThuCN { get => tongDoanhThuCN; set => tongDoanhThuCN = value; }

        public DoanhThuGanDay(int maCN, string tenCN, decimal tongDoanhThuCN)
        {
            this.MaCN = maCN;
            this.TenCN = tenCN;
            this.TongDoanhThuCN = tongDoanhThuCN;
        }
        public DoanhThuGanDay(DataRow row)
        {
            this.MaCN = (int)row["MaCN"];
            this.TenCN = row["TenCN"].ToString();
            this.TongDoanhThuCN = (decimal)row["TongDoanhThuCN"];
        }
    }

    public class BaoCaoDoanhSo
    {
        private int nam;

        public int Nam { get => nam; set => nam = value; }

        public BaoCaoDoanhSo(int nam)
        {
            this.Nam = nam;
        }

        public BaoCaoDoanhSo(DataRow row)
        {
            this.Nam = (int)row["Nam"];
        }
    }

    public class BaoCaoDoanhSoThuChi
    {
        private int thang;
        private decimal tongThu;
        private decimal tongChi;

        public int Thang { get => thang; set => thang = value; }
        public decimal TongThu { get => tongThu; set => tongThu = value; }
        public decimal TongChi { get => tongChi; set => tongChi = value; }

        public BaoCaoDoanhSoThuChi(int thang, decimal tongThu, decimal tongChi)
        {
            this.Thang = thang;
            this.TongThu = tongThu;
            this.TongChi = tongChi;
        }

        public BaoCaoDoanhSoThuChi(DataRow row)
        {
            this.Thang = (int)row["Thang"];
            this.TongThu = (decimal)row["TongThu"]; 
            this.TongChi = (decimal)row["TongChi"]; 
        }

    }

    public class BaoCaoHoaDon
    {

        private int maHD;
        private string tenNV;
        private string tenKH;
        private string tenCN;
        private DateTime tGTT;
        private decimal tongHD;
        private double giamGia;
        private double thanhTien;


        public int MaHD { get => maHD; set => maHD = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string TenCN { get => tenCN; set => tenCN = value; }
        public DateTime TGTT { get => tGTT; set => tGTT = value; }
        public decimal TongHD { get => tongHD; set => tongHD = value; }
        public double GiamGia { get => giamGia; set => giamGia = value; }
        public double ThanhTien { get => thanhTien; set => thanhTien = value; }


        public BaoCaoHoaDon(int maHD, string tenNV, string tenKH, string tenCN, DateTime tGTT, decimal tongHD, double giamGia, double thanhTien)
        {
            this.MaHD = maHD;
            this.TenNV = tenNV;
            this.TenKH = tenKH;
            this.TenCN = TenCN;
            this.TGTT = tGTT;
            this.TongHD = tongHD;
            this.GiamGia = giamGia;
            this.ThanhTien = thanhTien;
        }
        public BaoCaoHoaDon(DataRow row)
        {
            this.MaHD = (int)row["MaHD"];
            this.TenNV = row["TenNV"].ToString();
            this.TenKH = row["TenKH"].ToString();
            this.TenCN = row["TenCN"].ToString();
            this.TGTT = (DateTime)row["TGTT"];
            this.TongHD = (decimal)row["TongHoaDon"];
            this.GiamGia = (double)row["GiamGia"];
            this.ThanhTien = (double)row["ThanhTien"];

        }
    }
}
