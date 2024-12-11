using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class TienThuDAOImpl : ITienThuDAO
    {
        private readonly SqlConnection _connection;

        public TienThuDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            _connection.Open();
        }

        public List<TienThuTienIch> GetAll()
        {
            var tienThuTienIchList = new List<TienThuTienIch>();
            string query = "SELECT * FROM TienThuTienIch";
            using (var cmd = new SqlCommand(query, _connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tienThuTienIch = new TienThuTienIch
                        {
                            MaTienThu = reader.GetInt32("maTienThu"),
                            MaPhong = reader.GetInt32("maPhong"),
                            NgayThu = reader.GetDateTime("ngayGhiDien").Date,
                            SoDienCu = reader.GetDouble("soDienCu"),
                            SoDienMoi = reader.GetDouble("soDienMoi"),
                            SoNuocCu = reader.GetDouble("soNuocCu"),
                            SoNuocMoi = reader.GetDouble("soNuocMoi"),
                            SoDienDaDung = reader.GetDouble("soDienDaDung"),
                            SoNuocDaDung = reader.GetDouble("soNuocDaDung")
                        };
                        tienThuTienIchList.Add(tienThuTienIch);
                    }
                }
            }
            return tienThuTienIchList;
        }

        public TienThuTienIch GetTienThu(int maTienThu)
        {
            string query = "SELECT * FROM TienThuTienIch WHERE maPhong = @MaPhong";
            var tienThuTienIch = new TienThuTienIch();
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@MaPhong", maTienThu);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tienThuTienIch.MaTienThu = reader.GetInt32("maTienThu");
                        tienThuTienIch.MaPhong = reader.GetInt32("maPhong");
                        tienThuTienIch.NgayThu = reader.GetDateTime("ngayGhiDien").Date;
                        tienThuTienIch.SoDienCu = reader.GetDouble("soDienCu");
                        tienThuTienIch.SoDienMoi = reader.GetDouble("soDienMoi");
                        tienThuTienIch.SoNuocCu = reader.GetDouble("soNuocCu");
                        tienThuTienIch.SoNuocMoi = reader.GetDouble("soNuocMoi");
                        tienThuTienIch.SoDienDaDung = reader.GetDouble("soDienDaDung");
                        tienThuTienIch.SoNuocDaDung = reader.GetDouble("soNuocDaDung");
                    }
                }
            }
            return tienThuTienIch;
        }

        public static void Main(string[] args)
        {
            var tienThuDAO = new TienThuDAOImpl();
            var tienThuTienIchList = tienThuDAO.GetAll();
            foreach (var tienThuTienIch in tienThuTienIchList)
            {
                Console.WriteLine(tienThuTienIch.MaTienThu);
            }
        }
    }
}