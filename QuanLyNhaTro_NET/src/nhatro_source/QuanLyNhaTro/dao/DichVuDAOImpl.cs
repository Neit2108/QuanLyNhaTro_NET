using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class DichVuDAOImpl : IDichVuDAO
    {
        private readonly SqlConnection _connection;

        public DichVuDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            _connection.Open();
        }

        public void AddDichVu(int maDichVu, string tenDichVu, string trangThai)
        {
            // Implementation needed
        }

        public void UpdateDichVu(int maDichVu, string tenDichVu, string trangThai)
        {
            // Implementation needed
        }

        public void DeleteDichVu(int maDichVu)
        {
            // Implementation needed
        }

        public DichVu GetDichVu(int maDichVu)
        {
            string query = "select * from DichVu where maDichVu = @maDichVu";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maDichVu", maDichVu);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DichVu(
                            reader.GetInt32("maDichVu"),
                            reader.GetString("tenDichVu"),
                            reader.GetInt32("giaDichVu"),
                            reader.GetString("trangThai")
                        );
                    }
                }
            }
            return null;
        }

        public List<DichVu> GetAllDichVu()
        {
            return new List<DichVu>();
        }
    }
}