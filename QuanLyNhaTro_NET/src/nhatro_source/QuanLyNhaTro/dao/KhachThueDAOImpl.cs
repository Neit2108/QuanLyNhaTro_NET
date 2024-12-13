using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class KhachThueDAOImpl : IKhachThueDAO
    {
        private readonly SqlConnection _connection;

        public KhachThueDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            
        }

        public List<KhachThue> GetAllKhachThue()
        {
            var khachThueList = new List<KhachThue>();
            string query = "select * from KhachThue";
            using (var cmd = new SqlCommand(query, _connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var khachThue = new KhachThue
                        {
                            MaKhach = reader.GetInt32("maKhachThue"),
                            MaCCCD = reader.GetString("maCCCD"),
                            Ten = reader.GetString("tenKhach"),
                            NgaySinh = reader.GetDateTime("ngaySinh"),
                            GioiTinh = reader.GetString("gioiTinh"),
                            SoDienThoai = reader.GetString("soDienThoai"),
                            DiaChi = reader.GetString("diaChi"),
                            MaTaiKhoan = reader.GetInt32("maTaiKhoan")
                        };
                        khachThueList.Add(khachThue);
                    }
                }
            }
            return khachThueList;
        }

        public KhachThue GetKhachThue(string maCCCD)
        {
            var khachThue = new KhachThue();
            string query = "select * from KhachThue where maCCCD = @maCCCD";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maCCCD", maCCCD);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        khachThue.MaKhach = reader.GetInt32("maKhachThue");
                        khachThue.MaCCCD = reader.GetString("maCCCD");
                        khachThue.Ten = reader.GetString("tenKhach");
                        khachThue.NgaySinh = reader.GetDateTime("ngaySinh");
                        khachThue.GioiTinh = reader.GetString("gioiTinh");
                        khachThue.SoDienThoai = reader.GetString("soDienThoai");
                        khachThue.DiaChi = reader.GetString("diaChi");
                        khachThue.MaTaiKhoan = reader.GetInt32("maTaiKhoan");
                    }
                }
            }
            return khachThue;
        }

        public KhachThue GetKhachThue(int maTaiKhoan)
        {
            var khachThue = new KhachThue();
            string query = "select * from KhachThue where maTaiKhoan = @maTaiKhoan";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        khachThue.MaKhach = reader.GetInt32("maKhachThue");
                        khachThue.MaCCCD = reader.GetString("maCCCD");
                        khachThue.Ten = reader.GetString("tenKhach");
                        khachThue.NgaySinh = reader.GetDateTime("ngaySinh");
                        khachThue.GioiTinh = reader.GetString("gioiTinh");
                        khachThue.SoDienThoai = reader.GetString("soDienThoai");
                        khachThue.DiaChi = reader.GetString("diaChi");
                        khachThue.MaTaiKhoan = reader.GetInt32("maTaiKhoan");
                    }
                }
            }
            return khachThue;
        }

        public void AddKhachThue(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan)
        {
            string query = "insert into KhachThue(maCCCD, tenKhach, ngaySinh, gioiTinh, soDienThoai, diaChi, maTaiKhoan) values(@maCCCD, @ten, @ngaySinh, @gioiTinh, @soDienThoai, @diaChi, @maTaiKhoan)";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maCCCD", maCCCD);
                        cmd.Parameters.AddWithValue("@ten", ten);
                        cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@diaChi", diaChi);
                        cmd.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Thêm không thành công", e);
                }
            }
        }

        public void UpdateKhachThue(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan)
        {
            string query = "update KhachThue set tenKhach = @ten, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, soDienThoai = @soDienThoai, diaChi = @diaChi, maTaiKhoan = @maTaiKhoan where maCCCD = @maCCCD";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ten", ten);
                        cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@diaChi", diaChi);
                        cmd.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                        cmd.Parameters.AddWithValue("@maCCCD", maCCCD);

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Chỉnh sửa không thành công", e);
                }
            }
        }

        public void DeleteKhachThue(string maCCCD)
        {
            string query = "delete from KhachThue where maCCCD = @maCCCD";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maCCCD", maCCCD);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Xóa không thành công", e);
                }
            }
        }

        public List<KhachThue> GetKhachThueByMaChuNha(int maChuNha)
        {
            var khachThueList = new List<KhachThue>();
            string query = "SELECT DISTINCT KT.* " +
                           "FROM ChuNha CN " +
                           "JOIN NhaTro NT ON CN.maChuNha = NT.maChuNha " +
                           "JOIN Phong P ON NT.maNhaTro = P.maNhaTro " +
                           "JOIN HopDong HD ON P.maPhong = HD.maPhong " +
                           "JOIN KhachThue KT ON HD.maKhachThue = KT.maKhachThue " +
                           "WHERE CN.maChuNha = @maChuNha";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maChuNha", maChuNha);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var khachThue = new KhachThue
                        {
                            MaKhach = reader.GetInt32("maKhachThue"),
                            MaCCCD = reader.GetString("maCCCD"),
                            Ten = reader.GetString("tenKhach"),
                            NgaySinh = reader.GetDateTime("ngaySinh"),
                            GioiTinh = reader.GetString("gioiTinh"),
                            SoDienThoai = reader.GetString("soDienThoai"),
                            DiaChi = reader.GetString("diaChi"),
                            MaTaiKhoan = reader.GetInt32("maTaiKhoan")
                        };
                        khachThueList.Add(khachThue);
                    }
                }
            }
            return khachThueList;
        }
    }
}