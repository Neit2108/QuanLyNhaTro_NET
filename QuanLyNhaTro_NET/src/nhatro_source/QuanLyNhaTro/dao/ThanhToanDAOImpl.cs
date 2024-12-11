using System;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class ThanhToanDAOImpl : IThanhToanDAO
    {
        private readonly SqlConnection _connection;

        public ThanhToanDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            _connection.Open();
        }

        public void AddThanhToan(int maHoaDon, double soTien, string hinhThuc, string trangThai)
        {
            string query = "INSERT INTO ThanhToan(maHoaDon, soTien, hinhThucThanhToan, trangThai) VALUES(@MaHoaDon, @SoTien, @HinhThuc, @TrangThai)";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmd.Parameters.AddWithValue("@SoTien", soTien);
                        cmd.Parameters.AddWithValue("@HinhThuc", hinhThuc);
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Error adding ThanhToan", e);
                }
            }
        }
    }
}