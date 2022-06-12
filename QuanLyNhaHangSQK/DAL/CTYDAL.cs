using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class CTYDAL
    {
        SqlConnection connect = new SqlConnection(DataProvider.connectionSTR);
        private static CTYDAL instance;

        public static CTYDAL Instance 
        { 
            get { if (instance == null) instance = new CTYDAL(); return instance; } 
            private set => instance = value; 
        }

        private CTYDAL() { }

        public CTY TaiThongTinCTYTheoMa(int MaCTY)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblCTY where MaCTY = " + MaCTY);

            foreach (DataRow item in data.Rows)
            {
                return new CTY(item);
            }

            return null;
        }

        public List<CTY> TaiDanhSachCTY()
        {
            List<CTY> danhSachCTY = new List<CTY>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblCTY");

            foreach (DataRow item in data.Rows)
            {
                CTY cTY = new CTY(item);
                danhSachCTY.Add(cTY);
            }

            return danhSachCTY;
        }

        public CTY TaiThongTinCTY()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblCTY");

            foreach (DataRow item in data.Rows)
            {
                return new CTY(item);
            }

            return null;
        }

        public void CapNhatCTY(int MaCTY,string TenCTY,string TenVietTat,string SoLuoc,string TenNH,string SoTKNH,string DienThoai,string Email,string Website,string DiaChi,byte[] Img)
        {
            using (var cmd = new SqlCommand("update tblCTY set TenCTY = @TenCTY, TenVietTat = @TenVietTat, SoLuoc = @SoLuoc, TenNH = @TenNH, SoTKNH = @SoTKNH, DienThoaiCTY = @DienThoai, Email = @Email, Website = @Website, DiaChi = @DiaChi, Logo = @Logo where MaCTY = " + MaCTY))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@TenCTY", TenCTY);
                cmd.Parameters.AddWithValue("@TenVietTat", TenVietTat);
                cmd.Parameters.AddWithValue("@SoLuoc", SoLuoc);
                cmd.Parameters.AddWithValue("@TenNH", TenNH);
                cmd.Parameters.AddWithValue("@SoTKNH", SoTKNH);
                cmd.Parameters.AddWithValue("@DienThoai", DienThoai);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Website", Website);
                cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                cmd.Parameters.AddWithValue("@Logo", Img);
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public byte[] TaiAnhLen(int MaCTY)
        {
            return (byte[])DataProvider.Instance.ExecuteScalar("Select Logo from tblCTY where MaCTY = " + MaCTY);
        }
    }
}
