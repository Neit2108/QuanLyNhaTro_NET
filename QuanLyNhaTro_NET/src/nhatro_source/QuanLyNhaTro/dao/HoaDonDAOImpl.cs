using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class HoaDonDAOImpl : IHoaDonDAO
    {
        private readonly SqlConnection _conn;

        public HoaDonDAOImpl()
        {
            _conn = DatabaseConnection.GetConnection();
            _conn.Open();
        }

        public List<HoaDon> GetAllHoaDon()
        {
            var hoaDonList = new List<HoaDon>();
            string query = "SELECT * FROM HoaDon";
            using (var cmd = new SqlCommand(query, _conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hoaDon = new HoaDon
                        {
                            MaHoaDon = reader.GetInt32("maHoaDon"),
                            MaHopDong = reader.GetInt32("maHopDong"),
                            TongTien = reader.GetDouble("tongTien"),
                            NgayTao = reader.GetDateTime("ngayTao"),
                            NgayThanhToan = (DateTime)(reader.IsDBNull(reader.GetOrdinal("ngayThanhToan")) ? (DateTime?)null : reader.GetDateTime("ngayThanhToan")),
                            TrangThai = reader.GetString("trangThai")
                        };
                        hoaDonList.Add(hoaDon);
                    }
                }
            }
            return hoaDonList;
        }

        public List<HoaDon> GetHoaDonByMaKhach(int maKhach)
        {
            var hoaDonList = new List<HoaDon>();
            string query = "select * from HoaDon " +
                           "join dbo.HopDong HD on HoaDon.maHopDong = HD.maHopDong " +
                           "join dbo.KhachThue KT on HD.maKhachThue = KT.maKhachThue " +
                           "where HD.maKhachThue = @maKhach";
            using (var cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@maKhach", maKhach);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hoaDon = new HoaDon
                        {
                            MaHoaDon = reader.GetInt32("maHoaDon"),
                            MaHopDong = reader.GetInt32("maHopDong"),
                            TongTien = reader.GetDouble("tongTien"),
                            NgayTao = reader.GetDateTime("ngayTao"),
                            NgayThanhToan = (DateTime)(reader.IsDBNull(reader.GetOrdinal("ngayThanhToan")) ? (DateTime?)null : reader.GetDateTime("ngayThanhToan")),
                            TrangThai = reader.GetString("trangThai")
                        };
                        hoaDonList.Add(hoaDon);
                    }
                }
            }
            return hoaDonList;
        }

        public List<HoaDon> GetHoaDonByMaNhaTro(int maNhaTro)
        {
            var hoaDonList = new List<HoaDon>();
            string query = "select * from HoaDon " +
                           "join HopDong hd on HoaDon.maHopDong = hd.maHopDong " +
                           "join Phong p on p.maPhong = hd.maPhong " +
                           "where p.maNhaTro = @maNhaTro";
            using (var cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@maNhaTro", maNhaTro);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hoaDon = new HoaDon
                        {
                            MaHoaDon = reader.GetInt32("maHoaDon"),
                            MaHopDong = reader.GetInt32("maHopDong"),
                            TongTien = reader.GetDouble("tongTien"),
                            NgayTao = reader.GetDateTime("ngayTao"),
                            NgayThanhToan = (DateTime)(reader.IsDBNull(reader.GetOrdinal("ngayThanhToan")) ? (DateTime?)null : reader.GetDateTime("ngayThanhToan")),
                            TrangThai = reader.GetString("trangThai")
                        };
                        hoaDonList.Add(hoaDon);
                    }
                }
            }
            return hoaDonList;
        }

        public bool IsCreatedHoaDon(DateTime date)
        {
            int result = 0;
            string query = "{call sp_KiemTraHoaDonThang(?)}";
            using (var cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@date", date);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = reader.GetInt32("HoaDonDaTao");
                    }
                }
            }
            return result > 0;
        }

        public void AutoCreateHoaDon(int maChuNha, DateTime date)
        {
            string query1 = "{call sp_TaoHoaDonTuDong(?, ?)}";
            string query2 = "{call sp_ThemTienDienNuocTuDong(?)}";

            using (var transaction = _conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query1, _conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@maChuNha", maChuNha);
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new SqlCommand(query2, _conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maChuNha", maChuNha);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while auto creating HoaDon", e);
                }
            }
        }

        public void DeleteHoaDon(int maHoaDon)
        {
            string sql = "BEGIN TRANSACTION; " +
                         "DELETE FROM ChiTiet_DichVu WHERE maChiTiet IN (" +
                         "    SELECT maChiTiet FROM ChiTietHoaDon WHERE maHoaDon = @maHoaDon);" +
                         "DELETE FROM ChiTiet_CSVC WHERE maChiTiet IN (" +
                         "    SELECT maChiTiet FROM ChiTietHoaDon WHERE maHoaDon = @maHoaDon);" +
                         "DELETE FROM ChiTietHoaDon WHERE maHoaDon = @maHoaDon;" +
                         "DELETE FROM HoaDon WHERE maHoaDon = @maHoaDon;" +
                         "COMMIT TRANSACTION;";
            using (var cmd = new SqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@maHoaDon", maHoaDon);
                cmd.ExecuteNonQuery();
            }
        }
    }
}