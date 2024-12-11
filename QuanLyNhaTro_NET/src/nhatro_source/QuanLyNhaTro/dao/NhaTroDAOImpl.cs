using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class NhaTroDAOImpl : INhaTroDAO
    {
        private readonly SqlConnection _connection;

        public NhaTroDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            _connection.Open();
        }

        public List<NhaTro> GetAllNhaTroByMaChuNha(int maChuNha)
        {
            var nhaTros = new List<NhaTro>();
            string query = "SELECT * FROM NhaTro WHERE maChuNha = @maChuNha";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maChuNha", maChuNha);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nhaTros.Add(new NhaTro
                        {
                            MaNhaTro = reader.GetInt32("maNhaTro"),
                            MaChuNha = reader.GetInt32("maChuNha"),
                            DiaChi = reader.GetString("diaChi"),
                            SoLuongPhong = reader.GetInt32("soLuongPhong"),
                            TrangThai = reader.GetString("trangThai"),
                            UrlImage = reader.GetString("urlImage")
                        });
                    }
                }
            }
            return nhaTros;
        }

        public List<NhaTro> GetAllNhaTro()
        {
            var nhaTros = new List<NhaTro>();
            string query = "SELECT * FROM NhaTro";
            using (var cmd = new SqlCommand(query, _connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nhaTros.Add(new NhaTro
                        {
                            MaNhaTro = reader.GetInt32("maNhaTro"),
                            MaChuNha = reader.GetInt32("maChuNha"),
                            DiaChi = reader.GetString("diaChi"),
                            SoLuongPhong = reader.GetInt32("soLuongPhong"),
                            TrangThai = reader.GetString("trangThai"),
                            UrlImage = reader.GetString("urlImage")
                        });
                    }
                }
            }
            return nhaTros;
        }

        public void AddNhaTro(int maChuNha, string diaChi, int soLuongPhong, string trangThai, string urlImage)
        {
            string query = "INSERT INTO NhaTro(maChuNha, diaChi, soLuongPhong, trangThai, urlImage) VALUES(@maChuNha, @diaChi, @soLuongPhong, @trangThai, @urlImage)";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maChuNha", maChuNha);
                        cmd.Parameters.AddWithValue("@diaChi", diaChi);
                        cmd.Parameters.AddWithValue("@soLuongPhong", soLuongPhong);
                        cmd.Parameters.AddWithValue("@trangThai", trangThai);
                        cmd.Parameters.AddWithValue("@urlImage", urlImage);

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Error adding NhaTro", e);
                }
            }
        }

        public void UpdateNhaTro(int maNhaTro, int maChuNha, string diaChi, int soLuongPhong, string trangThai, string urlImage)
        {
            string query = "UPDATE NhaTro SET maChuNha = @maChuNha, diaChi = @diaChi, soLuongPhong = @soLuongPhong, trangThai = @trangThai, urlImage = @urlImage WHERE maNhaTro = @maNhaTro";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maChuNha", maChuNha);
                        cmd.Parameters.AddWithValue("@diaChi", diaChi);
                        cmd.Parameters.AddWithValue("@soLuongPhong", soLuongPhong);
                        cmd.Parameters.AddWithValue("@trangThai", trangThai);
                        cmd.Parameters.AddWithValue("@urlImage", urlImage);
                        cmd.Parameters.AddWithValue("@maNhaTro", maNhaTro);

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Error updating NhaTro", e);
                }
            }
        }

        public void DeleteNhaTro(int maNhaTro)
        {
            string query1 = "DELETE FROM Phong WHERE maNhaTro = @maNhaTro";
            string query2 = "DELETE FROM NhaTro WHERE maNhaTro = @maNhaTro";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd1 = new SqlCommand(query1, _connection, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@maNhaTro", maNhaTro);
                        cmd1.ExecuteNonQuery();
                    }
                    using (var cmd2 = new SqlCommand(query2, _connection, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@maNhaTro", maNhaTro);
                        cmd2.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Error deleting NhaTro", e);
                }
            }
        }

        public NhaTro GetNhaTroByMaNhaTro(int maNhaTro)
        {
            string query = "SELECT * FROM NhaTro WHERE maNhaTro = @maNhaTro";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maNhaTro", maNhaTro);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NhaTro
                        {
                            MaNhaTro = reader.GetInt32("maNhaTro"),
                            MaChuNha = reader.GetInt32("maChuNha"),
                            DiaChi = reader.GetString("diaChi"),
                            SoLuongPhong = reader.GetInt32("soLuongPhong"),
                            TrangThai = reader.GetString("trangThai"),
                            UrlImage = reader.GetString("urlImage")
                        };
                    }
                }
            }
            return null;
        }
    }
}