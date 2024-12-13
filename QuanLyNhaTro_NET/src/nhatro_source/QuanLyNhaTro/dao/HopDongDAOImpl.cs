using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class HopDongDAOImpl : IHopDongDAO
    {
        private readonly SqlConnection _conn;

        public HopDongDAOImpl()
        {
            _conn = DatabaseConnection.GetConnection();
            
        }

        public void AddHopDong(int maPhong, int maKhachThue, double tienCoc, DateTime ngayThue, int thoiHanHopDong, string trangThai, int soNguoi)
        {
            string query = "insert into HopDong(maPhong, maKhachThue, tienCoc, soNguoi, ngayThue, thoiHanHopDong, trangThai) values(@maPhong, @maKhachThue, @tienCoc, @soNguoi, @ngayThue, @thoiHanHopDong, @trangThai)";
            using (var transaction = _conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maPhong", maPhong);
                        cmd.Parameters.AddWithValue("@maKhachThue", maKhachThue);
                        cmd.Parameters.AddWithValue("@tienCoc", tienCoc);
                        cmd.Parameters.AddWithValue("@soNguoi", soNguoi);
                        cmd.Parameters.AddWithValue("@ngayThue", ngayThue);
                        cmd.Parameters.AddWithValue("@thoiHanHopDong", thoiHanHopDong);
                        cmd.Parameters.AddWithValue("@trangThai", trangThai);

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public HopDong GetHopDong(int maHopDong)
        {
            string query = "select * from HopDong where maHopDong = @maHopDong";
            using (var cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@maHopDong", maHopDong);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new HopDong(
                            reader.GetInt32("maHopDong"),
                            reader.GetInt32("maPhong"),
                            reader.GetInt32("maKhachThue"),
                            Convert.ToDouble(reader.GetDecimal("tienCoc")),
                            reader.GetInt32("soNguoi"),
                            reader.GetDateTime("ngayThue"),
                            reader.GetInt32("thoiHanHopDong"),
                            reader.GetDateTime("ngayTao"),
                            reader.GetString("trangThai")
                        );
                    }
                }
            }
            return null;
        }

        public List<HopDong> GetAllHopDong()
        {
            var hopDongList = new List<HopDong>();
            string query = "select * from HopDong";
            using (var cmd = new SqlCommand(query, _conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hd = new HopDong(
                            reader.GetInt32("maHopDong"),
                            reader.GetInt32("maPhong"),
                            reader.GetInt32("maKhachThue"),
                            Convert.ToDouble(reader.GetDecimal("tienCoc")),
                            reader.GetInt32("soNguoi"),
                            reader.GetDateTime("ngayThue"),
                            reader.GetInt32("thoiHanHopDong"),
                            reader.GetDateTime("ngayTao"),
                            reader.GetString("trangThai")
                        );
                        hopDongList.Add(hd);
                    }
                }
            }
            return hopDongList;
        }

        public List<HopDong> GetHopDongByMaKhach(int maKhach)
        {
            var hopDongList = new List<HopDong>();
            string query = "select * from HopDong where maKhachThue = @maKhach";
            using (var cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@maKhach", maKhach);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hd = new HopDong(
                            reader.GetInt32("maHopDong"),
                            reader.GetInt32("maPhong"),
                            reader.GetInt32("maKhachThue"),
                            Convert.ToDouble(reader.GetDecimal("tienCoc")),
                            reader.GetInt32("soNguoi"),
                            reader.GetDateTime("ngayThue"),
                            reader.GetInt32("thoiHanHopDong"),
                            reader.GetDateTime("ngayTao"),
                            reader.GetString("trangThai")
                        );
                        hopDongList.Add(hd);
                    }
                }
            }
            return hopDongList;
        }

        public List<HopDong> GetHopDongByMaChuNha(int maChuNha)
        {
            var hopDongList = new List<HopDong>();
            string query = "SELECT HD.* " +
                           "FROM HopDong HD " +
                           "JOIN Phong P ON HD.maPhong = P.maPhong " +
                           "JOIN NhaTro NT ON P.maNhaTro = NT.maNhaTro " +
                           "WHERE NT.maChuNha = @maChuNha";
            using (var cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@maChuNha", maChuNha);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hd = new HopDong(
                            reader.GetInt32("maHopDong"),
                            reader.GetInt32("maPhong"),
                            reader.GetInt32("maKhachThue"),
                            Convert.ToDouble(reader.GetDecimal("tienCoc")),
                            reader.GetInt32("soNguoi"),
                            reader.GetDateTime("ngayThue"),
                            reader.GetInt32("thoiHanHopDong"),
                            reader.GetDateTime("ngayTao"),
                            reader.GetString("trangThai")
                        );
                        hopDongList.Add(hd);
                    }
                }
            }
            return hopDongList;
        }
    }
}