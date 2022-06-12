using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class MenuMonAnNhapHang
    {
        private string tenMA;
        private int soLuong;
        private decimal donGia;
        private decimal thanhTien;

        public string TenMA { get => tenMA; set => tenMA = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public decimal ThanhTien { get => thanhTien; set => thanhTien = value; }

        public MenuMonAnNhapHang(string tenMA, int soLuong, decimal donGia, decimal thanhTien)
        {
            this.TenMA = tenMA;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }

        public MenuMonAnNhapHang(DataRow row)
        {
            this.TenMA = row["TenTP"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            this.DonGia = (decimal)row["GiaGoc"];
            this.ThanhTien = (decimal)row["ThanhTien"];
        }
    }
}
