using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class TaiKhoanDAOImpl : ITaiKhoanDAO
    {
        private readonly SqlConnection _connection;

        public TaiKhoanDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            //_connection.Open();
        }

        public void AddTaiKhoan(string email, string password, string vaiTro)
        {
            string query = "INSERT INTO TaiKhoan(email, password, vaiTro) VALUES(@Email, @Password, @VaiTro)";
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", PasswordUtils.HashPassword(password));
                        cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Error adding TaiKhoan", e);
                }
            }
        }

        public List<TaiKhoan> GetAllTaiKhoan()
        {
            var list = new List<TaiKhoan>();
            string query = "SELECT * FROM TaiKhoan";
            using (var cmd = new SqlCommand(query, _connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaiKhoan
                        {
                            MaTaiKhoan = reader.GetInt32("maTaiKhoan"),
                            Email = reader.GetString("email"),
                            Password = reader.GetString("password"),
                            VaiTro = reader.GetString("vaiTro"),
                            NgayTao = reader.GetDateTime("ngayTao")
                        });
                    }
                }
            }
            return list;
        }

        public TaiKhoan GetTaiKhoan(int maTaiKhoan)
        {
            string query = "SELECT * FROM TaiKhoan WHERE maTaiKhoan = @MaTaiKhoan";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TaiKhoan
                        {
                            MaTaiKhoan = reader.GetInt32("maTaiKhoan"),
                            Email = reader.GetString("email"),
                            Password = reader.GetString("password"),
                            VaiTro = reader.GetString("vaiTro"),
                            NgayTao = reader.GetDateTime("ngayTao")
                        };
                    }
                }
            }
            return null;
        }

        public TaiKhoan GetTaiKhoan(string email)
        {
            string query = "SELECT * FROM TaiKhoan WHERE email = @Email";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TaiKhoan
                        {
                            MaTaiKhoan = reader.GetInt32("maTaiKhoan"),
                            Email = reader.GetString("email"),
                            Password = reader.GetString("password"),
                            VaiTro = reader.GetString("vaiTro"),
                            NgayTao = reader.GetDateTime("ngayTao")
                        };
                    }
                }
            }
            return null;
        }

        public void UpdateTaiKhoan(string email, string vaiTro)
        {
            string query = "UPDATE TaiKhoan SET vaiTro = @VaiTro WHERE email = @Email";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTaiKhoan(string email)
        {
            string query = "DELETE FROM TaiKhoan WHERE email = @Email";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetMaChuNha(int maTaiKhoan)
        {
            string query = "SELECT maChuNha FROM ChuNha WHERE maTaiKhoan = @MaTaiKhoan";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
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

        public int GetMaKhachThue(int maTaiKhoan)
        {
            string query = "SELECT maKhachThue FROM KhachThue WHERE maTaiKhoan = @MaTaiKhoan";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32("maKhachThue");
                    }
                }
            }
            return -1;
        }

        public int GetMaAdmin(int maTaiKhoan)
        {
            string query = "SELECT maAdmin FROM Admin WHERE maTaiKhoan = @MaTaiKhoan";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32("maAdmin");
                    }
                }
            }
            return -1;
        }

        public bool CheckLogin(string email)
        {
            string query = "SELECT isFirstLogin FROM TaiKhoan WHERE email = @Email";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetBoolean("isFirstLogin");
                    }
                }
            }
            return false;
        }

        public void UpdateLogin(string email)
        {
            string query = "UPDATE TaiKhoan SET isFirstLogin = 0 WHERE email = @Email";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();
            }
        }

        
    }
}