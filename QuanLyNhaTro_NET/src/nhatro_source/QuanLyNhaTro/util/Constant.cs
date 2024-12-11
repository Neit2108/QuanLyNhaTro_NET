using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util
{
    public static class Constant
    {
        // Database
        public static readonly string Url = "Server=localhost,1433;Database=final_QuanLyNhaTro;Encrypt=True;TrustServerCertificate=True";
        public static readonly string Username = "sa";
        public static readonly string Password = "23102001";

        // Mail
        public static readonly string SenderMail = "ldungtien.210804@gmail.com";
        public static readonly string SenderPass = "cncawmbjswiyagwf";

        // Role
        public static TaiKhoan TaiKhoan;
        public static string Role;
    }

    
}