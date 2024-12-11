using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class Phong_DichVu_DAOImpl : IPhong_DichVu_DAO
    {
        private readonly SqlConnection _connection;

        public Phong_DichVu_DAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            _connection.Open();
        }

        public List<DichVu> GetAllDichVuPhong(int maPhong)
        {
            var dichVuList = new List<DichVu>();
            string query = "SELECT maDichVu FROM Phong_DichVu WHERE maPhong = @maPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maPhong", maPhong);
                using (var reader = cmd.ExecuteReader())
                {
                    var dichVuDAO = new DichVuDAOImpl();
                    while (reader.Read())
                    {
                        var dichVu = dichVuDAO.GetDichVu(reader.GetInt32("maDichVu"));
                        dichVuList.Add(dichVu);
                    }
                }
            }
            return dichVuList;
        }

        public List<string> GetAllTrangThaiPhong(int maPhong)
        {
            var trangThaiList = new List<string>();
            string query = "SELECT ghiChu FROM Phong_DichVu WHERE maPhong = @maPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maPhong", maPhong);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trangThaiList.Add(reader.GetString("ghiChu"));
                    }
                }
            }
            return trangThaiList;
        }

        public static void Main(string[] args)
        {
            var phongDichVuDAO = new Phong_DichVu_DAOImpl();
            var trangThaiList = phongDichVuDAO.GetAllTrangThaiPhong(5);
            foreach (var trangThai in trangThaiList)
            {
                Console.WriteLine(trangThai);
            }
        }
    }
}