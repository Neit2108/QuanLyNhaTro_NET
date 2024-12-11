using System;
using Microsoft.Data.SqlClient; // Use Microsoft.Data.SqlClient for .NET 8
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlTypes;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util
{
    public static class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = null;
            try
            {
                string connectionString = $"Server={Constant.Url};User Id={Constant.Username};Password={Constant.Password};";
                con = new SqlConnection(connectionString);
                con.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return con;
        }
    }

}