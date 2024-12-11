using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class ChuNhaDAOImpl : IChuNhaDAO
    {
        private readonly SqlConnection _connection;

        public ChuNhaDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            _connection.Open();
        }

        public void AddChuNha(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan)
        {
            string query = "INSERT INTO ChuNha(maCCCD, tenChuNha, ngaySinh, gioiTinh, soDienThoai, diaChi, maTaiKhoan) VALUES(@maCCCD, @ten, @ngaySinh, @gioiTinh, @soDienThoai, @diaChi, @maTaiKhoan)";
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
                        transaction.Commit();
                    }
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while adding a ChuNha", e);
                }
            }
        }

        public ChuNha GetChuNhaByMa(int maChuNha)
        {
            string query = "SELECT * FROM ChuNha WHERE maChuNha = @maChuNha";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maChuNha", maChuNha);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ChuNha( 
                            reader.GetString("maCCCD"),
                            reader.GetString("tenChuNha"),
                            reader.GetDateTime("ngaySinh"),
                            reader.GetString("gioiTinh"),
                            reader.GetString("soDienThoai"),
                            reader.GetString("diaChi"),
                            reader.GetInt32("maChuNha"),
                            reader.GetInt32("maTaiKhoan")
                        );
                    }
                }
            }
            return null;
        }

        public ChuNha GetChuNhaByCCCD(string maCCCD)
        {
            string query = "SELECT * FROM ChuNha WHERE maCCCD = @maCCCD";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maCCCD", maCCCD);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ChuNha(
                            reader.GetString("maCCCD"),
                            reader.GetString("tenChuNha"),
                            reader.GetDateTime("ngaySinh"),
                            reader.GetString("gioiTinh"),
                            reader.GetString("soDienThoai"),
                            reader.GetString("diaChi"),
                            reader.GetInt32("maChuNha"),
                            reader.GetInt32("maTaiKhoan")
                        );
                    }
                }
            }
            return null;
        }

        public List<ChuNha> GetAllChuNha()
        {
            string query = "SELECT * FROM ChuNha";
            var chuNhaList = new List<ChuNha>();
            using (var cmd = new SqlCommand(query, _connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var chuNha = new ChuNha(
                            reader.GetString("maCCCD"),
                            reader.GetString("tenChuNha"),
                            reader.GetDateTime("ngaySinh"),
                            reader.GetString("gioiTinh"),
                            reader.GetString("soDienThoai"),
                            reader.GetString("diaChi"),
                            reader.GetInt32("maChuNha"),
                            reader.GetInt32("maTaiKhoan")
                        );
                        chuNhaList.Add(chuNha);
                    }
                }
            }
            return chuNhaList;
        }

        public void UpdateChuNha(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan)
        {
            string query = "UPDATE ChuNha SET tenChuNha = @ten, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, soDienThoai = @soDienThoai, diaChi = @diaChi, maTaiKhoan = @maTaiKhoan WHERE maCCCD = @maCCCD";
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
                        transaction.Commit();
                    }
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while updating a ChuNha", e);
                }
            }
        }
    }
}