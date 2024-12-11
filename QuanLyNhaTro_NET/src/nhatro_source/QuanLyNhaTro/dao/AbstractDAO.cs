using System;
using Microsoft.Data.SqlClient;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public abstract class AbstractDAO
    {
        protected void InsertPerson(SqlConnection conn, string sql, string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan)
        {
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(sql, conn, transaction))
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
                    throw new Exception("An error occurred while inserting a person", e);
                }
            }
        }

        protected void UpdatePerson(SqlConnection conn, string sql, string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maAdmin, int maTaiKhoan)
        {
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(sql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maCCCD", maCCCD);
                        cmd.Parameters.AddWithValue("@ten", ten);
                        cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@diaChi", diaChi);
                        cmd.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                        cmd.Parameters.AddWithValue("@maAdmin", maAdmin);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while updating a person", e);
                }
            }
        }
    }
}