using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class CTY
    {
        private int maCTY;
        private string tenCTY;
        private string tenVietTat;
        private string dienThoaiCTY;
        private byte[] logo;
        private string soLuoc;
        private string website;
        private string email;
        private string soTKNH;
        private string tenNH;
        private string diaChi;

        public int MaCTY { get => maCTY; set => maCTY = value; }
        public string TenCTY { get => tenCTY; set => tenCTY = value; }
        public string TenVietTat { get => tenVietTat; set => tenVietTat = value; }
        public string DienThoaiCTY { get => dienThoaiCTY; set => dienThoaiCTY = value; }
        public byte[] Logo { get => logo; set => logo = value; }
        public string SoLuoc { get => soLuoc; set => soLuoc = value; }
        public string Website { get => website; set => website = value; }
        public string Email { get => email; set => email = value; }
        public string SoTKNH { get => soTKNH; set => soTKNH = value; }
        public string TenNH { get => tenNH; set => tenNH = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

        public CTY(int maCTY, string tenCTY, string tenVietTat, string dienThoaiCTY, byte[] logo, string soLuoc, string website, string email, string soTKNH, string tenNH, string diaChi)
        {
            this.MaCTY = maCTY;
            this.TenCTY = tenCTY;
            this.SoLuoc = soLuoc;
            this.TenVietTat = tenVietTat;
            this.DienThoaiCTY = dienThoaiCTY;
            this.Logo = logo;
            this.Website = website;
            this.Email = email;
            this.SoTKNH = soTKNH;
            this.TenNH = tenNH;
            this.DiaChi = diaChi;

        }

        public CTY(DataRow row)
        {
            this.MaCTY = (int)row["MaCTY"];
            this.TenCTY = row["TenCTY"].ToString();
            this.SoLuoc = row["SoLuoc"].ToString();
            this.TenVietTat = row["TenVietTat"].ToString();
            this.DienThoaiCTY = row["DienThoaiCTY"].ToString();
            this.Logo = (byte[])row["Logo"];
            this.Website = row["Website"].ToString();
            this.Email = row["Email"].ToString();
            this.SoTKNH = row["SoTKNH"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.TenNH = row["TenNH"].ToString();
        }
    }
}
