using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class AdminDAOImpl : AbstractDAO, IAdminDAO
    {
        private readonly SqlConnection _conn;

        public AdminDAOImpl()
        {
            _conn = DatabaseConnection.GetConnection();
            _conn.Open();
        }

        public void AddAdmin(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan)
        {
            string sql = "INSERT INTO admin(maCCCD, tenAdmin, ngaySinh, gioiTinh, soDienThoai, diaChi, maTaiKhoan) VALUES(@maCCCD, @ten, @ngaySinh, @gioiTinh, @soDienThoai, @diaChi, @maTaiKhoan)";
            InsertPerson(_conn, sql, maCCCD, ten, ngaySinh, gioiTinh, soDienThoai, diaChi, maTaiKhoan);
        }

        public List<Admin> GetAllAdmins()
        {
            var admins = new List<Admin>();
            string sql = "SELECT * FROM admin";
            using (var cmd = new SqlCommand(sql, _conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var admin = new Admin
                        {
                            MaAdmin = reader.GetInt32("maAdmin"),
                            MaCCCD = reader.GetString("maCCCD"),
                            Ten = reader.GetString("tenAdmin"),
                            GioiTinh = reader.GetString("gioiTinh"),
                            NgaySinh = reader.GetDateTime("ngaySinh"),
                            SoDienThoai = reader.GetString("soDienThoai"),
                            DiaChi = reader.GetString("diaChi"),
                            MaTaiKhoan = reader.GetInt32("maTaiKhoan")
                        };
                        admins.Add(admin);
                    }
                }
            }
            return admins;
        }

        public Admin GetAdmin(string maCCCD)
        {
            string query = "SELECT * FROM admin WHERE maCCCD = @maCCCD";
            using (var cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@maCCCD", maCCCD);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Admin
                        {
                            MaAdmin = reader.GetInt32("maAdmin"),
                            MaCCCD = reader.GetString("maCCCD"),
                            Ten = reader.GetString("tenAdmin"),
                            GioiTinh = reader.GetString("gioiTinh"),
                            NgaySinh = reader.GetDateTime("ngaySinh"),
                            SoDienThoai = reader.GetString("soDienThoai"),
                            DiaChi = reader.GetString("diaChi"),
                            MaTaiKhoan = reader.GetInt32("maTaiKhoan")
                        };
                    }
                }
            }
            return null;
        }

        public void UpdateAdmin(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maAdmin, int maTaiKhoan)
        {
            string sql = "UPDATE admin SET maCCCD = @maCCCD, tenAdmin = @ten, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, soDienThoai = @soDienThoai, diaChi = @diaChi, maTaiKhoan = @maTaiKhoan WHERE maAdmin = @maAdmin";
            UpdatePerson(_conn, sql, maCCCD, ten, ngaySinh, gioiTinh, soDienThoai, diaChi, maAdmin, maTaiKhoan);
        }

        public void DeleteAdmin(string maCCCD)
        {
            string sql = "DELETE FROM admin WHERE maCCCD = @maCCCD";
            using (var transaction = _conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(sql, _conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maCCCD", maCCCD);
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while deleting an admin", e);
                }
            }
        }
    }
}