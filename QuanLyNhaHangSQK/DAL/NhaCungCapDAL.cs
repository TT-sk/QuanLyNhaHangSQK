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
    public class NhaCungCapDAL
    {
        private static NhaCungCapDAL instance;

        public static NhaCungCapDAL Instance 
        { 
            get { if (instance == null) instance = new NhaCungCapDAL(); return instance; }
            private set => instance = value; 
        }

        public NhaCungCap TaiNhaCungCapTheoMa(string MaNCC)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from tblNhaCungCap where MaNCC = N'{0}'", MaNCC));

            foreach (DataRow item in data.Rows)
            {
                return new NhaCungCap(item);
            }
            return null;
        }

        public List<NhaCungCap> TaiDanhSachNhaCungCap()
        {
            List<NhaCungCap> danhSachNCC = new List<NhaCungCap>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from tblNhaCungCap"));

            foreach (DataRow item in data.Rows)
            {
                NhaCungCap nhaCungCap = new NhaCungCap(item);
                danhSachNCC.Add(nhaCungCap);
            }
            return danhSachNCC;
        }

        public bool ThemNCC(string MaNCC, string TenNCC, string DienThoai, string DiaChi)
        {
            int ressult = DataProvider.Instance.ExcuteNonQuery(string.Format("insert into tblNhaCungCap (MaNCC, TenNCC, DienThoaiNCC, DiaChiNCC) values ('{0}', N'{1}', '{2}', N'{3}')", MaNCC, TenNCC, DienThoai, DiaChi));

            return ressult > 0;
        }

        public bool XoaNhaCungCap(string MaNCC)
        {
            int ressult = DataProvider.Instance.ExcuteNonQuery(string.Format("delete tblNhaCungCap where MaNCC = '{0}'", MaNCC));

            return ressult > 0;
        }

        public bool SuaNCC(string MaNCC, string TenNCC, string DienThoai, string DiaChi)
        {
            int ressult = DataProvider.Instance.ExcuteNonQuery(string.Format("update tblNhaCungCap set TenNCC = N'{0}', DienThoaiNCC = '{1}', DiaChiNCC = N'{2}' where MaNCC = '{3}'", TenNCC, DienThoai, DiaChi, MaNCC));

            return ressult > 0;
        }

        public List<NhaCungCap> TaiNhaCungCapTheoTimKiem(string TenNCC)
        {
            List<NhaCungCap> danhSachNCC = new List<NhaCungCap>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblNhaCungCap where dbo.fuConvertToUnsign1(TenNCC) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", TenNCC));

            foreach (DataRow item in data.Rows)
            {
                NhaCungCap nhaCungCap = new NhaCungCap(item);
                danhSachNCC.Add(nhaCungCap);
            }

            return danhSachNCC;
        }

        public DataTable ListToDataTable(List<NhaCungCap> NhaCungCaps)
        {

            DataTable data = new DataTable(typeof(NhaCungCap).Name);
            PropertyInfo[] Props = typeof(NhaCungCap).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (NhaCungCap item in NhaCungCaps)
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
