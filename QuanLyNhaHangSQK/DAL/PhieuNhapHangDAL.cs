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
    public class PhieuNhapHangDAL
    {
        private static PhieuNhapHangDAL instance;

        public static PhieuNhapHangDAL Instance 
        {
            get { if (instance == null) instance = new PhieuNhapHangDAL(); return instance; }
            private set => instance = value; 
        }

        private PhieuNhapHangDAL() { }

        public List<PhieuNhapHang> TaiDanhSachPhieuNhap()
        {
            List<PhieuNhapHang> danhSachPhieuNhap = new List<PhieuNhapHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblPhieuNhapHang where TinhTrang = 0");

            foreach (DataRow item in data.Rows)
            {
                PhieuNhapHang phieuNhapHang = new PhieuNhapHang(item);
                danhSachPhieuNhap.Add(phieuNhapHang);
            }

            return danhSachPhieuNhap;
        }

        public List<PhieuNhapHang> TaiDanhSachPhieuNhapTheoMa(int MaPN)
        {
            List<PhieuNhapHang> danhSachPhieuNhap = new List<PhieuNhapHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblPhieuNhapHang where dbo.fuConvertToUnsign1(MaPN) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", MaPN));

            foreach (DataRow item in data.Rows)
            {
                PhieuNhapHang phieuNhapHang = new PhieuNhapHang(item);
                danhSachPhieuNhap.Add(phieuNhapHang);
            }

            return danhSachPhieuNhap;
        }

        public List<PhieuNhapHang> TaiDanhSachPhieuNhapTheoNCC(string MaNCC)
        {
            List<PhieuNhapHang> danhSachPhieuNhap = new List<PhieuNhapHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblPhieuNhapHang where dbo.fuConvertToUnsign1(MaNCC) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", MaNCC));

            foreach (DataRow item in data.Rows)
            {
                PhieuNhapHang phieuNhapHang = new PhieuNhapHang(item);
                danhSachPhieuNhap.Add(phieuNhapHang);
            }

            return danhSachPhieuNhap;
        }

        public List<PhieuNhapHang> TaiDanhSachPhieuNhapTheoNgayLap(string NgayBD, string NgayKT)
        {
            List<PhieuNhapHang> danhSachPhieuNhap = new List<PhieuNhapHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from tblPhieuNhapHang where NgayLap between '{0}' and '{1}'", NgayBD, NgayKT));

            foreach (DataRow item in data.Rows)
            {
                PhieuNhapHang phieuNhapHang = new PhieuNhapHang(item);
                danhSachPhieuNhap.Add(phieuNhapHang);
            }

            return danhSachPhieuNhap;
        }

        public List<PhieuNhapHang> TaiDanhSachPhieuNhapTheoNgayNhap(string NgayBD, string NgayKT)
        {
            List<PhieuNhapHang> danhSachPhieuNhap = new List<PhieuNhapHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from tblPhieuNhapHang where NgayNhapHang between '{0}' and '{1}'", NgayBD, NgayKT));

            foreach (DataRow item in data.Rows)
            {
                PhieuNhapHang phieuNhapHang = new PhieuNhapHang(item);
                danhSachPhieuNhap.Add(phieuNhapHang);
            }

            return danhSachPhieuNhap;
        }

        public string LayMaNCCTheoMaPN(int MaPN)
        {
            return (string)DataProvider.Instance.ExecuteScalar("select MaNCC from tblPhieuNhapHang where MaPN = " + MaPN);
        }

        public bool ThemPhieuNhap(string MaNCC, int MaND, string NgayNhap)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("Insert into tblPhieuNhapHang (MaNCC, MaND, NgayLap, NgayNhapHang) values ('{0}', {1}, Getdate(), '{2}')", MaNCC, MaND, NgayNhap));

            return result > 0;
        }

        public bool SuaPhieuNhap(int MaPN)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("update tblPhieuNhapHang set TinhTrang = 1 where MaPN = " + MaPN));
            return result > 0;
        }

        public int LayMaPNLonNhat()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("Select MAX(MaPN) from tblPhieuNhapHang");
            }
            catch
            {
                return 1;
            }
        }

        public DataTable ListToDataTable(List<PhieuNhapHang> PhieuNhapHangs)
        {

            DataTable data = new DataTable(typeof(PhieuNhapHang).Name);
            PropertyInfo[] Props = typeof(PhieuNhapHang).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (PhieuNhapHang item in PhieuNhapHangs)
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
