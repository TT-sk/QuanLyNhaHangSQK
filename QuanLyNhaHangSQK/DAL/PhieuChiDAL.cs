using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class PhieuChiDAL
    {
        private static PhieuChiDAL instance;

        public static PhieuChiDAL Instance
        {
            get { if (instance == null) instance = new PhieuChiDAL(); return instance; }
            private set => instance = value;
        }

        private PhieuChiDAL() { }

        public List<PhieuChi> TaiDanhSachPhieuChi()
        {
            List<PhieuChi> danhSachPhieuChi = new List<PhieuChi>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblPhieuChi");

            foreach (DataRow item in data.Rows)
            {
                PhieuChi phieuChi = new PhieuChi(item);
                danhSachPhieuChi.Add(phieuChi);
            }

            return danhSachPhieuChi;
        }

        public List<PhieuChi> TaiDanhSachPhieuChiTheoMaPN(int MaPN)
        {
            List<PhieuChi> danhSachPhieuChi = new List<PhieuChi>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblPhieuChi where MaPN = " + MaPN);

            foreach (DataRow item in data.Rows)
            {
                PhieuChi phieuChi = new PhieuChi(item);
                danhSachPhieuChi.Add(phieuChi);
            }

            return danhSachPhieuChi;
        }

        public List<PhieuChi> TaiDanhSachPhieuChiTheoNgayChi(string NgayBD, string NgayKT)
        {
            List<PhieuChi> danhSachPhieuChi = new List<PhieuChi>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from tblPhieuChi where NgayChi between '{0}' and '{1}'", NgayBD, NgayKT));

            foreach (DataRow item in data.Rows)
            {
                PhieuChi phieuChi = new PhieuChi(item);
                danhSachPhieuChi.Add(phieuChi);
            }

            return danhSachPhieuChi;
        }

        public decimal TongTienPhieuChi(int MaPN)
        {
            PhieuChi.ThanhTien =  (decimal)DataProvider.Instance.ExecuteScalar("exec pn_tongtien " + MaPN);

            return PhieuChi.ThanhTien;
        }

        public bool ThemPhieuChi(int MaND, int MaPN)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("insert into tblPhieuChi (MaND, MaPN) values ({0}, {1})", MaND, MaPN));

            return result > 0;
        }

        public DataTable ListToDataTable(List<PhieuChi> PhieuChis)
        {

            DataTable data = new DataTable(typeof(PhieuChi).Name);
            PropertyInfo[] Props = typeof(PhieuChi).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (PhieuChi item in PhieuChis)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);

                }
                data.Rows.Add(values);
            }
            return data;
        }
    }
}
