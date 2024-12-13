using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class ThongBaoDAOImpl : IThongBaoDAO
    {
        private readonly SqlConnection _connection;

        public ThongBaoDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            
        }

        public void AddThongBao(int maNguoiGui, int maNguoiNhan, string noiDung, string trangThai, int maPhong, string loaiThongBao)
        {
            string query = "INSERT INTO ThongBao(maNguoiGui, maNguoiNhan, noiDung, trangThai, maPhong, loaiThongBao) VALUES(@MaNguoiGui, @MaNguoiNhan, @NoiDung, @TrangThai, @MaPhong, @LoaiThongBao)";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaNguoiGui", maNguoiGui);
                        cmd.Parameters.AddWithValue("@MaNguoiNhan", maNguoiNhan);
                        cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                        cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                        cmd.Parameters.AddWithValue("@LoaiThongBao", loaiThongBao);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Error adding ThongBao", e);
                }
            }
        }

        public List<ThongBao> GetAllThongBao(int maNguoiNhan)
        {
            var thongBaoList = new List<ThongBao>();
            string query = "SELECT * FROM ThongBao WHERE maNguoiNhan = @MaNguoiNhan";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@MaNguoiNhan", maNguoiNhan);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var thongBao = new ThongBao
                        {
                            Id = reader.GetInt32("id"),
                            MaNguoiGui = reader.GetInt32("maNguoiGui"),
                            MaNguoiNhan = reader.GetInt32("maNguoiNhan"),
                            NoiDung = reader.GetString("noiDung"),
                            TrangThai = reader.GetString("trangThai"),
                            NgayTao = reader.GetDateTime("ngayTao").Date,
                            MaPhong = reader.GetInt32("maPhong"),
                            LoaiThongBao = reader.GetString("loaiThongBao")
                        };
                        thongBaoList.Add(thongBao);
                    }
                }
            }
            return thongBaoList;
        }

        public void UpdateTrangThaiThongBao(int id)
        {
            string query = "UPDATE ThongBao SET trangThai = N'Đã xem' WHERE id = @Id";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Error updating ThongBao status", e);
                }
            }
        }

        public ThongBao GetThongBao(int maThongBao)
        {
            string query = "SELECT * FROM ThongBao WHERE id = @Id";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", maThongBao);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ThongBao
                        {
                            Id = reader.GetInt32("id"),
                            MaNguoiGui = reader.GetInt32("maNguoiGui"),
                            MaNguoiNhan = reader.GetInt32("maNguoiNhan"),
                            NoiDung = reader.GetString("noiDung"),
                            TrangThai = reader.GetString("trangThai"),
                            NgayTao = reader.GetDateTime("ngayTao").Date,
                            MaPhong = reader.GetInt32("maPhong"),
                            LoaiThongBao = reader.GetString("loaiThongBao")
                        };
                    }
                }
            }
            return null;
        }

        public void DeleteThongBao(int maThongBao)
        {
            string query = "DELETE FROM ThongBao WHERE id = @Id";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Id", maThongBao);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Error deleting ThongBao", e);
                }
            }
        }

        public void DeleteAllThongBao(int maNguoiNhan)
        {
            string query = "DELETE FROM ThongBao WHERE maNguoiNhan = @MaNguoiNhan";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaNguoiNhan", maNguoiNhan);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Error deleting all ThongBao", e);
                }
            }
        }
    }
}