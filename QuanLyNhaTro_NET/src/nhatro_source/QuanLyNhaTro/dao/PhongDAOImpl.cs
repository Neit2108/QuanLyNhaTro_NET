using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class PhongDAOImpl : IPhongDAO
    {
        private readonly SqlConnection _connection;

        public PhongDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            _connection.Open();
        }

        public void AddPhong(string tenPhong, int maKieuPhong, int maNhaTro, string urlImage)
        {
            string query = "INSERT INTO Phong(tenPhong, maKieuPhong, maNhaTro, trangThai, urlImage) VALUES(@tenPhong, @maKieuPhong, @maNhaTro, @trangThai, @urlImage)";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@tenPhong", tenPhong);
                cmd.Parameters.AddWithValue("@maKieuPhong", maKieuPhong);
                cmd.Parameters.AddWithValue("@maNhaTro", maNhaTro);
                cmd.Parameters.AddWithValue("@trangThai", "Chưa thuê");
                cmd.Parameters.AddWithValue("@urlImage", urlImage);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePhong(int maPhong, string tenPhong, int maKieuPhong, int maNhaTro, string urlImage)
        {
            string query = "UPDATE Phong SET tenPhong = @tenPhong, maKieuPhong = @maKieuPhong, maNhaTro = @maNhaTro, urlImage = @urlImage WHERE maPhong = @maPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@tenPhong", tenPhong);
                cmd.Parameters.AddWithValue("@maKieuPhong", maKieuPhong);
                cmd.Parameters.AddWithValue("@maNhaTro", maNhaTro);
                cmd.Parameters.AddWithValue("@urlImage", urlImage);
                cmd.Parameters.AddWithValue("@maPhong", maPhong);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePhong(int maPhong)
        {
            string query = "DELETE FROM Phong WHERE maPhong = @maPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maPhong", maPhong);
                cmd.ExecuteNonQuery();
            }
        }

        public Phong GetPhong(int maPhong)
        {
            string query = "SELECT * FROM Phong WHERE maPhong = @maPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maPhong", maPhong);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Phong
                        {
                            MaPhong = reader.GetInt32("maPhong"),
                            TenPhong = reader.GetString("tenPhong"),
                            MaKieuPhong = reader.GetInt32("maKieuPhong"),
                            MaNhaTro = reader.GetInt32("maNhaTro"),
                            TrangThai = reader.GetString("trangThai"),
                            UrlImage = reader.GetString("urlImage")
                        };
                    }
                }
            }
            return null;
        }

        public List<Phong> GetAllPhong()
        {
            var phongs = new List<Phong>();
            string query = "SELECT * FROM Phong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        phongs.Add(new Phong
                        {
                            MaPhong = reader.GetInt32("maPhong"),
                            TenPhong = reader.GetString("tenPhong"),
                            MaKieuPhong = reader.GetInt32("maKieuPhong"),
                            MaNhaTro = reader.GetInt32("maNhaTro"),
                            TrangThai = reader.GetString("trangThai"),
                            UrlImage = reader.GetString("urlImage")
                        });
                    }
                }
            }
            return phongs;
        }

        public List<Phong> GetAllPhongByMaNhaTro(int maNhaTro)
        {
            var phongs = new List<Phong>();
            string query = "SELECT * FROM Phong WHERE maNhaTro = @maNhaTro";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maNhaTro", maNhaTro);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        phongs.Add(new Phong
                        {
                            MaPhong = reader.GetInt32("maPhong"),
                            TenPhong = reader.GetString("tenPhong"),
                            MaKieuPhong = reader.GetInt32("maKieuPhong"),
                            MaNhaTro = reader.GetInt32("maNhaTro"),
                            TrangThai = reader.GetString("trangThai"),
                            UrlImage = reader.GetString("urlImage")
                        });
                    }
                }
            }
            return phongs;
        }

        public double GetGiaPhong(int maPhong)
        {
            string query = "SELECT * FROM PhongView WHERE maPhong = @maPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maPhong", maPhong);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetDouble("giaPhong");
                    }
                }
            }
            return -1;
        }

        public int GetMaChuNha(int maPhong)
        {
            string query = "SELECT maChuNha FROM Phong JOIN NhaTro ON Phong.maNhaTro = NhaTro.maNhaTro WHERE maPhong = @maPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maPhong", maPhong);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32("maChuNha");
                    }
                }
            }
            return -1;
        }

        public void UpdateTrangThaiPhong(int maPhong, string trangThai)
        {
            string query = "UPDATE Phong SET trangThai = @trangThai WHERE maPhong = @maPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@trangThai", trangThai);
                cmd.Parameters.AddWithValue("@maPhong", maPhong);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Phong> GetAllPhongByMaKhach(int maKhach)
        {
            var phongs = new List<Phong>();
            string query = "SELECT * FROM Phong p JOIN HopDong hd ON hd.maPhong = p.maPhong JOIN KhachThue kt ON kt.maKhachThue = hd.maKhachThue WHERE kt.maKhachThue = @maKhach";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maKhach", maKhach);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        phongs.Add(new Phong
                        {
                            MaPhong = reader.GetInt32("maPhong"),
                            TenPhong = reader.GetString("tenPhong"),
                            MaKieuPhong = reader.GetInt32("maKieuPhong"),
                            MaNhaTro = reader.GetInt32("maNhaTro"),
                            TrangThai = reader.GetString("trangThai"),
                            UrlImage = reader.GetString("urlImage")
                        });
                    }
                }
            }
            return phongs;
        }

        public void UpdateTrangThaiPhong(int maPhong)
        {
            string query = "UPDATE Phong SET trangThai = N'Đã thuê' WHERE maPhong = @maPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maPhong", maPhong);
                cmd.ExecuteNonQuery();
            }
        }

    }
}