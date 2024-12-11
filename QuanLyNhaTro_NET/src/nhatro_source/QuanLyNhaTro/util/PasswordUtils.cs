using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util
{
    public class PasswordUtils
    {
        private const int Iterations = 10000; // số vòng lặp mã hóa
        private const int KeyLength = 256; // độ dài của key
        private const string Algorithm = "PBKDF2SHA256"; // Thuật toán mã hóa

        // Hàm mã hóa mật khẩu
        public static string HashPassword(string password)
        {
            byte[] salt = GetSalt();
            byte[] hash = HashPassword(password.ToCharArray(), salt);
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        // Hàm kiểm tra mật khẩu
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string[] parts = hashedPassword.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] hash = Convert.FromBase64String(parts[1]);
            byte[] calculatedHash = HashPassword(password.ToCharArray(), salt);
            return calculatedHash.SequenceEqual(hash);
        }

        // Hàm tạo salt
        private static byte[] GetSalt()
        {
            using (var sr = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16];
                sr.GetBytes(salt);
                return salt;
            }
        }

        // Hàm mã hóa mật khẩu
        private static byte[] HashPassword(char[] password, byte[] salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                return rfc2898DeriveBytes.GetBytes(KeyLength / 8); // Convert bits to bytes
            }
        }
    }
}