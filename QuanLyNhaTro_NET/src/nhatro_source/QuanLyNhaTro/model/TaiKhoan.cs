using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class TaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string VaiTro { get; set; }
        public DateTime NgayTao { get; set; }

        public TaiKhoan() { }

        public TaiKhoan(int maTaiKhoan, string email, string password, string vaiTro, DateTime ngayTao)
        {
            MaTaiKhoan = maTaiKhoan;
            Email = email;
            Password = password;
            VaiTro = vaiTro;
            NgayTao = ngayTao;
        }

        public override string ToString()
        {
            return $"TaiKhoan{{ maTaiKhoan='{MaTaiKhoan}', email='{Email}', password='{Password}', vaiTro='{VaiTro}', ngayTao='{NgayTao}' }}";
        }
    }
}