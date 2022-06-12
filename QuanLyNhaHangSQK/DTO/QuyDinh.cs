using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class QuyDinh
    {
        private int maQD;
        private string tenQD;
        private string noiDung;

        public int MaQD { get => maQD; set => maQD = value; }
        public string TenQD { get => tenQD; set => tenQD = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }

        public QuyDinh(int maQD, string tenQD, string noiDung)
        {
            this.TenQD = tenQD;
            this.MaQD = maQD;
            this.NoiDung = noiDung;

        }

        public QuyDinh(DataRow row)
        {
            this.MaQD = (int)row["MaQD"];
            this.TenQD = row["TenQD"].ToString();
            this.NoiDung = row["NoiDung"].ToString();
        }
    }
}
