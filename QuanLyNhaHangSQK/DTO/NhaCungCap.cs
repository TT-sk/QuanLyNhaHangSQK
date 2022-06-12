using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class NhaCungCap
    {
        private string maNCC;
        private string tenNCC;
        private string dienThoaiNCC;
        private string diaChiNCC;

        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string DienThoaiNCC { get => dienThoaiNCC; set => dienThoaiNCC = value; }
        public string DiaChiNCC { get => diaChiNCC; set => diaChiNCC = value; }

        public NhaCungCap(string maNCC, string tenNCC, string dienThoaiNCC, string diaChiNCC)
        {
            this.MaNCC = maNCC;
            this.TenNCC = tenNCC;
            this.DienThoaiNCC = dienThoaiNCC;
            this.DiaChiNCC = diaChiNCC;
        }

        public NhaCungCap(DataRow row)
        {
            this.MaNCC = row["MaNCC"].ToString();
            this.TenNCC = row["TenNCC"].ToString();
            this.DienThoaiNCC = row["DienThoaiNCC"].ToString();
            this.DiaChiNCC = row["DiaChiNCC"].ToString();
        }
    }
}
