using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class KieuPhongDAOImpl : IKieuPhongDAO
    {
        private readonly SqlConnection _connection;

        public KieuPhongDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            
        }

        public void AddKieuPhong(string loaiPhong, double dienTich, double giaPhong)
        {
            string query = "INSERT INTO KieuPhong(loaiPhong, dienTich, giaPhong) VALUES(@loaiPhong, @dienTich, @giaPhong)";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@loaiPhong", loaiPhong);
                cmd.Parameters.AddWithValue("@dienTich", dienTich);
                cmd.Parameters.AddWithValue("@giaPhong", giaPhong);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateKieuPhong(int maKieuPhong, string loaiPhong, double dienTich, double giaPhong)
        {
            string query = "UPDATE KieuPhong SET loaiPhong = @loaiPhong, dienTich = @dienTich, giaPhong = @giaPhong WHERE maKieuPhong = @maKieuPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maKieuPhong", maKieuPhong);
                cmd.Parameters.AddWithValue("@loaiPhong", loaiPhong);
                cmd.Parameters.AddWithValue("@dienTich", dienTich);
                cmd.Parameters.AddWithValue("@giaPhong", giaPhong);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteKieuPhong(int maKieuPhong)
        {
            string query = "DELETE FROM KieuPhong WHERE maKieuPhong = @maKieuPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maKieuPhong", maKieuPhong);
                cmd.ExecuteNonQuery();
            }
        }

        public KieuPhong GetKieuPhong(int maKieuPhong)
        {
            string query = "SELECT * FROM KieuPhong WHERE maKieuPhong = @maKieuPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maKieuPhong", maKieuPhong);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new KieuPhong
                        {
                            MaKieuPhong = reader.GetInt32("maKieuPhong"),
                            LoaiPhong = reader.GetString("loaiPhong"),
                            DienTich = Convert.ToDouble(reader.GetDecimal("dienTich")),
                            GiaPhong = Convert.ToDouble(reader.GetDecimal("giaPhong")),
                            NgayTao = reader.GetDateTime("ngayTao")
                        };
                    }
                }
            }
            return null;
        }

        public List<KieuPhong> GetAllKieuPhong()
        {
            var kieuPhongList = new List<KieuPhong>();
            string query = "SELECT * FROM KieuPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var kieuPhong = new KieuPhong
                        {
                            MaKieuPhong = reader.GetInt32("maKieuPhong"),
                            LoaiPhong = reader.GetString("loaiPhong"),
                            DienTich = reader.GetDouble("dienTich"),
                            GiaPhong = reader.GetDouble("giaPhong"),
                            NgayTao = reader.GetDateTime("ngayTao")
                        };
                        kieuPhongList.Add(kieuPhong);
                    }
                }
            }
            return kieuPhongList;
        }
    }
}