using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public class CoSoVatChatDAOImpl : ICoSoVatChatDAO
    {
        private readonly SqlConnection _connection;

        public CoSoVatChatDAOImpl()
        {
            _connection = DatabaseConnection.GetConnection();
            _connection.Open();
        }

        public CoSoVatChat GetCoSoVatChat(int maCoSoVatChat)
        {
            string query = "SELECT * FROM CoSoVatChat WHERE maCSVC = @maCSVC";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maCSVC", maCoSoVatChat);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new CoSoVatChat(
                            reader.GetInt32("maCSVC"),
                            reader.GetString("tenCSVC"),
                            reader.GetString("trangThai")
                        );
                    }
                }
            }
            return null;
        }

        public List<CoSoVatChat> GetAllCoSoVatChat(int maPhong)
        {
            var coSoVatChatList = new List<CoSoVatChat>();
            string query = "SELECT csvc.maCSVC FROM Phong\n" +
                           "join KieuPhong on Phong.maKieuPhong = KieuPhong.maKieuPhong\n" +
                           "join KieuPhong_CoSoVatChat kpcsvc on KieuPhong.maKieuPhong = kpcsvc.maKieuPhong\n" +
                           "join CoSoVatChat csvc on kpcsvc.maCSVC = csvc.maCSVC\n" +
                           "WHERE maPhong = @maPhong";
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@maPhong", maPhong);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var coSoVatChat = GetCoSoVatChat(reader.GetInt32("maCSVC"));
                        coSoVatChatList.Add(coSoVatChat);
                    }
                }
            }
            return coSoVatChatList;
        }
    }
}