using System;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util
{
    public class Authenticator
    {
        private static readonly SqlConnection conn = DatabaseConnection.GetConnection();

        // Kiểm tra thông tin đăng nhập
        public static bool IsValidUser(string email, string password)
        {
            string sql = "SELECT password FROM TaiKhoan WHERE email = @Email";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPassword = reader["password"].ToString();
                            return PasswordUtils.VerifyPassword(password, hashedPassword);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        // Check email format
        public static bool IsValidEmail(string email)
        {
            string regex = @"^[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?$";
            return Regex.IsMatch(email, regex);
        }

        // Check length password
        public static bool IsValidPassword(string password)
        {
            return password.Length >= 6;
        }

        // Check ngày sinh
        public static string NormalizeDate(string inputDate)
        {
            // Kiểm tra null
            if (string.IsNullOrWhiteSpace(inputDate))
            {
                MessageBox.Show("Ngày nhập không được để trống!");
                return null;
            }

            inputDate = inputDate.Trim();

            // Các định dạng có thể nhập vào
            string[] inputFormats = { "dd/MM/yyyy", "MM-dd-yyyy", "yyyy.MM.dd", "yyyy/MM/dd", "yyyy-MM-dd" };

            // Chuẩn
            string outputFormat = "yyyy-MM-dd";

            // Thử từng định dạng đầu vào
            foreach (string format in inputFormats)
            {
                if (DateTime.TryParseExact(inputDate, format, null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return date.ToString(outputFormat);
                }
            }

            MessageBox.Show(
                $"Định dạng ngày không hợp lệ: {inputDate}" +
                "\nVui lòng nhập ngày theo một trong các định dạng sau: " +
                "\ndd/MM/yyyy, MM-dd-yyyy, yyyy.MM.dd, yyyy/MM/dd, yyyy-MM-dd");
            return null;
        }

        
    }
}