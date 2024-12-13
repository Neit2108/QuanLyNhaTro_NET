using System;
using Microsoft.Data.SqlClient; // Use Microsoft.Data.SqlClient for .NET 8
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlTypes;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Policy;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util
{
    public static class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = null;
            try
            {
                // Sử dụng các phần đã định nghĩa để tạo chuỗi kết nối
                string connectionString = $"Server={Constant.Url};Database={Constant.Database};User Id={Constant.Username};Password={Constant.Password};Encrypt=True;TrustServerCertificate=True;";
                con = new SqlConnection(connectionString);
                con.Open();
                Console.WriteLine("Kết nối thành công!"); // Debug thông báo kết nối
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Lỗi SQL: {e.Message}");
            }
            return con;
        }
    }

}