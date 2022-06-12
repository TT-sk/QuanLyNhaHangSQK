using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class DoanhThuGanDayDAL
    {
        private static DoanhThuGanDayDAL instance;

        public static DoanhThuGanDayDAL Instance
        {
            get { if (instance == null) instance = new DoanhThuGanDayDAL(); return instance; }
            private set => instance = value;
        }

        private DoanhThuGanDayDAL() { }

        public List<DoanhThuGanDay> TaiDoanhThuTheoNgay(string NgayBD, string NgayKT)
        {
            List<DoanhThuGanDay> danhSachDoanhThu = new List<DoanhThuGanDay>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("exec cn_doanhthu '{0}', '{1}'", NgayBD, NgayKT));

            foreach (DataRow item in data.Rows)
            {
                DoanhThuGanDay doanhThu = new DoanhThuGanDay(item);
                danhSachDoanhThu.Add(doanhThu);
            }

            return danhSachDoanhThu;
        }

        public List<BaoCaoDoanhSo> TaiDanhSachNam()
        {
            List<BaoCaoDoanhSo> danhSachNam = new List<BaoCaoDoanhSo>();

            DataTable data = DataProvider.Instance.ExcuteQuery("exec baocao_laynamcombobox");

            foreach (DataRow item in data.Rows)
            {
                BaoCaoDoanhSo nam = new BaoCaoDoanhSo(item);
                danhSachNam.Add(nam);
            }

            return danhSachNam;
        }

        public List<BaoCaoDoanhSoThuChi> DoanhSoThuChi(int MaCN, int Nam)
        {
            List<BaoCaoDoanhSoThuChi> baoCaoDoanhSoThuChis = new List<BaoCaoDoanhSoThuChi>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("exec doanhso_thuchi {0}, {1}", MaCN, Nam));

            foreach (DataRow item in data.Rows)
            {
                BaoCaoDoanhSoThuChi baoCaoDoanhSo = new BaoCaoDoanhSoThuChi(item);
                baoCaoDoanhSoThuChis.Add(baoCaoDoanhSo);
            }

            return baoCaoDoanhSoThuChis;
        }

        public List<BaoCaoHoaDon> BaoCaoHoaDon(string FromDate, string ToDate, int MaCN)
        {
            List<BaoCaoHoaDon> baoCaoHDs = new List<BaoCaoHoaDon>();
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("exec baocao_hoadon '{0}', '{1}', '{2}'", FromDate, ToDate, MaCN));

            foreach (DataRow item in data.Rows)
            {
                BaoCaoHoaDon bao = new BaoCaoHoaDon(item);
                baoCaoHDs.Add(bao);
            }

            return baoCaoHDs;
        }
    }
}
